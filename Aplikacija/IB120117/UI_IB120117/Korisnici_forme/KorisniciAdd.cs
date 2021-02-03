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

namespace UI_IB120117.Korisnici_forme
{
    public partial class KorisniciAdd : Form
    {
        APIServices _apiService = new APIServices("Korisnici");
        APIServices _apiServiceUloge = new APIServices("Uloge");
        APIServices _apiServiceNaselja = new APIServices("Naselja/getNaselja");

        Korisnici k;

        public KorisniciAdd()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                k = new Korisnici();
                k.Ime = txtIme.Text;
                k.Prezime = txtPrezime.Text;
                k.Mail = txtMail.Text;
                k.Adresa = txtAdresa.Text;
                k.Telefon = txtTelefon.Text;
                k.KorisnickoIme = txtKorisnickoIme.Text;
                k.Status = true;
                k.NaseljeID = Convert.ToInt32(cbcNaselja.SelectedValue);

                k.LozinkaSalt = UIHelper.GenerateSalt();
                k.LozinkaHash = UIHelper.GenerateHash(txtLozinka.Text, k.LozinkaSalt);

                k.UlogaID = Convert.ToInt32(chbUlogeList.SelectedValue);             

                var list = _apiService.Insert<Korisnici>(k);

                if (list != null)
                {
                    const string message =
    "Uspješno ste dodali podatke o korisniku!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    
                }
                else
                {
                    const string message = "Podaci o korisniku nisu sačuvani!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void ClearInput()
        {
           txtAdresa.Text = txtIme.Text = txtPrezime.Text = txtMail.Text = txtTelefon.Text = txtKorisnickoIme.Text = txtLozinka.Text = "";
            cbcNaselja.SelectedValue = 0;
        }

        private void KorisniciAdd_Load(object sender, EventArgs e)
        {
            LoadNaselja();
            LoadUloge();
        }

        private async void LoadNaselja()
        {
            var list = await _apiServiceNaselja.GetT<List<esp_NaseljaAll_Result>>();

            if (list != null)
            {
                List<esp_NaseljaAll_Result> naselja = list;
                naselja.Insert(0, new esp_NaseljaAll_Result());
                naselja[0].Naziv = "Odaberite naselje";
                cbcNaselja.DataSource = naselja;
                cbcNaselja.DisplayMember = "Naziv";
                cbcNaselja.ValueMember = "NaseljeID";
            }
        }

        private async void LoadUloge()
        {
            var list = await _apiServiceUloge.GetT<List<esp_UlogeAll_Result>>();

            if (list != null)
            {
                List<esp_UlogeAll_Result> uloge = list;

                chbUlogeList.DataSource = uloge;
                chbUlogeList.DisplayMember = "Naziv";
                chbUlogeList.ValueMember = "UlogaID";
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtIme, "Ime je obavezno.");
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrezime.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPrezime, "Prezime je obavezno.");
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAdresa.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAdresa, "Adresa je obavezna.");
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTelefon.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTelefon, "Telefon je obavezan.");
            }
        }

        private void cbcNaselja_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(cbcNaselja.SelectedValue) == 0)
            {
                errorProvider.SetError(cbcNaselja, "Restoran je obavezno.");


            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtMail, "Mail je obavezan.");
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtKorisnickoIme.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtKorisnickoIme, "Korisnicko ime je obavezno.");
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLozinka.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtLozinka, "Lozinka je obavezna.");
            }
        }
    }
}
