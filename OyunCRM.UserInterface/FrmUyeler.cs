using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunCRM.BusinessLogicLayer.Manage;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.UserInterface
{
    public partial class FrmUyeler : Form
    {
        public FrmUyeler()
        {
            InitializeComponent();
        }
        UyelerManage uye_manage = new UyelerManage();
        private void FrmUyeler_Load(object sender, EventArgs e)
        {
            comboBoxUyePersoneller.DataSource =uye_manage.PersonelListesi();
            comboBoxUyePersoneller.DisplayMember = "Adi";
            comboBoxUyePersoneller.ValueMember = "PersonellerID";
            comboBoxUyeYetki.DataSource = uye_manage.YetkiListesi();
            comboBoxUyeYetki.DisplayMember = "YetkiAdi";
            comboBoxUyeYetki.ValueMember = "YetkilerID";

            dataGridViewuyelistesi.DataSource = uye_manage.UyeListesi();
        }
        int uyeID;
        private void dataGridViewuyelistesi_DoubleClick(object sender, EventArgs e)
        {
            textBoxUyeAdi.Text = dataGridViewuyelistesi.CurrentRow.Cells["UyeAdi"].Value.ToString();
            textBoxSifre.Text = dataGridViewuyelistesi.CurrentRow.Cells["Sifre"].Value.ToString();
            comboBoxUyePersoneller.Text = dataGridViewuyelistesi.CurrentRow.Cells["Personel"].Value.ToString();
            comboBoxUyeYetki.Text = dataGridViewuyelistesi.CurrentRow.Cells["Yetki"].Value.ToString();
            dateTimePickerUyeKayitTarihi.Text = dataGridViewuyelistesi.CurrentRow.Cells["KayitTarihi"].Value.ToString();
            textBoxUyeAciklama.Text = dataGridViewuyelistesi.CurrentRow.Cells["Aciklama"].Value.ToString();


            uyeID = (int)dataGridViewuyelistesi.CurrentRow.Cells["UyelerID"].Value;
        }
        private void toolStripButtonUyeEkle_Click(object sender, EventArgs e)
        {
            string insertUye = uye_manage.UyeKaydet((int)comboBoxUyePersoneller.SelectedValue, (int)comboBoxUyeYetki.SelectedValue, textBoxUyeAdi.Text, textBoxSifre.Text, UyeDurumu(), dateTimePickerUyeKayitTarihi.Value, textBoxUyeAciklama.Text);

            if (uye_manage.islemOnayBilgisi(insertUye))
            {
                dataGridViewuyelistesi.DataSource = uye_manage.UyeListesi();
                MessageBox.Show(insertUye);
            }
            else
            {
                MessageBox.Show(insertUye);
            }
        }
        private void toolStripButtonUyeGuncelle_Click(object sender, EventArgs e)
        {
            string updateResult = uye_manage.UyeGuncelle(uyeID, (int)comboBoxUyePersoneller.SelectedValue, (int)comboBoxUyeYetki.SelectedValue, textBoxUyeAdi.Text, textBoxSifre.Text, UyeDurumu(), dateTimePickerUyeKayitTarihi.Value, textBoxUyeAciklama.Text);

            dataGridViewuyelistesi.DataSource = uye_manage.UyeListesi();
            MessageBox.Show(updateResult);
        }
        private void toolStripButtonUyeSil_Click(object sender, EventArgs e)
        {
            if (uyeID > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = uye_manage.UyeSil(uyeID);

                    if (uye_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewuyelistesi.DataSource = uye_manage.UyeListesi();
                        MessageBox.Show(deleteResult);
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show(deleteResult);
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemini iptal ettiniz");
                }
            }
            else
            {
                MessageBox.Show("Seçim yapmadınız");
            }
        }
        public bool UyeDurumu()
        {
            if (radioButtonUyeAktif.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Temizle()
        {
            textBoxUyeAdi.Clear();
            textBoxSifre.Clear();
            textBoxUyeAciklama.Clear();

            textBoxUyeAdi.Focus();

            uyeID = 0;
        }
    }
}
