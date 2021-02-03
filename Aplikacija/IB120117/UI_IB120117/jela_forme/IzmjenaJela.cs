using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_IB120117.Util;

namespace UI_IB120117.jela_forme
{
    public partial class IzmjenaJela : Form
    {
        APIServices _apiServiceJela = new APIServices("Jela");
        APIServices _apiServiceJelaLastJelo = new APIServices("Jela/LastJelo");
        APIServices _apiServiceRestorani = new APIServices("Restorani/AllRestorani");
        APIServices _apiServiceVrsteJela = new APIServices("VrsteJela");
        APIServices _apiServiceJelaID = new APIServices("Jela/JeloByID");


        Jela jelo { get; set; }
        int jeloID;
        esp_JeloByJeloID2_Result j;
        public IzmjenaJela(int jeloID)
        {
            InitializeComponent();
            this.jeloID = jeloID;
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void IzmjenaJela_Load(object sender, EventArgs e)
        {
            LoadVrsta();
            loadRestoran();
           
            var response = await _apiServiceJelaID.Get<esp_JeloByJeloID2_Result>(jeloID);

            if (response!=null)
            {
                j = response;
            }
            textBox5.Text = j.Opis;
            textBox6.Text = j.Naziv;
            cbxVrsteJela.SelectedValue = j.VrsteJelaID;
            cbxRestoran.SelectedValue = j.RestoranID;
            txtSlika.Text = "Možete odabrati novu sliku za izmjenu";
            var ms = new MemoryStream(j.Slika);
            Image thumbImage = Image.FromStream(ms);
            pictureBox1.Image = thumbImage;
        }

        private async void loadRestoran()
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
                txtSlika.Text = openFileDialog1.FileName;
                Image orgImage = Image.FromFile(openFileDialog1.FileName);
                MemoryStream ms = new MemoryStream();
                orgImage.Save(ms, ImageFormat.Jpeg);
                j.Slika = null;
                j.Slika = ms.ToArray();


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

                        j.SlikaThumb = Ms.ToArray();
                    }
                    else
                    {
                        j = null;
                    }
                }
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Opis je obavezno.");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Naziv je obavezno.");
            }
        }

        private void cbxVrsteJela_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(cbxVrsteJela.SelectedValue) == 0)
            {
                errorProvider1.SetError(cbxVrsteJela, "Vrsta jela je obavezna.");
            }
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                j.Aktivno = true;
                j.KorisnikID = j.KorisnikID;
                j.Naziv = textBox6.Text;
                j.Opis = textBox5.Text;
                j.RestoranID = Convert.ToInt32(cbxRestoran.SelectedValue);
                j.VrsteJelaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);
                j.Slika = j.Slika;
                j.SlikaThumb = j.SlikaThumb;
                j.JeloID = j.JeloID;

                var response =  _apiServiceJela.Update<Jela>(j.JeloID,j).Status;
                
                if (response != 0)
                {
                    const string message = "Uspješno ste izmjenuli podatke o jelu!";
                    const string caption = "Informacija";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    jela_forme.PretragaJela kl = new jela_forme.PretragaJela();
                    kl.Show();
                }
                else
                {
                    const string message = "Podaci o jelu nisu izmjenjeni!";
                    const string caption = "Informacija";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
