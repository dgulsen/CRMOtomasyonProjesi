namespace OyunCRM.UserInterface
{
    partial class FrmUyeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUyeler));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewuyelistesi = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerUyeKayitTarihi = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonUyePasif = new System.Windows.Forms.RadioButton();
            this.radioButtonUyeAktif = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxUyeAciklama = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxUyeAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxUyeYetki = new System.Windows.Forms.ComboBox();
            this.comboBoxUyePersoneller = new System.Windows.Forms.ComboBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUyeEkle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUyeGuncelle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUyeSil = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewuyelistesi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewuyelistesi);
            this.groupBox2.Location = new System.Drawing.Point(0, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 182);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ÜYE LİSTESİ";
            // 
            // dataGridViewuyelistesi
            // 
            this.dataGridViewuyelistesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewuyelistesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewuyelistesi.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewuyelistesi.Name = "dataGridViewuyelistesi";
            this.dataGridViewuyelistesi.Size = new System.Drawing.Size(658, 163);
            this.dataGridViewuyelistesi.TabIndex = 0;
            this.dataGridViewuyelistesi.DoubleClick += new System.EventHandler(this.dataGridViewuyelistesi_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerUyeKayitTarihi);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxUyeAciklama);
            this.groupBox1.Controls.Add(this.textBoxSifre);
            this.groupBox1.Controls.Add(this.textBoxUyeAdi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxUyeYetki);
            this.groupBox1.Controls.Add(this.comboBoxUyePersoneller);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 168);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ÜYELER";
            // 
            // dateTimePickerUyeKayitTarihi
            // 
            this.dateTimePickerUyeKayitTarihi.CustomFormat = "";
            this.dateTimePickerUyeKayitTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerUyeKayitTarihi.Location = new System.Drawing.Point(321, 15);
            this.dateTimePickerUyeKayitTarihi.Name = "dateTimePickerUyeKayitTarihi";
            this.dateTimePickerUyeKayitTarihi.Size = new System.Drawing.Size(131, 20);
            this.dateTimePickerUyeKayitTarihi.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonUyePasif);
            this.panel3.Controls.Add(this.radioButtonUyeAktif);
            this.panel3.Location = new System.Drawing.Point(71, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(131, 21);
            this.panel3.TabIndex = 8;
            // 
            // radioButtonUyePasif
            // 
            this.radioButtonUyePasif.AutoSize = true;
            this.radioButtonUyePasif.Location = new System.Drawing.Point(64, 1);
            this.radioButtonUyePasif.Name = "radioButtonUyePasif";
            this.radioButtonUyePasif.Size = new System.Drawing.Size(55, 17);
            this.radioButtonUyePasif.TabIndex = 5;
            this.radioButtonUyePasif.TabStop = true;
            this.radioButtonUyePasif.Text = "PASİF";
            this.radioButtonUyePasif.UseVisualStyleBackColor = true;
            // 
            // radioButtonUyeAktif
            // 
            this.radioButtonUyeAktif.AutoSize = true;
            this.radioButtonUyeAktif.Location = new System.Drawing.Point(3, 1);
            this.radioButtonUyeAktif.Name = "radioButtonUyeAktif";
            this.radioButtonUyeAktif.Size = new System.Drawing.Size(55, 17);
            this.radioButtonUyeAktif.TabIndex = 5;
            this.radioButtonUyeAktif.TabStop = true;
            this.radioButtonUyeAktif.Text = "AKTİF";
            this.radioButtonUyeAktif.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "DURUMU";
            // 
            // textBoxUyeAciklama
            // 
            this.textBoxUyeAciklama.Location = new System.Drawing.Point(321, 59);
            this.textBoxUyeAciklama.Multiline = true;
            this.textBoxUyeAciklama.Name = "textBoxUyeAciklama";
            this.textBoxUyeAciklama.Size = new System.Drawing.Size(131, 59);
            this.textBoxUyeAciklama.TabIndex = 2;
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Location = new System.Drawing.Point(71, 59);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(131, 20);
            this.textBoxSifre.TabIndex = 2;
            this.textBoxSifre.UseSystemPasswordChar = true;
            // 
            // textBoxUyeAdi
            // 
            this.textBoxUyeAdi.Location = new System.Drawing.Point(71, 15);
            this.textBoxUyeAdi.Name = "textBoxUyeAdi";
            this.textBoxUyeAdi.Size = new System.Drawing.Size(131, 20);
            this.textBoxUyeAdi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "YETKİ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "ŞİFRE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "AÇIKLAMA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "KAYIT TARİHİ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ÜYE ADI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PERSONEL";
            // 
            // comboBoxUyeYetki
            // 
            this.comboBoxUyeYetki.FormattingEnabled = true;
            this.comboBoxUyeYetki.Location = new System.Drawing.Point(523, 72);
            this.comboBoxUyeYetki.Name = "comboBoxUyeYetki";
            this.comboBoxUyeYetki.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUyeYetki.TabIndex = 0;
            // 
            // comboBoxUyePersoneller
            // 
            this.comboBoxUyePersoneller.FormattingEnabled = true;
            this.comboBoxUyePersoneller.Location = new System.Drawing.Point(523, 8);
            this.comboBoxUyePersoneller.Name = "comboBoxUyePersoneller";
            this.comboBoxUyePersoneller.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUyePersoneller.TabIndex = 0;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUyeEkle,
            this.toolStripButtonUyeGuncelle,
            this.toolStripButtonUyeSil});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(670, 25);
            this.toolStrip4.TabIndex = 11;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButtonUyeEkle
            // 
            this.toolStripButtonUyeEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUyeEkle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUyeEkle.Image")));
            this.toolStripButtonUyeEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUyeEkle.Name = "toolStripButtonUyeEkle";
            this.toolStripButtonUyeEkle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUyeEkle.Text = "toolStripButton1";
            this.toolStripButtonUyeEkle.Click += new System.EventHandler(this.toolStripButtonUyeEkle_Click);
            // 
            // toolStripButtonUyeGuncelle
            // 
            this.toolStripButtonUyeGuncelle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUyeGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUyeGuncelle.Image")));
            this.toolStripButtonUyeGuncelle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUyeGuncelle.Name = "toolStripButtonUyeGuncelle";
            this.toolStripButtonUyeGuncelle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUyeGuncelle.Text = "toolStripButton2";
            this.toolStripButtonUyeGuncelle.Click += new System.EventHandler(this.toolStripButtonUyeGuncelle_Click);
            // 
            // toolStripButtonUyeSil
            // 
            this.toolStripButtonUyeSil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUyeSil.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUyeSil.Image")));
            this.toolStripButtonUyeSil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUyeSil.Name = "toolStripButtonUyeSil";
            this.toolStripButtonUyeSil.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUyeSil.Text = "toolStripButton3";
            this.toolStripButtonUyeSil.Click += new System.EventHandler(this.toolStripButtonUyeSil_Click);
            // 
            // FrmUyeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip4);
            this.Name = "FrmUyeler";
            this.Text = "FrmUyeler";
            this.Load += new System.EventHandler(this.FrmUyeler_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewuyelistesi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewuyelistesi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerUyeKayitTarihi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonUyePasif;
        private System.Windows.Forms.RadioButton radioButtonUyeAktif;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxUyeAciklama;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxUyeAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxUyeYetki;
        private System.Windows.Forms.ComboBox comboBoxUyePersoneller;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButtonUyeEkle;
        private System.Windows.Forms.ToolStripButton toolStripButtonUyeGuncelle;
        private System.Windows.Forms.ToolStripButton toolStripButtonUyeSil;
    }
}