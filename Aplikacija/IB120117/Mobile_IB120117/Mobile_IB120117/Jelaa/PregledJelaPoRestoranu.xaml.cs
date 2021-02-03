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

namespace Mobile_IB120117.Jelaa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PregledJelaPoRestoranu : ContentPage
    {
        APIService _apiService = new APIService("Jela/JelaByRestoran");
        APIService _apiServiceRestoranVrsta = new APIService("Jela/JelaByRestoranVrsta");
        APIService _apiServiceVrsteJela = new APIService("VrsteJela");
        APIService _apiServiceid = new APIService("Jela/JeloByID"); 
        APIService _apiServicePreporucena = new APIService("Jela/PreporuceniRestorani");
        APIService _apiServiceRVN = new APIService("Jela/JelaByRestoranVrstaNaziv");
        
        int restoranID;
        public List<ViewModel.VrsteJela> vrste;
        int vrstaID;
        int jeloID;
        public PregledJelaPoRestoranu (int restoranID)
		{
			InitializeComponent ();
            this.restoranID = restoranID;
            this.BindingContext = new RootModel1
            {
                VrsteList = GetJobsInfo()
            };
        }

        private List<ViewModel.VrsteJela> GetJobsInfo()
        {
            var b = GetJobsAll();
            List<esp_VrsteJelaAll_Result> v = b.Result;
            var json = JsonConvert.SerializeObject(v);
            vrste = JsonConvert.DeserializeObject<List<ViewModel.VrsteJela>>(json);
            return vrste;
        }


        private Task<List<esp_VrsteJelaAll_Result>> GetJobsAll()
        {
            return Task.Run(() => _apiServiceVrsteJela.GetT<List<esp_VrsteJelaAll_Result>>().Result);
        }

        protected override void OnAppearing()
        {
            BindData();
            base.OnAppearing();
        }

        private async void BindData()
        {
            var response = await _apiService.GetById<List<esp_JelaByRestoranID_Result>>(restoranID.ToString());
            if (response!=null)
            {
                var jsonResult = JsonConvert.SerializeObject(response);
                List<esp_JelaByRestoranID_Result> jela = JsonConvert.DeserializeObject<List<esp_JelaByRestoranID_Result>>(jsonResult);
                MenuItemsListView.ItemsSource = jela;
            }
        }

        private void MenuItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (pickerh.SelectedIndex == -1 && naziv.Text == null)
            {
                jeloID = Convert.ToInt32((MenuItemsListView.SelectedItem as esp_JelaByRestoranID_Result).JeloID);
            }
            else
            {
                if (pickerh.SelectedIndex != -1 && naziv.Text == null)
                {
                    jeloID = Convert.ToInt32((MenuItemsListView.SelectedItem as esp_JelaByRestoranIDVrstaID_Result).JeloID);
                }
                else
                {

                    jeloID = Convert.ToInt32((MenuItemsListView.SelectedItem as esp_JelaByRestoranIDVrstaIDNazivv).JeloID);
                }
            }
            this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Jelaa.DetaljiJela(jeloID)));
        }
        private async void Pickerh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerh.SelectedIndex == -1)
            {
                BindData();
            }
            else
            {
                vrstaID = Convert.ToInt32((pickerh.SelectedItem as ViewModel.VrsteJela).VrsteJelaID);
                var response = await _apiServiceRestoranVrsta.GetByVrstaName<List<esp_JelaByRestoranIDVrstaID_Result>>(restoranID, vrstaID.ToString());
                if (response != null)
                {
                    var jsonResult = JsonConvert.SerializeObject(response);
                    List<esp_JelaByRestoranIDVrstaID_Result> jela = JsonConvert.DeserializeObject<List<esp_JelaByRestoranIDVrstaID_Result>>(jsonResult);
                    MenuItemsListView.ItemsSource = jela;
                }
            }
        }

        private async void Traži_Clicked(object sender, EventArgs e)
        {
            if (naziv.Text == "")
            {
                BindData();
            }
            else {
              
                if (vrstaID == 0)
                {
                  await  DisplayAlert("Upozorenje", "Za pretragu je potrebno odabrati vrstu jela!", "OK");
                }
                else
                {
                    var response = await _apiServiceRVN.GetByParametri<List<esp_JelaByRestoranIDVrstaIDNazivv>>(restoranID, vrstaID,naziv.Text);
                    if (response != null)
                    {
                        var jsonResult = JsonConvert.SerializeObject(response);
                        List<esp_JelaByRestoranIDVrstaIDNazivv> jela = JsonConvert.DeserializeObject<List<esp_JelaByRestoranIDVrstaIDNazivv>>(jsonResult);
                        MenuItemsListView.ItemsSource = jela;
                    }
                }               
            }
        }
    }
}