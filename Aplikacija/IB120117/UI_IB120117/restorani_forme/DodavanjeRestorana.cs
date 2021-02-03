using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_IB120117.Util;

namespace UI_IB120117.restorani_forme
{
    public partial class DodavanjeRestorana : Form
    {
        APIServices _apiService = new APIServices("Restorani");
        Restorani restoran { get; set; }
        public DodavanjeRestorana()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (restoran == null)
                {
                    restoran = new Restorani();
                }
                restoran.Aktivno = true;
                restoran.Adresa = txtAdresa.Text;
                restoran.Mail = txtMail.Text;
                restoran.Telefon = txtTelefon.Text;
                restoran.Naziv = textBox6.Text;
                restoran.KorisnikID = 1;
                
                var response = await _apiService.Insert<Restorani>(restoran);
                if (response != null)
                {

                    const string message =
"Uspješno ste dodali podatke o restoranu!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();

                }
                else {
                    const string message = "Podaci o restoranu nisu sačuvani!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearInput()
        {
            txtAdresa.Text = txtMail.Text = txtSlika.Text = txtTelefon.Text = textBox6.Text = "";
            pictureBox1.Image = null;
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (restoran == null)
                {
                    restoran = new Restorani();
                }

                txtSlika.Text = openFileDialog1.FileName;
                Image orgImage = Image.FromFile(openFileDialog1.FileName);
                MemoryStream ms = new MemoryStream();
                orgImage.Save(ms, ImageFormat.Jpeg);
                restoran.Slika = ms.ToArray();


                int resizedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageWidth"]);
                int resizedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImageHeight"]);
                int croppedImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageWidth"]);
                int croppedImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImageHeight"]);


                if (orgImage.Width > resizedImageWidth)
                {
                    Image resizedImg = UIHelper.ResizeImage(orgImage, new Size(resizedImageWidth, resizedImageHeight));

                    if (resizedImg.Width > croppedImageWidth && resizedImg.Height > croppedImageHeight)
                    {
                        int croppedXPosition = (resizedImg.Width - croppedImageWidth) / 2;
                        int croppedYPosition = (resizedImg.Height - croppedImageHeight) / 2;

                        Image croppedImg = UIHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImageWidth, croppedImageHeight));
                        pictureBox1.Image = croppedImg;

                        MemoryStream Ms = new MemoryStream();
                        croppedImg.Save(Ms, orgImage.RawFormat);

                        restoran.SlikaThumb = Ms.ToArray();

                    }
                    else
                    {
                        restoran = null;
                    }



                }
            }
        }

     

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Naziv restorana je obavezna.");
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAdresa.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdresa, "Adresa je obavezna.");
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTelefon.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTelefon, "Telefon je obavezna.");
            }
        }

        private void txtMail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMail, "Mail je obavezna.");
            }
        }

        private void txtSlika_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSlika.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSlika, "Slika je obavezna.");
            }
        }

     
    }
}
