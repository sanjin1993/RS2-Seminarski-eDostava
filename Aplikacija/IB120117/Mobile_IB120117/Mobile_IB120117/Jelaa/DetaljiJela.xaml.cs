using Mobile_IB120117.ViewModel;
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
using VelicinaJela = Mobile_IB120117.ViewModel.VelicinaJela;

namespace Mobile_IB120117.Jelaa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetaljiJela : ContentPage
	{
        APIService _apiService = new APIService("Jela");
        APIService _apiServiceVelicinaJela = new APIService("VelicinaJela/AllVelicineByJeloID");
        APIService _apiServiceid = new APIService("Jela/JeloByID");
        APIService _apiServicePreporucena = new APIService("Jela/PreporuceniRestorani");

        int jeloID;
        public List<ViewModel.VelicinaJela> velicine;
        public PCL_IB120117.Model.VelicinaJela v { get; set; }
        public jeloByJeloID jelo { get; set; }
        public Jela jela { get; set; }
        int velicinaID;
        decimal? cijena;

        public DetaljiJela (int jeloID)
		{
			InitializeComponent();
            this.jeloID = jeloID;
            this.BindingContext = new RootModel2
            {
                VelicinaList = GetJobsInfo()                
            };
        }

        private List<ViewModel.VelicinaJela> GetJobsInfo()
        {
            var b = GetJobsAll();
            List<esp_VelicinaJelaByJeloID_Result> v = b.Result;
            var json = JsonConvert.SerializeObject(v);
            velicine = JsonConvert.DeserializeObject<List<ViewModel.VelicinaJela>>(json);
            return velicine;
        }


        private Task<List<esp_VelicinaJelaByJeloID_Result>> GetJobsAll()
        {
            return Task.Run(() => _apiServiceVelicinaJela.GetById<List<esp_VelicinaJelaByJeloID_Result>>(jeloID.ToString()).Result);
        }


        protected async override void OnAppearing()
        {
            var response = await _apiServiceid.GetById<jeloByJeloID>(jeloID.ToString());
            if (response != null)
            {
                var json = JsonConvert.SerializeObject(response);
                jelo = JsonConvert.DeserializeObject<jeloByJeloID>(json);
                odabranoJelo.BindingContext = jelo;
                if (jelo != null)
                {
                    jela = new Jela();
                    jela.JeloID = jelo.JeloID;
                    jela.Aktivno = jelo.Aktivno;
                    jela.Naziv = jelo.Naziv;
                    jela.Opis = jelo.Opis;
                    jela.KorisnikID = jelo.KorisnikID;
                    jela.Restorani = new PCL_IB120117.Model.Restorani();
                    jela.RestoranID = jelo.RestoranID;
                    jela.Restorani.Naziv = jelo.Restoran;
                    jela.VrsteJela = new PCL_IB120117.Model.VrsteJela();
                    jela.VrsteJelaID = jelo.VrsteJelaID;
                    jela.VrsteJela.Naziv = jelo.Vrsta;
                }
            }
            var response1 = await _apiServicePreporucena.GetById<List<PreporuceniRestorani_Result>>(jeloID.ToString());
            if (response1 != null)
            {
                var json = JsonConvert.SerializeObject(response1);                           
                List<PreporuceniRestorani_Result> recommended = JsonConvert.DeserializeObject<List<PreporuceniRestorani_Result>>(json);
                MenuItemsListView.ItemsSource = recommended;
            }
            base.OnAppearing();
        }    
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Jelaa.OcjenaKomentarJela(jeloID)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Naruci_Clicked(object sender, EventArgs e)
        {
            gridnarudzba.IsVisible = true;     
        } 
        private void Pickerh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayAlert("Upozorenje", "  da da da" + velicinaID, "OK");
        }
        private void Pickerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            velicinaID = Convert.ToInt32((pickerm.SelectedItem as ViewModel.VelicinaJela).VelicinaJelaID);
            ViewModel.VelicinaJela vv = pickerm.SelectedItem as ViewModel.VelicinaJela;
            v = new PCL_IB120117.Model.VelicinaJela();
            v.Cijena = vv.Cijena;
            v.Naziv= vv.Naziv;
            v.VelicinaJelaID = velicinaID;            
            cijenaVelicine.Text = Convert.ToString("Cijena je " +(pickerm.SelectedItem as ViewModel.VelicinaJela).Cijena + " KM");           
        }
        private void Dodaj_Clicked(object sender, EventArgs e)
        {
            if (Global.AktivnaNarudzba == null)
            {
                Global.AktivnaNarudzba = new PCL_IB120117.Model.Narudzbe();
                Global.AktivnaNarudzba.BrojNarudzbe = "1/" + DateTime.Now.Day + "-" + DateTime.Now.Year;
                Global.AktivnaNarudzba.Datum = DateTime.Now;
                Global.AktivnaNarudzba.KlijentID = Global.prijavljeniKlijent.KlijentID;
                Global.AktivnaNarudzba.NarudzbaStavke = new List<NarudzbeStavke>();
            }
            if (inutKolicina.Text == "")
            {
                DisplayAlert("Upozorenje", "Unesite količinu!", "OK");
            }
            else
            {
                string message = "Uspjesno ste dodali jelo u korpu";

                NarudzbeStavke s = new NarudzbeStavke();
                s.JeloID = jeloID;
                s.VelicinaJelaID = velicinaID;
                s.Jela = jela;
                s.Kolicina = Convert.ToInt32(inutKolicina.Text);
                s.VelicinaJela = v;            

                Global.AktivnaNarudzba.NarudzbaStavke.Add(s);
                DisplayAlert("Uspjeh", message, "OK");
            }
            if (inutKolicina.Text != null && velicinaID!=0)
            {
                this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Narudzbe.TrenutneNarudzbe()));
            }
            else
            {
                DisplayAlert("Upozorenje", "Unesite količinu!", "OK");
            }
        }
    }
}