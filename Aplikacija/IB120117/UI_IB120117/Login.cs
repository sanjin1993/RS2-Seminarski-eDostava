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

namespace UI_IB120117
{
    public partial class Login : Form
    {
        APIServices _apiService = new APIServices("Korisnici/KorisnikByUserName");
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_Trazi_Click(object sender, EventArgs e)
        {
            var list = await _apiService.GetByNameDektop<esp_desktopKorisnickoIme_Result>(txtIme.Text);

            if (list !=null)
            {
                Korisnici k = new Korisnici();
                k.Adresa = list.Adresa;
                k.Ime = list.Ime;
                k.KorisnickoIme = list.KorisnickoIme;
                k.KorisnikID = list.KorisnikID;
                k.LozinkaHash = list.LozinkaHash;
                k.LozinkaSalt = list.LozinkaSalt;
                k.Mail = list.Mail;
                k.Prezime = list.Prezime;
                k.Status = list.Status;
                k.Telefon = list.Telefon;
                k.UlogaID = list.UlogaID;
                k.NaseljeID = list.NaseljeID;
                if (k == null)
                {
                    MessageBox.Show("Korisnik kojeg ste unijeli ne postoji u bazi podataka");

                }
                else
                {
                    if (k.LozinkaHash == UIHelper.GenerateHash(textBox1.Text, k.LozinkaSalt))
                    {
                        DialogResult = DialogResult.OK;
                        Global.TrenurnoPrijavljeniKorisnik = k;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Lozinka nije ispravna");
                        textBox1.Text = String.Empty;
                    }
                }
            }
            else
                MessageBox.Show("Error Code ");
        }
    }
}
