namespace OyunCRM.UserInterface
{
    partial class FrmBankalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBankalar));
            this.groupBoxBankalarListesi = new System.Windows.Forms.GroupBox();
            this.dataGridViewBankalarListesi = new System.Windows.Forms.DataGridView();
            this.groupBoxBankaBilgisi = new System.Windows.Forms.GroupBox();
            this.textBoxBankaAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.yeniToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.açToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.kaydetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.yazdırToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.kesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.kopyalaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.yapıştırToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.yardımToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBankaKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBankaGuncelle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBankaSil = new System.Windows.Forms.ToolStripButton();
            this.groupBoxBankalarListesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankalarListesi)).BeginInit();
            this.groupBoxBankaBilgisi.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBankalarListesi
            // 
            this.groupBoxBankalarListesi.Controls.Add(this.dataGridViewBankalarListesi);
            this.groupBoxBankalarListesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxBankalarListesi.Location = new System.Drawing.Point(2, 146);
            this.groupBoxBankalarListesi.Name = "groupBoxBankalarListesi";
            this.groupBoxBankalarListesi.Size = new System.Drawing.Size(795, 292);
            this.groupBoxBankalarListesi.TabIndex = 2;
            this.groupBoxBankalarListesi.TabStop = false;
            this.groupBoxBankalarListesi.Text = "BANKALAR LİSTESİ";
            // 
            // dataGridViewBankalarListesi
            // 
            this.dataGridViewBankalarListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBankalarListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBankalarListesi.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewBankalarListesi.Name = "dataGridViewBankalarListesi";
            this.dataGridViewBankalarListesi.Size = new System.Drawing.Size(789, 273);
            this.dataGridViewBankalarListesi.TabIndex = 0;
            this.dataGridViewBankalarListesi.DoubleClick += new System.EventHandler(this.dataGridViewBankalarListesi_DoubleClick_1);
            // 
            // groupBoxBankaBilgisi
            // 
            this.groupBoxBankaBilgisi.Controls.Add(this.textBoxBankaAdi);
            this.groupBoxBankaBilgisi.Controls.Add(this.label1);
            this.groupBoxBankaBilgisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxBankaBilgisi.Location = new System.Drawing.Point(2, 28);
            this.groupBoxBankaBilgisi.Name = "groupBoxBankaBilgisi";
            this.groupBoxBankaBilgisi.Size = new System.Drawing.Size(795, 112);
            this.groupBoxBankaBilgisi.TabIndex = 3;
            this.groupBoxBankaBilgisi.TabStop = false;
            this.groupBoxBankaBilgisi.Text = "BANKA BİLGİSİ";
            // 
            // textBoxBankaAdi
            // 
            this.textBoxBankaAdi.Location = new System.Drawing.Point(85, 42);
            this.textBoxBankaAdi.Name = "textBoxBankaAdi";
            this.textBoxBankaAdi.Size = new System.Drawing.Size(221, 20);
            this.textBoxBankaAdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BANKA ADI";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniToolStripButton,
            this.açToolStripButton,
            this.kaydetToolStripButton,
            this.yazdırToolStripButton,
            this.toolStripSeparator,
            this.kesToolStripButton,
            this.kopyalaToolStripButton,
            this.yapıştırToolStripButton,
            this.toolStripSeparator1,
            this.yardımToolStripButton,
            this.toolStripButtonBankaKaydet,
            this.toolStripButtonBankaGuncelle,
            this.toolStripButtonBankaSil});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // yeniToolStripButton
            // 
            this.yeniToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.yeniToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("yeniToolStripButton.Image")));
            this.yeniToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.yeniToolStripButton.Name = "yeniToolStripButton";
            this.yeniToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.yeniToolStripButton.Text = "Y&eni";
            // 
            // açToolStripButton
            // 
            this.açToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.açToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("açToolStripButton.Image")));
            this.açToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.açToolStripButton.Name = "açToolStripButton";
            this.açToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.açToolStripButton.Text = "&Aç";
            // 
            // kaydetToolStripButton
            // 
            this.kaydetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kaydetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("kaydetToolStripButton.Image")));
            this.kaydetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kaydetToolStripButton.Name = "kaydetToolStripButton";
            this.kaydetToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.kaydetToolStripButton.Text = "&Kaydet";
            // 
            // yazdırToolStripButton
            // 
            this.yazdırToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.yazdırToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("yazdırToolStripButton.Image")));
            this.yazdırToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.yazdırToolStripButton.Name = "yazdırToolStripButton";
            this.yazdırToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.yazdırToolStripButton.Text = "Y&azdır";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // kesToolStripButton
            // 
            this.kesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kesToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("kesToolStripButton.Image")));
            this.kesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kesToolStripButton.Name = "kesToolStripButton";
            this.kesToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.kesToolStripButton.Text = "K&es";
            // 
            // kopyalaToolStripButton
            // 
            this.kopyalaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kopyalaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("kopyalaToolStripButton.Image")));
            this.kopyalaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kopyalaToolStripButton.Name = "kopyalaToolStripButton";
            this.kopyalaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.kopyalaToolStripButton.Text = "K&opyala";
            // 
            // yapıştırToolStripButton
            // 
            this.yapıştırToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.yapıştırToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("yapıştırToolStripButton.Image")));
            this.yapıştırToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.yapıştırToolStripButton.Name = "yapıştırToolStripButton";
            this.yapıştırToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.yapıştırToolStripButton.Text = "&Yapıştır";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // yardımToolStripButton
            // 
            this.yardımToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.yardımToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("yardımToolStripButton.Image")));
            this.yardımToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.yardımToolStripButton.Name = "yardımToolStripButton";
            this.yardımToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.yardımToolStripButton.Text = "&Yardım";
            // 
            // toolStripButtonBankaKaydet
            // 
            this.toolStripButtonBankaKaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBankaKaydet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBankaKaydet.Image")));
            this.toolStripButtonBankaKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBankaKaydet.Name = "toolStripButtonBankaKaydet";
            this.toolStripButtonBankaKaydet.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBankaKaydet.Text = "Banka Kaydet";
            this.toolStripButtonBankaKaydet.Click += new System.EventHandler(this.toolStripButtonBankaKaydet_Click_1);
            // 
            // toolStripButtonBankaGuncelle
            // 
            this.toolStripButtonBankaGuncelle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBankaGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBankaGuncelle.Image")));
            this.toolStripButtonBankaGuncelle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBankaGuncelle.Name = "toolStripButtonBankaGuncelle";
            this.toolStripButtonBankaGuncelle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBankaGuncelle.Text = "Banka Guncelle";
            this.toolStripButtonBankaGuncelle.Click += new System.EventHandler(this.toolStripButtonBankaGuncelle_Click);
            // 
            // toolStripButtonBankaSil
            // 
            this.toolStripButtonBankaSil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBankaSil.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBankaSil.Image")));
            this.toolStripButtonBankaSil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBankaSil.Name = "toolStripButtonBankaSil";
            this.toolStripButtonBankaSil.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBankaSil.Text = "Banka Sil";
            this.toolStripButtonBankaSil.Click += new System.EventHandler(this.toolStripButtonBankaSil_Click_1);
            // 
            // FrmBankalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxBankaBilgisi);
            this.Controls.Add(this.groupBoxBankalarListesi);
            this.Name = "FrmBankalar";
            this.Text = "FrmBankalar";
            this.Load += new System.EventHandler(this.FrmBankalar_Load);
            this.groupBoxBankalarListesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankalarListesi)).EndInit();
            this.groupBoxBankaBilgisi.ResumeLayout(false);
            this.groupBoxBankaBilgisi.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxBankalarListesi;
        private System.Windows.Forms.DataGridView dataGridViewBankalarListesi;
        private System.Windows.Forms.GroupBox groupBoxBankaBilgisi;
        private System.Windows.Forms.TextBox textBoxBankaAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton yeniToolStripButton;
        private System.Windows.Forms.ToolStripButton açToolStripButton;
        private System.Windows.Forms.ToolStripButton kaydetToolStripButton;
        private System.Windows.Forms.ToolStripButton yazdırToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton kesToolStripButton;
        private System.Windows.Forms.ToolStripButton kopyalaToolStripButton;
        private System.Windows.Forms.ToolStripButton yapıştırToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton yardımToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonBankaKaydet;
        private System.Windows.Forms.ToolStripButton toolStripButtonBankaGuncelle;
        private System.Windows.Forms.ToolStripButton toolStripButtonBankaSil;
    }
}