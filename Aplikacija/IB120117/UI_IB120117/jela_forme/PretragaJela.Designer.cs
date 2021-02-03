namespace UI_IB120117.jela_forme
{
    partial class PretragaJela
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxVrsteJela = new System.Windows.Forms.ComboBox();
            this.kk = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovoJelo = new System.Windows.Forms.Button();
            this.dgvJela = new System.Windows.Forms.DataGridView();
            this.JeloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vrsta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Restoran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.Akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Akcijaobriši = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxVrsteJela
            // 
            this.cbxVrsteJela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVrsteJela.FormattingEnabled = true;
            this.cbxVrsteJela.Location = new System.Drawing.Point(344, 31);
            this.cbxVrsteJela.Margin = new System.Windows.Forms.Padding(4);
            this.cbxVrsteJela.Name = "cbxVrsteJela";
            this.cbxVrsteJela.Size = new System.Drawing.Size(142, 24);
            this.cbxVrsteJela.TabIndex = 100;
            this.cbxVrsteJela.SelectedIndexChanged += new System.EventHandler(this.cbxVrsteJela_SelectedIndexChanged);
            // 
            // kk
            // 
            this.kk.AutoSize = true;
            this.kk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kk.ForeColor = System.Drawing.Color.Black;
            this.kk.Location = new System.Drawing.Point(267, 34);
            this.kk.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.kk.Name = "kk";
            this.kk.Size = new System.Drawing.Size(67, 17);
            this.kk.TabIndex = 99;
            this.kk.Text = "Vrsta jela";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(86, 31);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(134, 23);
            this.textBox6.TabIndex = 98;
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 97;
            this.label8.Text = "Naziv";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(625, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 24);
            this.comboBox1.TabIndex = 102;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(540, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "Restoran";
            // 
            // btnNovoJelo
            // 
            this.btnNovoJelo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovoJelo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNovoJelo.ForeColor = System.Drawing.Color.Black;
            this.btnNovoJelo.Location = new System.Drawing.Point(800, 27);
            this.btnNovoJelo.Name = "btnNovoJelo";
            this.btnNovoJelo.Size = new System.Drawing.Size(107, 31);
            this.btnNovoJelo.TabIndex = 103;
            this.btnNovoJelo.Text = "Novo jelo";
            this.btnNovoJelo.UseVisualStyleBackColor = false;
            this.btnNovoJelo.Click += new System.EventHandler(this.btnNovoJelo_Click);
            // 
            // dgvJela
            // 
            this.dgvJela.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvJela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JeloID,
            this.Naziv,
            this.Opis,
            this.Vrsta,
            this.Restoran,
            this.Slika,
            this.Akcija,
            this.Akcijaobriši});
            this.dgvJela.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvJela.Location = new System.Drawing.Point(32, 77);
            this.dgvJela.Margin = new System.Windows.Forms.Padding(4);
            this.dgvJela.Name = "dgvJela";
            this.dgvJela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJela.Size = new System.Drawing.Size(875, 345);
            this.dgvJela.TabIndex = 104;
            this.dgvJela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJela_CellContentClick);
            // 
            // JeloID
            // 
            this.JeloID.DataPropertyName = "JeloID";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.JeloID.DefaultCellStyle = dataGridViewCellStyle3;
            this.JeloID.HeaderText = "JeloID";
            this.JeloID.Name = "JeloID";
            this.JeloID.ReadOnly = true;
            this.JeloID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "NazivJela";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Naziv.DefaultCellStyle = dataGridViewCellStyle4;
            this.Naziv.HeaderText = "Naziv jela";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 150;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "OpisJela";
            this.Opis.HeaderText = "Opis jela";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            this.Opis.Width = 150;
            // 
            // Vrsta
            // 
            this.Vrsta.DataPropertyName = "VrstaJela";
            this.Vrsta.HeaderText = "Vrsta jela";
            this.Vrsta.Name = "Vrsta";
            this.Vrsta.ReadOnly = true;
            this.Vrsta.Width = 130;
            // 
            // Restoran
            // 
            this.Restoran.DataPropertyName = "Restoran";
            this.Restoran.HeaderText = "Restoran";
            this.Restoran.Name = "Restoran";
            this.Restoran.ReadOnly = true;
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
            // PretragaJela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.dgvJela);
            this.Controls.Add(this.btnNovoJelo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxVrsteJela);
            this.Controls.Add(this.kk);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PretragaJela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pretraga jela";
            this.Load += new System.EventHandler(this.PretragaJela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxVrsteJela;
        private System.Windows.Forms.Label kk;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovoJelo;
        private System.Windows.Forms.DataGridView dgvJela;
        private System.Windows.Forms.DataGridViewTextBoxColumn JeloID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vrsta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Restoran;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewButtonColumn Akcija;
        private System.Windows.Forms.DataGridViewButtonColumn Akcijaobriši;
    }
}