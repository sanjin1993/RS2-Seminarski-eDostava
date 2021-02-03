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

namespace UI_IB120117.narudzbe_forme
{
    public partial class NarudzbeDetalji : Form
    {
        APIServices _apiServiceklijent = new APIServices("NarudzbaStavke/KlijentNarudzba");
        APIServices _apiServiceStavke = new APIServices("NarudzbaStavke/StavkeNarudzbe");

        int narudzbaID;
        public NarudzbeDetalji(int narudzbaID)
        {
            InitializeComponent();
            this.narudzbaID = narudzbaID;
        }

     
        private async void NarudzbeDetalji_Load(object sender, EventArgs e)
        { 
            var response = await _apiServiceklijent.GetById< esp_PodaciOKlijentuNarudzbeStavkeByNarudzba1_Result > (narudzbaID);
         
            if (response!=null)
            {
                esp_PodaciOKlijentuNarudzbeStavkeByNarudzba1_Result narudzbe = response;
                lblAdresa.Text = narudzbe.Adresa;
                lblDatum.Text = Convert.ToString(narudzbe.Datum);
                lbLIME.Text = narudzbe.Ime;
                lblPrezime.Text = narudzbe.Prezime;
                lblTelefon.Text = narudzbe.Telefon;
            }
        
            var response1 = await _apiServiceStavke.GetById<List<esp_AllNarudzbeStavkeByNarudzba_Result>>(narudzbaID);

            if (response1 != null)
            {
                List<esp_AllNarudzbeStavkeByNarudzba_Result> narudzbe = response1;
                dgvJela.DataSource = narudzbe;
                dgvJela.AutoGenerateColumns = false;
            }
        }

    }
}
