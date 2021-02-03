using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_IB120117.Util;

namespace UI_IB120117.jela_forme
{
    public partial class PretragaJela : Form
    {
        APIServices _apiServiceJela = new APIServices("Jela");
        APIServices _apiServiceJelByVrstaRestorana = new APIServices("Jela/AllJelaPretragaByVrstaRestoran");
        APIServices _apiServiceJelaPr = new APIServices("Jela/AllJelaPretragaByNaziv");
        APIServices _apiServiceJelaPretraga = new APIServices("Jela/AllJelaPretraga");
        APIServices _apiServiceRestorani = new APIServices("Restorani/AllRestorani");
        APIServices _apiServiceVrsteJela = new APIServices("VrsteJela");

        
        public PretragaJela()
        {
            InitializeComponent();
        }

        private void PretragaJela_Load(object sender, EventArgs e)
        {
            BindData();
            BindVrste();
            BindRestorani();
        }

        private async void BindRestorani()
        {
            var list = await _apiServiceRestorani.GetT<List<esp_RestoraniAll_Result>>();
            if (list != null)
            {
                List<esp_RestoraniAll_Result> restorani = list;
                restorani.Insert(0, new esp_RestoraniAll_Result());
                restorani[0].Naziv = "Odaberite restoran";
                comboBox1.DataSource = restorani;
                comboBox1.DisplayMember = "Naziv";
                comboBox1.ValueMember = "RestoranID";
            }
        }

        private async void BindVrste()
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

        private async void BindData()
        {
            var list = await _apiServiceJelaPretraga.GetT<List<esp_JelaZaPretraguAll_Result>>();
            if (list != null)
            {          
                List<esp_JelaZaPretraguAll_Result> jelaAll = list;
                dgvJela.DataSource = jelaAll;
                dgvJela.AutoGenerateColumns = false;
                dgvJela.Columns[8].Visible = false;
            }
        }

        private void btnNovoJelo_Click(object sender, EventArgs e)
        {
            jela_forme.AddJela jelo = new jela_forme.AddJela();
            jelo.Show();
            this.Close();
        }

        private async void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            string naziv = textBox6.Text.ToString();
            int VrstaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);
            int RestoranID = Convert.ToInt32(comboBox1.SelectedValue);
            if (e.KeyCode == Keys.Enter)
            {
                if (naziv == "")
                {
                    naziv = "null";
                   
                    var list = await _apiServiceJelByVrstaRestorana.GetByParametri<List<AllJelaPretragaByVrstaRestoran_Result>>(VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByVrstaRestoran_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                        dgvJela.AutoGenerateColumns = false;
                        dgvJela.Columns[8].Visible = false;
                    }
                }
                else
                {
                    var list = await _apiServiceJelaPr.GetAll<List<AllJelaPretragaByNaziv_Result>>(naziv, VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByNaziv_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                        dgvJela.AutoGenerateColumns = false;
                        dgvJela.Columns[8].Visible = false;
                    }
                }
            }
        }

        private async void cbxVrsteJela_SelectedIndexChanged(object sender, EventArgs e)
        {
            string naziv = textBox6.Text.Trim();
            int VrstaID;
            int RestoranID = Convert.ToInt32(comboBox1.SelectedValue);
            if (naziv == "")
            {
                naziv = "null";
                if (cbxVrsteJela.SelectedIndex == 0)
                {
                    VrstaID = 0;
                }
                else
                {
                    VrstaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);
                }
                var list = await _apiServiceJelByVrstaRestorana.GetByParametri<List<AllJelaPretragaByVrstaRestoran_Result>>(VrstaID, RestoranID);
                if (list != null)
                {                
                    List<AllJelaPretragaByVrstaRestoran_Result> jelaAll = list;
                    dgvJela.DataSource = jelaAll;
                    dgvJela.AutoGenerateColumns = false;
                    dgvJela.Columns[8].Visible = false;
                }
            }
           
        
            else{
                if (cbxVrsteJela.SelectedIndex == 0)
                {
                    VrstaID = 0;
                    var list = await _apiServiceJelaPr.GetAll<List<AllJelaPretragaByNaziv_Result>>(naziv, VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByNaziv_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                        dgvJela.AutoGenerateColumns = false;
                        dgvJela.Columns[8].Visible = false;

                    }
                }
                else
                {
                    VrstaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);

                    var list = await _apiServiceJelaPr.GetAll<List<AllJelaPretragaByNaziv_Result>>(naziv, VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByNaziv_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                        dgvJela.AutoGenerateColumns = false;
                        dgvJela.Columns[8].Visible = false;

                    }
                }
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string naziv = textBox6.Text.ToString();
            int VrstaID = Convert.ToInt32(cbxVrsteJela.SelectedValue);
            int RestoranID;

            if (naziv == "")
            {
                naziv = "null";
                if (comboBox1.SelectedIndex == 0)
                {
                    RestoranID = 0;
                }
                else
                {
                    RestoranID = Convert.ToInt32(comboBox1.SelectedValue);
                }
                var list = await _apiServiceJelByVrstaRestorana.GetByParametri<List<AllJelaPretragaByVrstaRestoran_Result>>(VrstaID, RestoranID);
                if (list != null)
                {
                    List<AllJelaPretragaByVrstaRestoran_Result> jelaAll = list; dgvJela.DataSource = jelaAll;
                    dgvJela.AutoGenerateColumns = false;
                    dgvJela.Columns[8].Visible = false;

                }
            }


            else
            {
                if (comboBox1.SelectedIndex == 0)
            {
                RestoranID = 0;
                    var list = await _apiServiceJelaPr.GetAll<List<AllJelaPretragaByNaziv_Result>>(naziv, VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByNaziv_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                    dgvJela.AutoGenerateColumns = false;
                    dgvJela.Columns[8].Visible = false;
                }
            }
            else
            {
                RestoranID = Convert.ToInt32(comboBox1.SelectedValue);
                    var list = await _apiServiceJelaPr.GetAll<List<AllJelaPretragaByNaziv_Result>>(naziv, VrstaID, RestoranID);
                    if (list != null)
                    {
                        List<AllJelaPretragaByNaziv_Result> jelaAll = list;
                        dgvJela.DataSource = jelaAll;
                    dgvJela.AutoGenerateColumns = false;
                    dgvJela.Columns[8].Visible = false;
                }
            }
        }
        }

        private void dgvJela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string k = dgvJela.SelectedCells[2].Value.ToString();
            int jeloID;
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dgvJela.SelectedCells[e.ColumnIndex].Value.ToString() == "Uredi")
                {
                    jeloID = Convert.ToInt32(k);
                    jela_forme.IzmjenaJela jIzmjena = new jela_forme.IzmjenaJela(jeloID);
                    jIzmjena.Show();
                    this.Close();
                }
                else
                {
                    if (dgvJela.SelectedCells[e.ColumnIndex].Value.ToString() == "Obriši")
                    {
                        jeloID = Convert.ToInt32(k);

                        var response = _apiServiceJela.Delete<Jela>(jeloID);
                        if (response != null)
                        {
                            const string message = "Jelo je obrisano ! ";
                            const string caption = "Informacija";

                            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData();
                        }
                    }
                }
            }
        }
    }
}
