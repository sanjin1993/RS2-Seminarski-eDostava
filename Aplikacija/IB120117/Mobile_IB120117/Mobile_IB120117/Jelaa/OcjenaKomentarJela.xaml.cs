using Newtonsoft.Json;
using PCL_IB120117.Model;
using PCL_IB120117.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Mobile_IB120117.Services.APIServices;

namespace Mobile_IB120117.Jelaa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OcjenaKomentarJela : ContentPage
	{
        APIService _apiService = new APIService("Jela/JeloByID");
        APIService _apiServiceKomentari = new APIService("Komentari");
        APIService _apiServiceOcjene = new APIService("Ocjene");
        int jeloID;
        Ocjene a;
        public OcjenaKomentarJela ( int jeloID)
		{
			InitializeComponent ();
            this.jeloID = jeloID;
		}
        protected async override void OnAppearing()
        {
            var response = await _apiService.GetById<jeloByJeloID>(jeloID.ToString());
            if (response != null)
            {
                var json = JsonConvert.SerializeObject(response);
                jeloByJeloID jelo = JsonConvert.DeserializeObject<jeloByJeloID>(json);                
                odabranoJeloOcjenaKom.BindingContext = jelo;
            }
            base.OnAppearing();
        }

        private void Komentiraj_Clicked(object sender, EventArgs e)
        {

            Komentari komentari = new Komentari();
            komentari.Datum = DateTime.Now;
            komentari.KlijentID= Global.prijavljeniKlijent.KlijentID;
            komentari.JeloID = jeloID;
            komentari.Komentar = inutKomentar.Text;
          
            var response = _apiServiceKomentari.Insert<Komentari>(komentari);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ostavili komentar na odabrano jelo!", "OK");
                inutKomentar.Text = "";
            }
        }

        private void Zvjezdica1_Clicked(object sender, EventArgs e)
        {
            a = new Ocjene();
            a.Datum = DateTime.Now;
            a.Ocjena = 1;
            a.JeloID = jeloID;
            a.KlijentID = Global.prijavljeniKlijent.KlijentID;

            var response = _apiServiceOcjene.Insert<Ocjene>(a);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ocjenuli jelo ocjenom 1 !", "OK");         
            }
        }

        private void Zvjezdica2_Clicked(object sender, EventArgs e)
        {
            a = new Ocjene();
            a.Datum = DateTime.Now;
            a.Ocjena = 2;
            a.JeloID = jeloID;
            a.KlijentID = Global.prijavljeniKlijent.KlijentID;

            var response = _apiServiceOcjene.Insert<Ocjene>(a);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ocjenuli jelo ocjenom 2 !", "OK");
            }
        }

        private void Zvjezdica3_Clicked(object sender, EventArgs e)
        {
            a = new Ocjene();
            a.Datum = DateTime.Now;
            a.Ocjena = 3;
            a.JeloID = jeloID;
            a.KlijentID = Global.prijavljeniKlijent.KlijentID;

            var response = _apiServiceOcjene.Insert<Ocjene>(a);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ocjenuli jelo ocjenom 3 !", "OK");
            }
        }

        private void Zvjezdica4_Clicked(object sender, EventArgs e)
        {
            a = new Ocjene();
            a.Datum = DateTime.Now;
            a.Ocjena = 4;
            a.JeloID = jeloID;
            a.KlijentID = Global.prijavljeniKlijent.KlijentID;

            var response = _apiServiceOcjene.Insert<Ocjene>(a);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ocjenuli jelo ocjenom 4 !", "OK");
            }
        }

        private void Zvjezdica5_Clicked(object sender, EventArgs e)
        {
            a = new Ocjene();
            a.Datum = DateTime.Now;
            a.Ocjena = 5;
            a.JeloID = jeloID;
            a.KlijentID = Global.prijavljeniKlijent.KlijentID;

            var response = _apiServiceOcjene.Insert<Ocjene>(a);
            if (response != null)
            {
                DisplayAlert("Uspjeh", "Uspješno ste ocjenuli jelo ocjenom 5 !", "OK");
            }
        }
    }
}