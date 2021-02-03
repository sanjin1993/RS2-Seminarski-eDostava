using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_IB120117
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pretrageKlijenataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Korisnici_forme.KorisniciAdd k = new Korisnici_forme.KorisniciAdd();
            k.Show();
        }

        private void izmjenaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Korisnici_forme.KorisniciLista k = new Korisnici_forme.KorisniciLista();
            k.Show();
        }

        private void evidencijaZaposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jela_forme.AddJela j = new jela_forme.AddJela();
            j.Show();
        }


        private void pretragaJelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jela_forme.PretragaJela j = new jela_forme.PretragaJela();
            j.Show();
        }

        private void evidencijaProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restorani_forme.DodavanjeRestorana r = new restorani_forme.DodavanjeRestorana();
            r.Show();
        }

        private void evidencijaMeniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            komenatar_i_ocjene_forme.PregledKomentaraIOcjena kio = new komenatar_i_ocjene_forme.PregledKomentaraIOcjena();
            kio.Show();
        }

        private void pregledNarudžbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            narudzbe_forme.NarudzbePregled n = new narudzbe_forme.NarudzbePregled();
            n.Show();
        }

        private void pregledIzvještajaNarudžbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report_forme.Rpt_narudzbe rpt = new report_forme.Rpt_narudzbe();
            rpt.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Dobro došli, " + Global.TrenurnoPrijavljeniKorisnik.Ime + " " + Global.TrenurnoPrijavljeniKorisnik.Prezime;
        }

        private void pregledRestoranaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restorani_forme.RestoranLista rpt = new restorani_forme.RestoranLista();
            rpt.Show();
        }

        private void izmjenaLozinkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Korisnici_forme.IzmjenaLozinke k = new Korisnici_forme.IzmjenaLozinke();
            k.Show();
        }
    }
}
