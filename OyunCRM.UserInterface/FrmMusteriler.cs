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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        MusteriManage musteri_manage = new MusteriManage();
        OrtakClassUI ort = new OrtakClassUI();
        int MusteriID;
        private void tabPageMusteriler_Enter(object sender, EventArgs e)
        {
            dataGridViewMusterilerListesi.DataSource = musteri_manage.MusteriListele();
            ort.illerListesi(comboBoxMusteriSehir);
            ort.UlkelerListesi(comboBoxMusteriUlke);
        }

        private void toolStripButtonMusteriEkle_Click(object sender, EventArgs e)
        {
            //DateTime kayitTarihi = DateTime.Now.Date;
            string insertMusteri = musteri_manage.MusteriKaydet(textBoxMusteriAdi.Text, textBoxMusterilSoyadi.Text, maskedTextBoxMusteriTelefon.Text, textBoxMusteriMail.Text, textBoxMusteriAdres.Text, textBoxMusteriFax.Text, comboBoxMusteriUlke.Text, comboBoxMusteriSehir.Text, comboBoxMusteriilce.Text, checkBoxMusteriDurum.Checked, DateTime.Now.Date);

            if (musteri_manage.islemOnayBilgisi(insertMusteri) == true)
            {
                dataGridViewMusterilerListesi.DataSource = musteri_manage.MusteriListele();
                MessageBox.Show(insertMusteri);
            }
            else
            {
                MessageBox.Show(insertMusteri);
            }
        }

        private void dataGridViewMusterilerListesi_DoubleClick(object sender, EventArgs e)
        {
            textBoxMusteriAdi.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["MusteriAdi"].Value.ToString();
            textBoxMusterilSoyadi.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["MusteriSoyadi"].Value.ToString();
            //if (dataGridViewMusterilerListesi.CurrentRow.Cells["Telefon"].Value != null)
            //{
                maskedTextBoxMusteriTelefon.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["Telefon"].Value.ToString();
            //}
            //else
            //{
            //    maskedTextBoxMusteriTelefon.Text = "";
            //}
            //if (dataGridViewMusterilerListesi.CurrentRow.Cells["email"].Value != null)
            //{
                textBoxMusteriMail.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["email"].Value.ToString();
            //}
            //else
            //{
            //    textBoxMusteriMail.Text = "";
            //}
            if (dataGridViewMusterilerListesi.CurrentRow.Cells["adres"].Value != null)
            {
                textBoxMusteriAdres.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["adres"].Value.ToString();
            }
            else
            {
                textBoxMusteriAdres.Text = "";
            }
            if (dataGridViewMusterilerListesi.CurrentRow.Cells["Ulkesi"].Value != null)
            {
                comboBoxMusteriUlke.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["Ulkesi"].Value.ToString();
            }
            else
            {
                comboBoxMusteriUlke.Text = "";
            }
            if (dataGridViewMusterilerListesi.CurrentRow.Cells["Sehir"].Value != null)
            {
                comboBoxMusteriSehir.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["Sehir"].Value.ToString();
            }
            else
            {
                comboBoxMusteriSehir.Text = "";
            }
            if (dataGridViewMusterilerListesi.CurrentRow.Cells["PostaKodu"].Value != null)
            {
                comboBoxMusteriilce.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["PostaKodu"].Value.ToString();
            }
            else
            {
                comboBoxMusteriilce.Text = "";
            }
            if (dataGridViewMusterilerListesi.CurrentRow.Cells["Fax"].Value != null)
            {
                textBoxMusteriFax.Text = dataGridViewMusterilerListesi.CurrentRow.Cells["Fax"].Value.ToString();
            }
            else
            {
                textBoxMusteriFax.Text = "";
            }

            MusteriID = (int)dataGridViewMusterilerListesi.CurrentRow.Cells["MusterilerID"].Value;
        }

        private void toolStripButtonMusteriGuncelle_Click(object sender, EventArgs e)
        {
            string updateResult = musteri_manage.MusteriGuncelle(MusteriID, textBoxMusteriAdi.Text, textBoxMusterilSoyadi.Text, maskedTextBoxMusteriTelefon.Text, textBoxMusteriMail.Text, textBoxMusteriFax.Text, textBoxMusteriAdres.Text, checkBoxMusteriDurum.Checked, comboBoxMusteriUlke.Text, comboBoxMusteriSehir.Text, comboBoxMusteriilce.Text);


            dataGridViewMusterilerListesi.DataSource = musteri_manage.MusteriListele();
            MessageBox.Show(updateResult);
        }

        private void toolStripButtonMusteriSil_Click(object sender, EventArgs e)
        {
            string deleteResult = musteri_manage.MusteriSil(MusteriID);
            dataGridViewMusterilerListesi.DataSource = musteri_manage.MusteriListele();
            MusteriID = 0;
        }
        int plakaKodu;
        private void comboBoxMusteriSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            plakaKodu = ort.ilPlakaKoduBul(comboBoxMusteriSehir.Text);
            if (plakaKodu > 0)
            {
                ort.ilcelerListesi(comboBoxMusteriilce, plakaKodu);
                plakaKodu = 0;
            }
            else
            {
                MessageBox.Show("Bir Hata Olustu");
            }


        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            musteri_manage.MusteriEkleFakeData();
            dataGridViewMusterilerListesi.DataSource = musteri_manage.MusteriListele();
        }

        #region Müşteri Ödemeleri

        private void tabPageMusteriOdemeleri_Enter(object sender, EventArgs e)
        {
            dataGridViewMusteriOdemeleriListesi.DataSource = musteri_manage.MusteriOdemeleriListesi();
            ort.MusteriAdiSoyadiListesi(comboBoxOdemeMusteriAdi);
            ort.OdemeSekliListesi(comboBoxOdemeSekli);
        }
        private void toolStripButtonMusteriOdemesiEkle_Click(object sender, EventArgs e)
        {
            decimal odenecekmiktar = 0;
            if (!string.IsNullOrWhiteSpace(textBoxOdenecekMiktar.Text))
            {
                odenecekmiktar = Convert.ToDecimal(textBoxOdenecekMiktar.Text);
            }
            string insertResult = musteri_manage.MusteriOdemesiKaydet((int)comboBoxOdemeSekli.SelectedValue, dateTimePickerOdemeTarihi.Value, odenecekmiktar, textBoxOdemeAciklama.Text, (int)comboBoxOdemeMusteriAdi.SelectedValue, textBoxBankaAdi.Text);
            dataGridViewMusteriOdemeleriListesi.DataSource = musteri_manage.MusteriOdemeleriListesi();
            MessageBox.Show(insertResult);
        }
        int musteriodemeleriid;
        private void dataGridViewMusteriOdemeleriListesi_DoubleClick(object sender, EventArgs e)
        {
            int mID, oID;
            musteriodemeleriid = (int)dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["MusteriOdemeleriID"].Value;
            mID = (int)dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["MusteriID"].Value;
            comboBoxOdemeMusteriAdi.Text = musteri_manage.MusteriAdSoyadGetir(mID);
            oID = (int)dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["OdemeSekliID"].Value;
            comboBoxOdemeSekli.Text = musteri_manage.OdemeSekliAdiGetir(oID);
            dateTimePickerOdemeTarihi.Text = dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["OdemeTarihi"].Value.ToString();
            textBoxOdenecekMiktar.Text = dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["OdenecekMiktar"].Value.ToString();
            textBoxBankaAdi.Text = dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["BankaAdi"].Value.ToString();
            textBoxOdemeAciklama.Text = dataGridViewMusteriOdemeleriListesi.CurrentRow.Cells["Aciklama"].Value.ToString();
        }
        private void toolStripButtonMusteriOdemesiGuncelle_Click(object sender, EventArgs e)
        {
            decimal odenecekmiktar = 0;
            if (!string.IsNullOrWhiteSpace(textBoxOdenecekMiktar.Text))
            {
                odenecekmiktar = Convert.ToDecimal(textBoxOdenecekMiktar.Text);
            }
            string updateResult = musteri_manage.MusteriOdemeGuncelle(musteriodemeleriid, (int)comboBoxOdemeSekli.SelectedValue, dateTimePickerOdemeTarihi.Value, odenecekmiktar, textBoxOdemeAciklama.Text, (int)comboBoxOdemeMusteriAdi.SelectedValue, textBoxBankaAdi.Text);
            dataGridViewMusteriOdemeleriListesi.DataSource = musteri_manage.MusteriOdemeleriListesi();
            MessageBox.Show(updateResult);
        }
        private void toolStripButtonMusteriOdemesiSil_Click(object sender, EventArgs e)
        {
            string deleteResult = musteri_manage.MusteriOdemeSil(musteriodemeleriid);
            dataGridViewMusteriOdemeleriListesi.DataSource = musteri_manage.MusteriOdemeleriListesi();
            MessageBox.Show(deleteResult);
        }

        #endregion


    }
}
