using Newtonsoft.Json;
using System;
using PCL_IB120117.Model;
using PCL_IB120117.Util;
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
	public partial class HistorijaNarudzbi : ContentPage
	{
         APIService _apiService = new APIService("Narudzbe/Historija");
        public HistorijaNarudzbi ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            BindData();

            base.OnAppearing();
        }
        private async void BindData()
        {
            var response = await _apiService.GetById < List<esp_HistorijaNarudzbi>>(Global.prijavljeniKlijent.KlijentID.ToString());
            if (response != null)
            {
                var json = JsonConvert.SerializeObject(response);
                List<esp_HistorijaNarudzbi> restorani = JsonConvert.DeserializeObject<List<esp_HistorijaNarudzbi>>(json);
                MenuItemsListView.ItemsSource = restorani;
            }          
        }
    }
}