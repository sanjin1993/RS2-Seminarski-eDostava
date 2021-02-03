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

namespace UI_IB120117.Korisnici_forme
{
    public partial class KorisniciLista : Form
    {
        APIServices _apiService = new APIServices("Korisnici");
        APIServices _apiServiceKByNaselja = new APIServices("Korisnici/KorisniciByNaselja");
        APIServices _apiServiceNaselja = new APIServices("Naselja/getNaselja");
        

        public KorisniciLista()
        {
            InitializeComponent();
            
        }

        private void KorisniciLista_Load(object sender, EventArgs e)
        {

            LoadList();
        }

        private async void LoadList()
        {
            var list = await _apiServiceNaselja.GetT<List<esp_AllNaselja_Result>>();

            if (list != null)
            {
                List<esp_AllNaselja_Result> naselja = list;
                naselja.Insert(0, new esp_AllNaselja_Result());
                naselja[0].Naziv = "Odaberite naselje";
                cbcNaselja.DataSource = naselja;
                cbcNaselja.DisplayMember = "Naziv";
                cbcNaselja.ValueMember = "NaseljeID";
            }
            var listALL = await _apiService.GetT<List<esp_KorisniciAllForGrid_Result>>();

            if (listALL != null)
            {
                List<esp_KorisniciAllForGrid_Result> korisnici = listALL;
                dgvKorisnici.DataSource = korisnici;
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.Columns[9].Visible = false;
                dgvKorisnici.Columns[10].Visible = false;
                dgvKorisnici.Columns[11].Visible = false;
                dgvKorisnici.Columns[12].Visible = false;
                dgvKorisnici.Columns[13].Visible = false;
            }
        }

        private async void cbcNaselja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcNaselja.SelectedIndex == 0)
            {
                var list = await _apiService.GetT<List<esp_KorisniciAllForGrid_Result>>();

                if (list != null)
                {
                    List<esp_KorisniciAllForGrid_Result> korisnici = list;
                    dgvKorisnici.DataSource = korisnici;
                }
            }
            else
            {
                var list = await _apiServiceKByNaselja.GetById<List<esp_KorisniciAll_Result>>(cbcNaselja.SelectedValue.ToString());

                if (list != null)
                {
                    List<esp_KorisniciAll_Result> korisnici = list;
                    dgvKorisnici.DataSource = korisnici;                 
                }
            }
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.Columns[9].Visible = false;
            dgvKorisnici.Columns[10].Visible = false;
            dgvKorisnici.Columns[11].Visible = false;
            dgvKorisnici.Columns[12].Visible = false;
            dgvKorisnici.Columns[13].Visible = false;
        }

        private async void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string k = dgvKorisnici.SelectedCells[2].Value.ToString();
            int korisnikID;
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 )
            {
                if (dgvKorisnici.SelectedCells[e.ColumnIndex].Value.ToString() == "Uredi")
                {
                     korisnikID = Convert.ToInt32(k);
                    Korisnici_forme.KorisniciIzmjena kIzmjena = new Korisnici_forme.KorisniciIzmjena(korisnikID);
                    kIzmjena.Show();
                    this.Close();
                }
                else
                {
                    if (dgvKorisnici.SelectedCells[e.ColumnIndex].Value.ToString() == "Obriši")
                    {
                        korisnikID = Convert.ToInt32(k);

                        var list = await _apiService.Delete<Korisnici>(korisnikID);
                        if (list != null)
                        {
                            const string message = "Korisnik obrisan ! ";
                            const string caption = "Informacija";

                            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadList();
                        }
                    }
                }
            }
        }       
    }
}
