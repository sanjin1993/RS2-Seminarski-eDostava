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

namespace Mobile_IB120117.Restorani
{
	[ XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class PregledRestorana : ContentPage
	{
        APIService _apiService = new APIService("Restorani/AllRestorani");
        public PregledRestorana ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            var response  = await _apiService.GetT<List<esp_RestoraniAll_Result>>();
            if (response!= null)
            {
                var json = JsonConvert.SerializeObject(response);               
                List<esp_RestoraniAll_Result> restorani = JsonConvert.DeserializeObject<List<esp_RestoraniAll_Result>>(json);
                MenuItemsListView.ItemsSource = restorani;
            }
            base.OnAppearing();
        }

        private void MenuItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int restoranID = Convert.ToInt32((MenuItemsListView.SelectedItem as esp_RestoraniAll_Result).RestoranID);
            this.Navigation.PushModalAsync(new Navigation.MasterDetailPage1(new Jelaa.PregledJelaPoRestoranu(restoranID)));
        }
    }
}