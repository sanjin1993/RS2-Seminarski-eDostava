namespace UI_IB120117.restorani_forme
{
    partial class RestoranLista
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRest = new System.Windows.Forms.DataGridView();
            this.btnNovoJelo = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RestoranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Restoran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Akcijaobriši = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRest
            // 
            this.dgvRest.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RestoranID,
            this.Restoran,
            this.Adresa,
            this.Telefon,
            this.Mail,
            this.Slika,
            this.Akcija,
            this.Akcijaobriši});
            this.dgvRest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvRest.Location = new System.Drawing.Point(22, 76);
            this.dgvRest.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRest.Name = "dgvRest";
            this.dgvRest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRest.Size = new System.Drawing.Size(745, 345);
            this.dgvRest.TabIndex = 108;
            this.dgvRest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRest_CellContentClick);
            // 
            // btnNovoJelo
            // 
            this.btnNovoJelo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovoJelo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNovoJelo.ForeColor = System.Drawing.Color.Black;
            this.btnNovoJelo.Location = new System.Drawing.Point(480, 18);
            this.btnNovoJelo.Name = "btnNovoJelo";
            this.btnNovoJelo.Size = new System.Drawing.Size(107, 31);
            this.btnNovoJelo.TabIndex = 107;
            this.btnNovoJelo.Text = "Traži";
            this.btnNovoJelo.UseVisualStyleBackColor = false;
            this.btnNovoJelo.Click += new System.EventHandler(this.btnNovoJelo_Click);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(310, 22);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(134, 23);
            this.textBox6.TabIndex = 106;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(169, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 105;
            this.label8.Text = "Naziv restorana";
            // 
            // RestoranID
            // 
            this.RestoranID.DataPropertyName = "RestoranID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RestoranID.DefaultCellStyle = dataGridViewCellStyle2;
            this.RestoranID.HeaderText = "RestoranID";
            this.RestoranID.Name = "RestoranID";
            this.RestoranID.ReadOnly = true;
            this.RestoranID.Visible = false;
            // 
            // Restoran
            // 
            this.Restoran.DataPropertyName = "Restoran";
            this.Restoran.HeaderText = "Restoran";
            this.Restoran.Name = "Restoran";
            this.Restoran.ReadOnly = true;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            // 
            // Mail
            // 
            this.Mail.DataPropertyName = "Mail";
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Slika.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // RestoranLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRest);
            this.Controls.Add(this.btnNovoJelo);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RestoranLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pretraga restorana";
            this.Load += new System.EventHandler(this.RestoranLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRest;
        private System.Windows.Forms.Button btnNovoJelo;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestoranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Restoran;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewButtonColumn Akcija;
        private System.Windows.Forms.DataGridViewButtonColumn Akcijaobriši;
    }
}