
using Mobile_IB120117.Services;
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

namespace Mobile_IB120117
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        APIService _apiService = new APIService("Klijenti/GetByUserNameKlijent");
        APIService _apiServiceKlijenti = new APIService("Klijenti/GetNaseljeIDByKlijentID");
        public Login ()
		{
			InitializeComponent ();
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var response = await _apiService.GetById<Klijenti>(inputUsername.Text);
            if (response != null)
            {
                var json = JsonConvert.SerializeObject(response);
                Klijenti k = JsonConvert.DeserializeObject<Klijenti>(json);
                Global.prijavljeniKlijent = k;

                var response1 = await _apiServiceKlijenti.GetById<NaseljaKlijenti>(k.KlijentID.ToString());
                if (response1 != null)
                {
                    var jsonResult1 = JsonConvert.SerializeObject(response1);
                    NaseljaKlijenti kl = JsonConvert.DeserializeObject<NaseljaKlijenti>(jsonResult1);
                    Global.prijavljeniKlijentNaselje = kl;
                    var v = UIHelper.GenerateHash(inputPassword.Text, k.LozinkaSalt);
                    if (k.LozinkaHash == v)
                    {
                       await  this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Restorani.PregledRestorana()));
                    }
                    else
                    {
                      await  DisplayAlert("Upozorenje", "Lozinka nije ispravna!", "OK");
                    }
                }
            }
            else
            {
               await DisplayAlert("Greška", "Niste unijeli ispravne podatke za prijavu!", "OK");
            }
        }
    }
}