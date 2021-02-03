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

namespace Mobile_IB120117.Narudzbe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrenutneNarudzbe : ContentPage
	{
        APIService _apiService = new APIService("Narudzbe");
        APIService _apiServiceNarudzbaStavke = new APIService("NarudzbaStavke");
        APIService _apiServiceNarudzbaZadnja = new APIService("Narudzbe/NarudzbaZadnja");
        
        public TrenutneNarudzbe ()
		{
			InitializeComponent ();
		}
        public class Aktivne
        {
            public string Naziv { get; set; }
            public string Restoran { get; set; }
            public string Opis { get; set; }
            public string Porcija { get; set; }
            public decimal? Cijena { get; set; }
            public int Kolicina { get; set; }
        }

        protected override void OnAppearing()
        {
            if (Global.AktivnaNarudzba != null)
            {

                List<Aktivne> jelas = new List<Aktivne>();
                Aktivne p;
                decimal? iznos = 0;

                foreach (NarudzbeStavke item in Global.AktivnaNarudzba.NarudzbaStavke)
                {
                    iznos += item.VelicinaJela.Cijena * item.Kolicina;
                    p = new Aktivne();
                    p.Opis = item.Jela.Opis;
                    p.Naziv = item.Jela.Naziv;
                    p.Restoran = item.Jela.Restorani.Naziv;
                    p.Porcija = item.VelicinaJela.Naziv;
                    p.Cijena = item.VelicinaJela.Cijena;
                    p.Kolicina = item.Kolicina;
                    jelas.Add(p);
                    p = null;
                }
                MenuItemsListView.ItemsSource = jelas;
                IznosLabel.Text = "Ukupan iznos: " + Math.Round(Convert.ToDecimal(iznos), 2) + " KM";
            }
            else
            {
                DisplayAlert("Informacija", "Trenutno nemate aktivnih narudzbi", "OK");
                this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Restorani.PregledRestorana()));
            }
            base.OnAppearing();
        }

        private async void Zakljuci_Clicked(object sender, EventArgs e)
        {
            if (Global.AktivnaNarudzba != null)
            {
                var response = _apiService.Insert<PCL_IB120117.Model.Narudzbe>(Global.AktivnaNarudzba);

                if (response!=null)
                {
                    var response2 = await _apiServiceNarudzbaZadnja.GetT<esp_Narudzba_Zadnja_Result>();

                    if (response2!=null)
                    {
                        var json = JsonConvert.SerializeObject(response2);
                        PCL_IB120117.Model.Narudzbe narudzba = JsonConvert.DeserializeObject<PCL_IB120117.Model.Narudzbe>(json);                    
                        
                        foreach (NarudzbeStavke item in Global.AktivnaNarudzba.NarudzbaStavke)
                        {
                            item.NarudzbaID = narudzba.NarudzbaID;

                            var response1 = _apiServiceNarudzbaStavke.Insert<PCL_IB120117.Model.NarudzbeStavke>(item);
                           
                            if (response1!=null)
                            {
                             await   DisplayAlert("Informacija", "Uspješno ste zaključili narudžbu.", "OK");
                             await   this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Restorani.PregledRestorana()));
                                Global.AktivnaNarudzba = null;
                            }
                        }
                    }
                }
                else
                {
                    foreach (NarudzbeStavke n in Global.AktivnaNarudzba.NarudzbaStavke)
                    {
                       await  DisplayAlert("Informacija", "Niste zaključili narudžbu.", "OK");
                    }
                    Global.AktivnaNarudzba = null;
                }
            }
        }
    }
}