namespace UI_IB120117
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.klijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretrageKlijenataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmjenaKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidencijaZaposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaJelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidencijaProizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledRestoranaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidencijaMeniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledNarudžbiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvještajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledIzvještajaNarudžbiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.izmjenaLozinkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klijentiToolStripMenuItem,
            this.zaposleniciToolStripMenuItem,
            this.proizvodiToolStripMenuItem,
            this.meniToolStripMenuItem,
            this.narudžbeToolStripMenuItem,
            this.izvještajToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // klijentiToolStripMenuItem
            // 
            this.klijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretrageKlijenataToolStripMenuItem,
            this.izmjenaKorisnikaToolStripMenuItem,
            this.izmjenaLozinkeToolStripMenuItem});
            this.klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            this.klijentiToolStripMenuItem.Size = new System.Drawing.Size(81, 25);
            this.klijentiToolStripMenuItem.Text = "Korisnici";
            // 
            // pretrageKlijenataToolStripMenuItem
            // 
            this.pretrageKlijenataToolStripMenuItem.Name = "pretrageKlijenataToolStripMenuItem";
            this.pretrageKlijenataToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.pretrageKlijenataToolStripMenuItem.Text = "Evidencija korisnika";
            this.pretrageKlijenataToolStripMenuItem.Click += new System.EventHandler(this.pretrageKlijenataToolStripMenuItem_Click);
            // 
            // izmjenaKorisnikaToolStripMenuItem
            // 
            this.izmjenaKorisnikaToolStripMenuItem.Name = "izmjenaKorisnikaToolStripMenuItem";
            this.izmjenaKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.izmjenaKorisnikaToolStripMenuItem.Text = "Pregled korisnika";
            this.izmjenaKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.izmjenaKorisnikaToolStripMenuItem_Click);
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evidencijaZaposlenikaToolStripMenuItem,
            this.pretragaJelaToolStripMenuItem});
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(48, 25);
            this.zaposleniciToolStripMenuItem.Text = "Jela";
            // 
            // evidencijaZaposlenikaToolStripMenuItem
            // 
            this.evidencijaZaposlenikaToolStripMenuItem.Name = "evidencijaZaposlenikaToolStripMenuItem";
            this.evidencijaZaposlenikaToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.evidencijaZaposlenikaToolStripMenuItem.Text = "Evidencija jela";
            this.evidencijaZaposlenikaToolStripMenuItem.Click += new System.EventHandler(this.evidencijaZaposlenikaToolStripMenuItem_Click);
            // 
            // pretragaJelaToolStripMenuItem
            // 
            this.pretragaJelaToolStripMenuItem.Name = "pretragaJelaToolStripMenuItem";
            this.pretragaJelaToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.pretragaJelaToolStripMenuItem.Text = "Pretraga jela";
            this.pretragaJelaToolStripMenuItem.Click += new System.EventHandler(this.pretragaJelaToolStripMenuItem_Click);
            // 
            // proizvodiToolStripMenuItem
            // 
            this.proizvodiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evidencijaProizvodaToolStripMenuItem,
            this.pregledRestoranaToolStripMenuItem});
            this.proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            this.proizvodiToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.proizvodiToolStripMenuItem.Text = "Restorani";
            // 
            // evidencijaProizvodaToolStripMenuItem
            // 
            this.evidencijaProizvodaToolStripMenuItem.Name = "evidencijaProizvodaToolStripMenuItem";
            this.evidencijaProizvodaToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.evidencijaProizvodaToolStripMenuItem.Text = "Evidencija restorana";
            this.evidencijaProizvodaToolStripMenuItem.Click += new System.EventHandler(this.evidencijaProizvodaToolStripMenuItem_Click);
            // 
            // pregledRestoranaToolStripMenuItem
            // 
            this.pregledRestoranaToolStripMenuItem.Name = "pregledRestoranaToolStripMenuItem";
            this.pregledRestoranaToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.pregledRestoranaToolStripMenuItem.Text = "Pregled restorana";
            this.pregledRestoranaToolStripMenuItem.Click += new System.EventHandler(this.pregledRestoranaToolStripMenuItem_Click);
            // 
            // meniToolStripMenuItem
            // 
            this.meniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evidencijaMeniaToolStripMenuItem});
            this.meniToolStripMenuItem.Name = "meniToolStripMenuItem";
            this.meniToolStripMenuItem.Size = new System.Drawing.Size(151, 25);
            this.meniToolStripMenuItem.Text = "Komentari i ocjene";
            // 
            // evidencijaMeniaToolStripMenuItem
            // 
            this.evidencijaMeniaToolStripMenuItem.Name = "evidencijaMeniaToolStripMenuItem";
            this.evidencijaMeniaToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.evidencijaMeniaToolStripMenuItem.Text = "Pregled komentara i ocjena";
            this.evidencijaMeniaToolStripMenuItem.Click += new System.EventHandler(this.evidencijaMeniaToolStripMenuItem_Click);
            // 
            // narudžbeToolStripMenuItem
            // 
            this.narudžbeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledNarudžbiToolStripMenuItem});
            this.narudžbeToolStripMenuItem.Name = "narudžbeToolStripMenuItem";
            this.narudžbeToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.narudžbeToolStripMenuItem.Text = "Narudžbe";
            // 
            // pregledNarudžbiToolStripMenuItem
            // 
            this.pregledNarudžbiToolStripMenuItem.Name = "pregledNarudžbiToolStripMenuItem";
            this.pregledNarudžbiToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.pregledNarudžbiToolStripMenuItem.Text = "Pregled narudžbi";
            this.pregledNarudžbiToolStripMenuItem.Click += new System.EventHandler(this.pregledNarudžbiToolStripMenuItem_Click);
            // 
            // izvještajToolStripMenuItem
            // 
            this.izvještajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledIzvještajaNarudžbiToolStripMenuItem});
            this.izvještajToolStripMenuItem.Name = "izvještajToolStripMenuItem";
            this.izvještajToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.izvještajToolStripMenuItem.Text = "Izvještaj";
            // 
            // pregledIzvještajaNarudžbiToolStripMenuItem
            // 
            this.pregledIzvještajaNarudžbiToolStripMenuItem.Name = "pregledIzvještajaNarudžbiToolStripMenuItem";
            this.pregledIzvještajaNarudžbiToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.pregledIzvještajaNarudžbiToolStripMenuItem.Text = "Pregled izvještaja narudžbi";
            this.pregledIzvještajaNarudžbiToolStripMenuItem.Click += new System.EventHandler(this.pregledIzvještajaNarudžbiToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // izmjenaLozinkeToolStripMenuItem
            // 
            this.izmjenaLozinkeToolStripMenuItem.Name = "izmjenaLozinkeToolStripMenuItem";
            this.izmjenaLozinkeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.izmjenaLozinkeToolStripMenuItem.Text = "Izmjena lozinke";
            this.izmjenaLozinkeToolStripMenuItem.Click += new System.EventHandler(this.izmjenaLozinkeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem klijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretrageKlijenataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidencijaZaposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidencijaProizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidencijaMeniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narudžbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledNarudžbiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmjenaKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaJelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvještajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledIzvještajaNarudžbiToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem pregledRestoranaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmjenaLozinkeToolStripMenuItem;
    }
}

