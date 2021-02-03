
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
	public partial class Registration : ContentPage
	{
        APIService _apiService = new APIService("Klijenti/GetByUserNameKlijent");
        APIService _apiServiceKlijenti = new APIService("Klijenti/GetNaseljeIDByKlijentID");
        APIService _apiServiceKlijentiPost = new APIService("Klijenti");
        APIService _apiServiceNaselja = new APIService("Naselja/getNaselja");
        APIService _apiServiceNaseljaKlijenti = new APIService("NaseljaKlijenti");
        APIService _apiServiceKlijentiList = new APIService("Klijenti/GetKlijentLast");

        
        public List<Naselja> naselja;
        int naseljeID;
        List<ViewModel.Naselja> naselje;

        public Registration ()
		{
			InitializeComponent ();
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



        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            Klijenti k = new Klijenti();
            k.Ime = inputIme.Text;
            k.Prezime = inputPrezime.Text;
            k.KorisnickoIme = inputUsername.Text;
            k.Telefon = inputTelefon.Text;
            k.LozinkaSalt = UIHelper.GenerateSalt();
            k.LozinkaHash = UIHelper.GenerateHash(inputPasswordReg.Text, k.LozinkaSalt);
            k.Status = true;
            k.Adresa = inputAresa.Text;

            
            NaseljaKlijenti nk = new NaseljaKlijenti();
            nk.NaseljeID = naseljeID;

            if (k.Ime == null || k.Prezime == null || k.KorisnickoIme == null || k.Adresa == null || k.Telefon == null  || k.LozinkaSalt == null || naseljeID==0)
            {

                await DisplayAlert("Upozorenje", "Za registraciju je potrebno popuniti sva polja!", "OK");

            }
            else
            {
                var response = await _apiServiceKlijentiPost.Insert<Klijenti>(k);
                if (response!= null)
                {
                    esp_LastKlijent2_Result response1 = await _apiServiceKlijentiList.GetT<esp_LastKlijent2_Result>();
                    if (response1!=null)
                    {
                        var jsonResult = JsonConvert.SerializeObject(response1);
                        esp_LastKlijent2_Result kl = JsonConvert.DeserializeObject<esp_LastKlijent2_Result>(jsonResult);
                        nk.KlijentID = kl.KlijentID;
                        var response2 = _apiServiceNaseljaKlijenti.Insert<NaseljaKlijenti>(nk);
                        if (response2!=null)
                        {
                            await DisplayAlert("Uspjeh", "Uspješno ste se registrovali!", "OK");
                            App.Current.MainPage= new Mobile_IB120117.Login();
                        }
                    }
                }
                else
                {
                    DisplayAlert("Greška", "Došlo je do greške!", "OK");
                }
            }

        }

        private void PickerOne_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void Pickerh_SelectedIndexChanged(object sender, EventArgs e)
        {
            naseljeID =Convert.ToInt32( (pickerh.SelectedItem as Naselja ).NaseljeID);
        }
    }
}