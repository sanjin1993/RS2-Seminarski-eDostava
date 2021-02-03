using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_IB120117.Services
{
   public class APIServices
    {
        public class APIService
        {
            public static string Username { get; set; }
            public static string Password { get; set; }

            private readonly string _route;

#if DEBUG
            private string _apiUrl = "http://localhost:56258/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api/";
#endif

            public APIService(string route)
            {
                _route = route;
            }
            public async Task<T> GetT<T>()
            {

                var result = await $"{_apiUrl}/{_route}".GetJsonAsync<T>();

                return result;

            }
            public async Task<T> Get<T>(object search)
            {
                var url = $"{_apiUrl}/{_route}";

                try
                {
                    if (search != null)
                    {
                        url += "?";
                        url += search;
                    }

                    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                }
                catch (FlurlHttpException ex)
                {
                    if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                    {
                        //MessageBox.Show("Niste authentificirani");
                        await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                    }
                    throw;
                }
            }

            public async Task<T> GetById<T>(string id)
            {

                try
                {
                    var url = $"{_apiUrl}/{_route}/{id}";

                    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                }
                catch (FlurlHttpException ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                    throw;
                }
            }
            public async Task<T> GetByVrstaName<T>(int vrsta, string naziv)
            {
                try
                {
                    var url = $"{_apiUrl}/{_route}/{vrsta}/{naziv}";

                    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                }
                catch (FlurlHttpException ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                    throw;
                }
            }
            public async Task<T> GetByParametri<T>(int restoran, int vrsta, string naziv)
            {
                try
                {
                    var url = $"{_apiUrl}/{_route}/{restoran}/{vrsta}/{naziv}";

                    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
                }
                catch (FlurlHttpException ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani", "OK");
                    throw;
                }
            }
            public async Task<T> Insert<T>(object request)
            {
                var url = $"{_apiUrl}/{_route}";

                try
                {
                    return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                }
                catch (FlurlHttpException ex)
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                    var stringBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                    }

                    await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                    return default(T);
                }

            }

            public async Task<T> Update<T>(int id, object request)
            {
                try
                {
                    var url = $"{_apiUrl}/{_route}/{id}";

                    return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
                }
                catch (FlurlHttpException ex)
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                    var stringBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                    }

                    await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                    return default(T);
                }

            }
        }
    }
}
