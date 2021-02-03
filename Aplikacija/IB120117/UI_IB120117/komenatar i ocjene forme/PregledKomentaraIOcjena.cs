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

namespace UI_IB120117.komenatar_i_ocjene_forme
{
    public partial class PregledKomentaraIOcjena : Form
    {
         APIServices _apiService = new APIServices("Komentari");

        public PregledKomentaraIOcjena()
        {
            InitializeComponent();
        }
        List<esp_AllKomentariOcjene_Result> All;
        private async void PregledKomentaraIOcjena_Load(object sender, EventArgs e)
        {
            var list = await _apiService.GetT<List<esp_AllKomentariOcjene_Result>>();
            if (list != null)
            {
                All = list;
                dgvJela.DataSource = All;
                dgvJela.AutoGenerateColumns = false;
                dgvJela.Columns[5].Visible = false;
                dgvJela.Columns[0].DisplayIndex = 5;
            }
        }

        private void dgvJela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string k = dgvJela.SelectedCells[1].Value.ToString();

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dgvJela.SelectedCells[e.ColumnIndex].Value.ToString() == "Učitaj")
                {
                    for (int i = 0; i < All.Count(); i++)
                    {
                        if (All[i].KomenatarID ==Convert.ToInt32(k))
                        {
                            textBox1.Text = All[i].Komentar.ToString();
                            
                        }
                    }
                }

            }
        }
    }
}
