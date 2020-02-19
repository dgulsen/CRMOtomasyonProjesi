using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunCRM.UserInterface
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        //isMDIContainer??

        FrmMusteriler frm_mus;
        private void ToolStripMenuItemMusteriislemleri_Click(object sender, EventArgs e)
        {
            if (frm_mus==null|| frm_mus.IsDisposed)
            {
                frm_mus = new FrmMusteriler();
                //FrmMusteriler frm_mus = new FrmMusteriler();//Musteriler formunu nesne olarak tanımladık
                frm_mus.MdiParent = this;//Frm_Mus formuna bu formu ana form yapıyoruz
                frm_mus.Show();//göster
            }
        }

        FrmPersoneller frm_pers;
        private void ToolStripMenuItemPersonelislemleri_Click(object sender, EventArgs e)
        {
            if (frm_pers==null || frm_pers.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_pers = new FrmPersoneller();
                frm_pers.MdiParent = this;
                frm_pers.Show();
            }

        }

        private void ToolStripMenuItemPersonelPrimleri_Click(object sender, EventArgs e)
        {

        }

        private void DepartmanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDepartmanlar frm_dep = new FrmDepartmanlar();
            frm_dep.Show();
        }
        FrmUrunler frm_Urun;
        private void üRÜNİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_Urun == null || frm_Urun.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_Urun = new FrmUrunler();
                frm_Urun.MdiParent = this;
                frm_Urun.Show();
            }
        }
		FrmSiparisler frm_siparis;
		

		private void siparislerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frm_siparis = new FrmSiparisler();
			frm_siparis.MdiParent = this;
			frm_siparis.Show();
		}
        FrmToplantilar frm_top;
        private void tOPLANTIOLUŞTURToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_top == null || frm_top.IsDisposed)
            {
                frm_top = new FrmToplantilar();
                frm_top.MdiParent = this;
                frm_top.Show();
            }
        }
        FrmBankalar frm_Banka;
        private void bANKALARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_Banka == null || frm_Banka.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_Banka = new FrmBankalar();
                frm_Banka.MdiParent = this;
                frm_Banka.Show();
            }
        }
        FrmFirmalar frm_Firma;
        private void fİRMALARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_Firma == null || frm_Firma.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_Firma = new FrmFirmalar();
                frm_Firma.MdiParent = this;
                frm_Firma.Show();
            }
        }
        FrmMusteriiletisim frm_iletisim;
        private void mÜŞTERİİLETİŞİMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_iletisim == null || frm_iletisim.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_iletisim = new FrmMusteriiletisim();
                frm_iletisim.MdiParent = this;
                frm_iletisim.Show();
            }
        }



        FrmGelirGider frm_gelgid;

        private void GelirGiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frm_gelgid == null || frm_gelgid.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_gelgid = new FrmGelirGider();
                frm_gelgid.MdiParent = this;
                frm_gelgid.Show();
            }
        }

        FrmUyeler frm_uye;
        private void uyelerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frm_uye == null || frm_uye.IsDisposed)
            {
                //IsDisposed==> kapatılan formun birdaha açılmasını sağlar, hazırda beklet anlamına gelir.
                frm_uye = new FrmUyeler();
                frm_uye.MdiParent = this;
                frm_uye.Show();
            }
        }
        public string UyeYetkisi;
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            MessageBox.Show(UyeYetkisi);
        }
        public void YetkiyeGoreMenuGizle()
        {
            if (UyeYetkisi.ToLower() == "yönetici") 
            {
                kASAToolStripMenuItem.Enabled = false;
                GelirGiderToolStripMenuItem.Visible = false;
                uyelerToolStripMenuItem.Visible = false;
            }
            if (UyeYetkisi.ToLower() == "admin")
            {
                uyelerToolStripMenuItem.Visible = false;
            }
            if (UyeYetkisi.ToLower() == "personel")
            {
                uyelerToolStripMenuItem.Visible = false;
            }
            if (UyeYetkisi.ToLower() == "muhasabe")
            {
                uyelerToolStripMenuItem.Visible = false;
                siparislerToolStripMenuItem.Visible = false;
            }
            if (UyeYetkisi.ToLower() == "full admin")
            {
            }
        }
    }
}
