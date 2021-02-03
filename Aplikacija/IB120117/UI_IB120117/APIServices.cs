using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Util;

namespace UI_IB120117
{
   public class APIServices
    {
        private string _route = null;

        public APIServices(string route)
        {
            _route = route;
        }
        public async Task<T> GetT<T>()
        {
            var result = await $"{Properties.Settings.Default.APIUrl}/{_route}".GetJsonAsync<T>();

            return result;

        }
        public static string Username { get; set; }
        public static string Password { get; set; }


        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "/";
                    url += search;
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Niste authentificirani");
                }
                throw;
            }
        }
        
        public async Task<T> Getisporuci<T>(bool id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByKorisnikId<T>(int id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByNameDektop<T>(string name)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{name}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByName<T>(string name)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{name}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        
        public async Task<T> GetByDatumiStatus<T>(string datumOd, string datumDo, bool status)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{datumOd}/{datumDo}/{status}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByDatumi<T>(string datumOd, string datumDo)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{datumOd}/{datumDo}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByNameJmbg<T>(object name, string jmbg)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{name}/{jmbg}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetAll<T>(string naziv, int korisnikID, int pacijentID)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{naziv}/{korisnikID}/{pacijentID}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByParametri<T>(int zahtjevID,  int pacijentID)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{zahtjevID}/{pacijentID}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByParametri<T>(int zahtjevID, int korisnikID, int pacijentID)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{zahtjevID}/{korisnikID}/{pacijentID}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> GetByZahtjevOdobri<T>(object zahtjev, bool odobri)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{zahtjev}/{odobri}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

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

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

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

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
        public async Task<T> Delete<T>(int id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
    }
}
