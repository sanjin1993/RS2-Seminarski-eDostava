namespace UI_IB120117.narudzbe_forme
{
    partial class NarudzbeDetalji
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
            this.dgvJela = new System.Windows.Forms.DataGridView();
            this.NarudzbaStavkeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Restoran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lbLIME = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJela
            // 
            this.dgvJela.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvJela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NarudzbaStavkeID,
            this.Jelo,
            this.Restoran,
            this.Kolicina,
            this.Cijena,
            this.Iznos});
            this.dgvJela.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvJela.Location = new System.Drawing.Point(14, 167);
            this.dgvJela.Margin = new System.Windows.Forms.Padding(5);
            this.dgvJela.Name = "dgvJela";
            this.dgvJela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJela.Size = new System.Drawing.Size(681, 226);
            this.dgvJela.TabIndex = 114;
            // 
            // NarudzbaStavkeID
            // 
            this.NarudzbaStavkeID.DataPropertyName = "NarudzbaStavkeID";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.NarudzbaStavkeID.DefaultCellStyle = dataGridViewCellStyle1;
            this.NarudzbaStavkeID.HeaderText = "NarudzbaStavkeID";
            this.NarudzbaStavkeID.Name = "NarudzbaStavkeID";
            this.NarudzbaStavkeID.ReadOnly = true;
            this.NarudzbaStavkeID.Visible = false;
            // 
            // Jelo
            // 
            this.Jelo.DataPropertyName = "Jelo";
            this.Jelo.HeaderText = "Jelo";
            this.Jelo.Name = "Jelo";
            this.Jelo.ReadOnly = true;
            this.Jelo.Width = 130;
            // 
            // Restoran
            // 
            this.Restoran.DataPropertyName = "Restoran";
            this.Restoran.HeaderText = "Restoran";
            this.Restoran.Name = "Restoran";
            this.Restoran.ReadOnly = true;
            this.Restoran.Width = 150;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            this.Kolicina.Width = 150;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(70, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 116;
            this.label6.Text = "Telefon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(70, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 115;
            this.label8.Text = "Datum";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefon.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon.Location = new System.Drawing.Point(163, 76);
            this.lblTelefon.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(65, 17);
            this.lblTelefon.TabIndex = 118;
            this.lblTelefon.Text = "lbltelefon";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(163, 37);
            this.lblDatum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(63, 17);
            this.lblDatum.TabIndex = 117;
            this.lblDatum.Text = "lblDatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(426, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Prezime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 119;
            this.label4.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.ForeColor = System.Drawing.Color.Black;
            this.lblPrezime.Location = new System.Drawing.Point(521, 75);
            this.lblPrezime.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(73, 17);
            this.lblPrezime.TabIndex = 122;
            this.lblPrezime.Text = "lblPrezime";
            // 
            // lbLIME
            // 
            this.lbLIME.AutoSize = true;
            this.lbLIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLIME.Location = new System.Drawing.Point(521, 36);
            this.lbLIME.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbLIME.Name = "lbLIME";
            this.lbLIME.Size = new System.Drawing.Size(50, 17);
            this.lbLIME.TabIndex = 121;
            this.lbLIME.Text = "lbLIME";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresa.ForeColor = System.Drawing.Color.Black;
            this.lblAdresa.Location = new System.Drawing.Point(521, 119);
            this.lblAdresa.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(67, 17);
            this.lblAdresa.TabIndex = 124;
            this.lblAdresa.Text = "lblAdresa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(426, 119);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 123;
            this.label10.Text = "Adresa";
            // 
            // NarudzbeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(711, 412);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lbLIME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvJela);
            this.Name = "NarudzbeDetalji";
            this.Text = "Narudzbe detalji";
            this.Load += new System.EventHandler(this.NarudzbeDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJela;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaStavkeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Restoran;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lbLIME;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.Label label10;
    }
}