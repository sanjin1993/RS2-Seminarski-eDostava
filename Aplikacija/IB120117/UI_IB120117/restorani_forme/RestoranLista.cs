using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_IB120117.Util;

namespace UI_IB120117.restorani_forme
{
    public partial class RestoranLista : Form
    {
         
                 APIServices _apiServiceDel = new APIServices("Restorani");
        APIServices _apiService = new APIServices("Restorani/All");
        APIServices _apiServiceNaziv = new APIServices("Restorani/RestoranByName");
        
        public RestoranLista()
        {
            InitializeComponent();
        }

        private void RestoranLista_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            var response = await _apiService.GetT<List<esp_AllRestoraniLista_Result>>();
          //  HttpResponseMessage response = restoranService.GetResponse("All");

            if (response!= null)
            {
                List<esp_AllRestoraniLista_Result> restAll = response;
                dgvRest.DataSource = restAll;
                dgvRest.AutoGenerateColumns = false;

            }
        }

        private async void btnNovoJelo_Click(object sender, EventArgs e)
        {
            string naziv = textBox6.Text.Trim();
            if (naziv == "")
            {
                LoadData();
            }
            else
            {
                var response = await _apiServiceNaziv.GetByName<List<esp_AllRestoraniByNaziv_Result>>(naziv.ToString());
             //   HttpResponseMessage response = restoranService.GetActionResponse("RestoranByName", naziv.ToString());

                if (response != null)
                {
                    List<esp_AllRestoraniByNaziv_Result> restAll = response;
                    dgvRest.DataSource = restAll;
                    dgvRest.AutoGenerateColumns = false;

                }
            }
        }

        private async void dgvRest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string k = dgvRest.SelectedCells[2].Value.ToString();
            int restoranID;
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dgvRest.SelectedCells[e.ColumnIndex].Value.ToString() == "Uredi")
                {
                    restoranID = Convert.ToInt32(k);
                    restorani_forme.UrediRestoran jIzmjena = new restorani_forme.UrediRestoran(restoranID);
                    jIzmjena.Show();
                    this.Close();
                }
                else
                {
                    if (dgvRest.SelectedCells[e.ColumnIndex].Value.ToString() == "Obriši")
                    {
                        restoranID = Convert.ToInt32(k);

                        var response = await _apiServiceDel.Delete<Restorani>(restoranID);
                 
                        if (response != null)
                        {
                            const string message = "Restoran je obrisano ! ";
                            const string caption = "Informacija";

                            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }

            }
        }
    }
}
