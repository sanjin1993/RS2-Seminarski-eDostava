
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
using Naselja = Mobile_IB120117.ViewModel.Naselja;

namespace Mobile_IB120117
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfil : ContentPage
	{
        APIService _apiServiceKlijentiPost = new APIService("Klijenti");
        APIService _apiServiceNaselja = new APIService("Naselja/getNaselja");
        APIService _apiServiceNaseljaKlijenti = new APIService("NaseljaKlijenti");
        public List<Naselja> naselja;
        Klijenti k;
        NaseljaKlijenti nk;
        int naseljeID=0;
        int naseljeID2 = 0;
        List<ViewModel.Naselja> naselje;
        public UserProfil ()
		{
            InitializeComponent();
            this.BindingContext = new RootModel
            {
                NaseljeList = GetJobsInfo()
            };
        }

        private List<ViewModel.Naselja> GetJobsInfo()
        {
            var b = GetJobsAll();
            List<Naselja> v = b.Result;
            var json = JsonConvert.SerializeObject(v);
            naselje = JsonConvert.DeserializeObject<List<ViewModel.Naselja>>(json);
            return naselje;
        }

        private Task<List<Naselja>> GetJobsAll()
        {
            return Task.Run(() => _apiServiceNaselja.GetT<List<Naselja>>().Result);
        }

        protected override void OnAppearing()
        {
            naseljeID = 0;
            naseljeID2 = 0;
            k = null;
            nk = null;
            k = Global.prijavljeniKlijent;
            nk = Global.prijavljeniKlijentNaselje;
            inputUsername.Text = k.KorisnickoIme;
            inputIme.Text = k.Ime;
            inputPrezime.Text = k.Prezime;
            inputTelefon.Text = k.Telefon;
            naseljeID=Convert.ToInt32( nk.NaseljeID);
            pickerh.SelectedIndex = naseljeID;
           inputAresa.Text = k.Adresa;
            inputPasswordReg.Text=inputPasswordReg.Text;
            base.OnAppearing();
        }

        private async void Button1_Click(object sender, System.EventArgs e)
        {
            k = Global.prijavljeniKlijent;
            k.Ime = inputIme.Text;
            k.Prezime = inputPrezime.Text;
            k.KorisnickoIme = inputUsername.Text;
            k.Telefon = inputTelefon.Text;
            k.Adresa = inputAresa.Text;
            if (inputPasswordReg.Text == null)
            {
                k.LozinkaSalt = k.LozinkaSalt;
                k.LozinkaHash = k.LozinkaHash;
            }
            else
            {
                k.LozinkaSalt = UIHelper.GenerateSalt();
                k.LozinkaHash = UIHelper.GenerateHash(inputPasswordReg.Text, k.LozinkaSalt);
            }
            k.Status = true;
            if (naseljeID2 == naseljeID)
            {
                nk.NaseljeID = naseljeID;
            }
            else {
                nk.NaseljeID = naseljeID2;
            }
           
            nk.KlijentID = k.KlijentID;
            if (k.Ime == null || k.Prezime == null || k.KorisnickoIme == null || k.Adresa == null || k.Telefon == null || naseljeID == 0)
            {

                await DisplayAlert("Upozorenje", "Za izmjenu je potrebno popuniti sva polja!", "OK");

            }
            else
            {
                var response =  _apiServiceKlijentiPost.Update<Klijenti>(k.KlijentID,k).Status;
                if (response != 0)
                {
                    var response1 =  _apiServiceNaseljaKlijenti.Update<NaseljaKlijenti>(nk.NaseljaKlijentiID, nk).Status;
                    if (response1 != 0)
                    {
                        await DisplayAlert("Uspjeh", "Uspješno ste izmjenuli podatke!", "OK");
                        k = null;
                        nk = null;
                        App.Current.MainPage = new Mobile_IB120117.Login();               

                    }
                }
                else
                {
                    await DisplayAlert("Greška", "Došlo je do greške!", "OK");
                }
            }
        }

        private void Pickerh_SelectedIndexChanged(object sender, EventArgs e)
        {
            naseljeID2 = Convert.ToInt32((pickerh.SelectedItem as Naselja).NaseljeID);
        }
    }
}