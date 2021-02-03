namespace UI_IB120117.Korisnici_forme
{
    partial class KorisniciLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naselje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivnost = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Akcijaobriši = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbcNaselja = new System.Windows.Forms.ComboBox();
            this.kk = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.Korisnik,
            this.Mail,
            this.Telefon,
            this.Adresa,
            this.Naselje,
            this.Aktivnost,
            this.Akcija,
            this.Akcijaobriši});
            this.dgvKorisnici.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvKorisnici.Location = new System.Drawing.Point(29, 91);
            this.dgvKorisnici.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(961, 433);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.KorisnikID.DefaultCellStyle = dataGridViewCellStyle1;
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.ReadOnly = true;
            this.KorisnikID.Visible = false;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.Korisnik.DefaultCellStyle = dataGridViewCellStyle2;
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            this.Korisnik.Width = 150;
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "E-mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 130;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Broj telefona";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            this.Telefon.Width = 130;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // Naselje
            // 
            this.Naselje.DataPropertyName = "Naziv";
            this.Naselje.HeaderText = "Naselje";
            this.Naselje.Name = "Naselje";
            this.Naselje.ReadOnly = true;
            // 
            // Aktivnost
            // 
            this.Aktivnost.DataPropertyName = "Status";
            this.Aktivnost.HeaderText = "Aktivnost";
            this.Aktivnost.Name = "Aktivnost";
            this.Aktivnost.ReadOnly = true;
            this.Aktivnost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktivnost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Akcija
            // 
            this.Akcija.HeaderText = "Akcija uredi";
            this.Akcija.Name = "Akcija";
            this.Akcija.Text = "Uredi";
            this.Akcija.UseColumnTextForButtonValue = true;
            // 
            // Akcijaobriši
            // 
            this.Akcijaobriši.HeaderText = "Akcija obriši";
            this.Akcijaobriši.Name = "Akcijaobriši";
            this.Akcijaobriši.Text = "Obriši";
            this.Akcijaobriši.UseColumnTextForButtonValue = true;
            // 
            // cbcNaselja
            // 
            this.cbcNaselja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcNaselja.FormattingEnabled = true;
            this.cbcNaselja.Location = new System.Drawing.Point(375, 35);
            this.cbcNaselja.Name = "cbcNaselja";
            this.cbcNaselja.Size = new System.Drawing.Size(188, 24);
            this.cbcNaselja.TabIndex = 96;
            this.cbcNaselja.SelectedIndexChanged += new System.EventHandler(this.cbcNaselja_SelectedIndexChanged);
            // 
            // kk
            // 
            this.kk.AutoSize = true;
            this.kk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kk.ForeColor = System.Drawing.Color.Black;
            this.kk.Location = new System.Drawing.Point(214, 38);
            this.kk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kk.Name = "kk";
            this.kk.Size = new System.Drawing.Size(129, 16);
            this.kk.TabIndex = 95;
            this.kk.Text = "Naselje korisnika";
            // 
            // KorisniciLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1017, 554);
            this.Controls.Add(this.cbcNaselja);
            this.Controls.Add(this.kk);
            this.Controls.Add(this.dgvKorisnici);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KorisniciLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prikaz korisnika";
            this.Load += new System.EventHandler(this.KorisniciLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.ComboBox cbcNaselja;
        private System.Windows.Forms.Label kk;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naselje;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivnost;
        private System.Windows.Forms.DataGridViewButtonColumn Akcija;
        private System.Windows.Forms.DataGridViewButtonColumn Akcijaobriši;
    }
}