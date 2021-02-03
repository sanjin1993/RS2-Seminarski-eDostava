using API_IB120117.Models;
using Microsoft.Reporting.WinForms;
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

namespace UI_IB120117.report_forme
{
    public partial class Rpt_narudzbe : Form
    {
        WebAPIHelper narudzbeService = new WebAPIHelper("http://localhost:56258/", "api/Narudzbe");
        WebAPIHelper klijentiService = new WebAPIHelper("http://localhost:56258/", "api/Klijenti");
        public Rpt_narudzbe()
        {
            InitializeComponent();
        }

        private void Rpt_narudzbe_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = klijentiService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<esp_AllKlijenti_Result> klijenti = response.Content.ReadAsAsync<List<esp_AllKlijenti_Result>>().Result;
                klijenti.Insert(0, new esp_AllKlijenti_Result());
                klijenti[0].Ime = "Odaberite klijenta";
                comboBox1.DataSource = klijenti;
                comboBox1.DisplayMember = "Ime";
                comboBox1.ValueMember = "KlijentID";
            }
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            string datumOd = d1.ToString("MM-dd-yyy");
            DateTime d2 = dateTimePicker2.Value;
            string datumDo = d2.ToString("MM-dd-yyy");
            bool status;
            string klijentID;
            if(checkBox1.Checked)
            {
                status = false;
            }else
            {
                status = true;
            }
            klijentID = Convert.ToString(comboBox1.SelectedValue);
            if (klijentID == "0")
            {
                MessageBox.Show("Za ptrtragu je potrebno odabrati klijenta", "Informacija");
            }
            else
            {
                HttpResponseMessage response = narudzbeService.GetActionResponseResponse3("Report", klijentID, status, datumOd, datumDo);
                if (response.IsSuccessStatusCode)
                {
                    List<esp_Narudzbe_DateOdDateDoREPORT_Result> NARUDZBE = response.Content.ReadAsAsync<List<esp_Narudzbe_DateOdDateDoREPORT_Result>>().Result;
                    Microsoft.Reporting.WinForms.ReportParameter p1 = new ReportParameter("datumOd", "  " + datumOd);
                    Microsoft.Reporting.WinForms.ReportParameter p2 = new ReportParameter("datumDo", "  " + datumDo);

                    ReportDataSource rpt = new ReportDataSource("DataSet1", NARUDZBE);

                    reportViewer1.LocalReport.ReportEmbeddedResource = "UI_IB120117.report_forme.Report1.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rpt);
                    NARUDZBE = null;

                }
                datumOd = datumDo = "";
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
