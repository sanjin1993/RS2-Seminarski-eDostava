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
    public partial class UrediRestoran : Form
    {
        APIServices _apiService = new APIServices("Restorani");
        Restorani restoran { get; set; }
        int restoranID;
        public UrediRestoran(int restoranID)
        {
            InitializeComponent();
            this.restoranID = restoranID;
            this.AutoValidate = AutoValidate.Disable;
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                restoran.RestoranID = restoran.RestoranID;
                restoran.Aktivno = true;
                restoran.Adresa = txtAdresa.Text;
                restoran.Mail = txtMail.Text;
                restoran.Telefon = txtTelefon.Text;
                restoran.Naziv = textBox6.Text;
                restoran.KorisnikID = 1;
                
                var response = _apiService.Update<Restorani>(restoran.RestoranID, restoran);
                if (response != null)
                {

                    const string message =
"Uspješno ste izmjenuli podatke o restoranu!";
                    const string caption = "Informacija";

                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();

                }
                else
                {
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

        private async void UrediRestoran_Load(object sender, EventArgs e)
        {
            esp_RestoraniByID_Result response = await _apiService.GetById<esp_RestoraniByID_Result>(restoranID);
            if (response != null)
            {
                restoran = new Restorani();
                restoran.RestoranID = response.RestoranID;
                restoran.KorisnikID = response.KorisnikID;
                restoran.Mail = response.Mail;
                restoran.Naziv = response.Naziv;
                restoran.Slika = response.Slika;
                restoran.SlikaThumb = response.SlikaThumb;
                restoran.Telefon = response.Telefon;
                restoran.Aktivno = response.Aktivno;
                restoran.Adresa = response.Adresa;
            }

            txtAdresa.Text = restoran.Adresa;
            txtMail.Text = restoran.Mail;
            txtTelefon.Text = restoran.Telefon;
            textBox6.Text = restoran.Naziv;
            txtSlika.Text = "Možete odabrati novu sliku za izmjenu";
            var ms = new MemoryStream(restoran.Slika);
            Image thumbImage = Image.FromStream(ms);
            pictureBox1.Image = thumbImage;
        }
    }
}
