using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_IB120117.Util;
using System.Net.Http;

namespace UI_IB120117.jela_forme
{
    public partial class AddJela : Form
    {
        APIServices _apiServiceJela = new APIServices("Jela");
        APIServices _apiServiceJelaLastJelo = new APIServices("Jela/LastJelo");        
        APIServices _apiServiceRestorani = new APIServices("Restorani/AllRestorani");
        APIServices _apiServiceVrsteJela = new APIServices("VrsteJela");
        APIServices _apiServiceVelicinaJela = new APIServices("VelicinaJela/GetVelicinaJelas");
        APIServices _apiServiceVelicinaJelaTabela = new APIServices("VelicinaJelaTabela");

        Jela jelo   { get; set; }
        VelicinaJelaTabela vt;
        List<VelicinaJelaTabela> v = new List<VelicinaJelaTabela>();
        List<Velicine> velicine = new List<Velicine>();
        VelicinaJela vj;
        public AddJela()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

       
        private void AddJela_Load(object sender, EventArgs e)
        {
            LoadVelicina();
            LoadVrsta();
            LoadRestorani();
          
        }

        private async void LoadRestorani()
        {
            var list = await _apiServiceRestorani.GetT<List<esp_RestoraniAll_Result>>();
            if (list != null)
            {
                List<esp_RestoraniAll_Result> restorani = list;
                restorani.Insert(0, new esp_RestoraniAll_Result());
                restorani[0].Naziv = "Odaberite restoran";
                cbxRestoran.DataSource = restorani;
                cbxRestoran.DisplayMember = "Naziv";
                cbxRestoran.ValueMember = "RestoranID";
            }
        }

        private async void LoadVelicina()
        {
            var list = await _apiServiceVelicinaJela.GetT<List<esp_VelicinaJelaAll_Result>>();
            if (list != null)
            {
                List<esp_VelicinaJelaAll_Result> velicina = list;
                velicina.Insert(0, new esp_VelicinaJelaAll_Result());
                velicina[0].Naziv = "Odaberite veličinu jela";
                comboBox1.DataSource = velicina;
                comboBox1.DisplayMember = "Naziv";
                comboBox1.ValueMember = "VelicinaJelaID";
            }
        }

        private async void LoadVrsta()
        {
            var list = await _apiServiceVrsteJela.GetT<List<esp_VrsteJelaAll_Result>>();
            if (list != null)
            {
                List<esp_VrsteJelaAll_Result> cVrsteJela = list;
                cVrsteJela.Insert(0, new esp_VrsteJelaAll_Result());
                cVrsteJela[0].Naziv = "Odaberite vrstu jela";
                cbxVrsteJela.DataSource = cVrsteJela;
                cbxVrsteJela.DisplayMember = "Naziv";
                cbxVrsteJela.ValueMember = "VrsteJelaID";
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (jelo == null)
                {
                    jelo = new Jela();
                }
             
                txtSlika.Text = openFileDialog1.FileName;
                Image orgImage = Image.FromFile(openFileDialog1.FileName);
                MemoryStream ms = new MemoryStream();
                orgImage.Save(ms, ImageFormat.Jpeg);
                jelo.Slika = ms.ToArray();


                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);
                int croppedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageWidth"]);
                int croppedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageHeight"]);




                if (orgImage.Width > resizedImageWidth)
                {
                    Image resizedImg = UIHelper.ResizeImage(orgImage, new Size(resizedImageWidth, resizedImageHeight));

                    if (resizedImg.Width > croppedImageWidth && resizedImg.Height > croppedImageHeight)
                    {
                        int croppedXPosition = (resizedImg.Width - croppedImageWidth) / 2;
                        int croppedYPosition = (resizedImg.Height - croppedImageHeight) / 2;

                        Image croppedImg = UIHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImageWidth, croppedImageHeight));
                        pictureBox1.Image = croppedImg;

                        MemoryStream Ms = new MemoryStream();
                        croppedImg.Save(Ms, orgImage.RawFormat);

                        jelo.SlikaThumb = Ms.ToArray();
                    }
                    else
                    {
                        jelo = null;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {               
                 errorProvider.SetError(textBox1, "Cijena je obavezna.");               
            }
            else
            { 
                vt = new VelicinaJelaTabela();
                vj = new VelicinaJela();

                vj.Naziv = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                vj.VelicinaJelaID = Convert.ToInt32(comboBox1.SelectedValue);

                vt.Cijena = Convert.ToDecimal(textBox1.Text.ToString());
                vt.VelicinaJelaID = Convert.ToInt32(comboBox1.SelectedValue);
                vt.JeloID = 1;

                v.Add(vt);

                Velicine velicina = new Velicine();
                bool exists = false;
                velicina.Naziv = vj.Naziv;
                velicina.Cijena = Convert.ToString(vt.Cijena);
                if (velicine.Count() == 0)
                {
                    velicine.Add(velicina);
                }
                else
                {
                    for (int i = 0; i < velicine.Count(); i++)
                    {

                        if (velicine[i].Naziv == vj.Naziv)
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        const string message = "Cijena za odabranu veličinu je već dodana!";
                        const string caption = "Informacija";

                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        velicine.Add(velicina);
                    }
                }
                BindGrid();
            }
        }

        private void BindGrid()
        {
            dataGridView1.DataSource = 0;
            dataGridView1.DataSource = velicine;
            dataGridView1.AutoGenerateColumns = false;       
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (jelo == null)
                {
                    jelo = new Jela();
                }
                jelo.Aktivno = true;
                jelo.KorisnikID = 1;
                jelo.Naziv = textBox6.Text;
                jelo.Opis = textBox5.Text;
                jelo.VrsteJelaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);
                jelo.RestoranID = Convert.ToInt32(cbxRestoran.SelectedValue);

               

                var response = await _apiServiceJela.Insert<Jela>(jelo);
                esp_LastJelo_Result last;
                int brojac = 0;
                brojac = v.Count();
                if (response!=null)
                {
                    var response1 = await _apiServiceJelaLastJelo.GetT<esp_LastJelo_Result>();
                    if (response1!=null)
                    {
                        last = response1;

                        for (int i = 0; i < v.Count(); i++)
                        {
                            v[i].JeloID = last.JeloID;
                            var response2 = await _apiServiceVelicinaJelaTabela.Insert<VelicinaJelaTabela>(v[i]);
                            brojac--;
                        }

                        if (brojac==0)
                        {
                            const string message = "Uspješno ste dodali podatke o jelu!";
                            const string caption = "Informacija";

                            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInput();
                        }
                    }
                }
                else
                {
                    const string message = "Podaci o jelu nisu sačuvani!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void ClearInput()
        {
            txtSlika.Text =   textBox1.Text = textBox5.Text = textBox6.Text = "";
            comboBox1.SelectedValue = 0;
            cbxVrsteJela.SelectedValue = 0;
            cbxRestoran.SelectedValue = 0;
            pictureBox1.Image = null;
            dataGridView1.DataSource = null;
            v = null;
            vt = null;
            vj = null;
            velicine = null;
            v = new List<VelicinaJelaTabela>();
            velicine = new List<Velicine>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string naziv = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
            string cijena = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {                
                    if (dataGridView1.SelectedCells[e.ColumnIndex].Value.ToString() == "Obriši")
                    {
                    for (int i = 0; i < velicine.Count(); i++)
                    {
                        if (velicine[i].Naziv == naziv && velicine[i].Cijena == cijena)
                        {
                            velicine.Remove(velicine[i]);
                            BindGrid();
                        }
                    }
                    }                
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox6, "Opis je obavezno.");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox5, "Naziv je obavezno.");
            }
        }

        private void cbxVrsteJela_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(cbxVrsteJela.SelectedValue) == 0)
            {
                const string message = "Odabir vrste je obavezan!";
                const string caption = "Informacija!";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
            }
        }
        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                const string message = "Odabir veličine je obavezan!";
                const string caption = "Informacija!";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
            }
        }
            private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox1, "Cijena je obavezno.");
            }
        }

        private void txtSlika_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSlika.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtSlika, "Slika je obavezno.");
            }
        }

        private void cbxRestoran_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(cbxRestoran.SelectedValue) == 0)
            {
                errorProvider.SetError(cbxRestoran, "Restoran je obavezno.");
            }
        }
    }
}
