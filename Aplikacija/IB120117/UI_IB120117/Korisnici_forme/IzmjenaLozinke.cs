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
    public partial class IzmjenaLozinke : Form
    {
        APIServices _apiService = new APIServices("Korisnici");

        public IzmjenaLozinke()
        {
            InitializeComponent();
        }

     
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool greska = false;
            Korisnici k = Global.TrenurnoPrijavljeniKorisnik;
            Global.TrenurnoPrijavljeniKorisnik = k;
            if (UIHelper.GenerateHash(txtLozinka.Text, k.LozinkaSalt)==k.LozinkaHash)
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text == textBox2.Text)
                    {
                        k.LozinkaSalt = UIHelper.GenerateSalt();
                        k.LozinkaHash = Util.UIHelper.GenerateHash(textBox1.Text, k.LozinkaSalt);
                    }
                    else
                    {
                        MessageBox.Show("Niste ponovili istu lozinku");
                        greska = true;
                        Clear();
                    }
                }

            }
            else
            {
                MessageBox.Show("Niste unjeli ispravnu lozinku (trenutnu)");
                greska = true;
                Clear();
            }
            if (greska == false)
            {
                var list = _apiService.Update<Korisnici>(k.KorisnikID,k);

                if (list != null)
                    MessageBox.Show("Uspjesno");
                else
                    MessageBox.Show("Neuspješno");
                Clear();
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txtLozinka.Text = "";
        }
    }
}
