using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunCRM.DataBaseLogicLayer;
using OyunCRM.BusinessLogicLayer.Manage;
namespace OyunCRM.UserInterface
{
	public partial class FrmSiparisler : Form
	{
		public FrmSiparisler()
		{
			InitializeComponent();
		}
		OrtakClassUI ort = new OrtakClassUI();

		private void tabPagesiparisler_Enter(object sender, EventArgs e)
		{
			ort.musterilistesi(comboBoxMusteri);
			ort.personellistesi(comboBoxPersonel);
			ort.musterilistesi(comboBoxMusteriArama);
		}

		private void tabPageSiparisDetay_Enter(object sender, EventArgs e)
		{
			ort.Siparisno(comboBoxsiparisID);
			ort.urunlistesi(comboBoxUrun);
			ort.Siparisno(comboBoxsiparinoarama);
		}
		MusteriManage musteri_mng = new MusteriManage();
		PersonelManage personel_mng = new PersonelManage();
		OyunCRMDBEntities db = new OyunCRMDBEntities();

		private void FrmMusteriler_Load(object sender, EventArgs e)
		{
			ort.musterilistesi(comboBoxMusteri);
			ort.personellistesi(comboBoxPersonel);
			ort.musterilistesi(comboBoxMusteriArama);

			ort.Siparisno(comboBoxsiparisID);
			ort.urunlistesi(comboBoxUrun);
			ort.Siparisno(comboBoxsiparinoarama);

		}

		private void toolStripButtonsKaydet_Click_1(object sender, EventArgs e)
		{
			//int.Parse(comboBoxMusteri.ValueMember)
			string insertResult = musteri_mng.SiparisKaydet(
				(int)comboBoxMusteri.SelectedValue, (int)comboBoxPersonel.SelectedValue, dateTimePickerIsalim.Value, dateTimePickerTeslim.Value, textBoxAciklama.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSiparisler.DataSource = musteri_mng.SiparisListesi();
			MessageBox.Show(insertResult);
		}

		private void toolStripButtonsGuncelle_Click(object sender, EventArgs e)
		{
			string insertResult = musteri_mng.SiparisGuncelle(SiparisID, (int)comboBoxMusteri.SelectedValue, (int)comboBoxPersonel.SelectedValue, dateTimePickerIsalim.Value, dateTimePickerTeslim.Value, textBoxAciklama.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSiparisler.DataSource = musteri_mng.SiparisListesi();
			MessageBox.Show(insertResult);
		}
		int SiparisID;
		int SiparisDetayID;



		private void toolStripButtonSDkaydet_Click(object sender, EventArgs e)
		{
			string insertResult = musteri_mng.SiparisDetayKaydet((int)comboBoxsiparisID.SelectedValue, (int)comboBoxUrun.SelectedValue, decimal.Parse(maskedTextBoxFiyat.Text), int.Parse(textBoxmiktar.Text), decimal.Parse(maskedTextBoxindirim.Text), textBoxAciklama.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi();
			MessageBox.Show(insertResult);
		}






		private void buttonListeyukle_Click(object sender, EventArgs e)
		{
			dataGridViewSiparisler.DataSource = musteri_mng.SiparisListesi();

		}

		private void buttonSDlisteyukle_Click(object sender, EventArgs e)
		{
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi();

		}



		private void buttonAra_Click_1(object sender, EventArgs e)
		{
			dataGridViewSiparisler.DataSource = musteri_mng.SiparisListesi((int)comboBoxMusteriArama.SelectedValue);

		}

		private void buttonMusteriSDSiparis_Click(object sender, EventArgs e)
		{
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi((int)comboBoxsiparinoarama.SelectedValue);
		}

		private void toolStripButtonSDguncelle_Click(object sender, EventArgs e)
		{
			string insertResult = musteri_mng.SiparisDetayGuncelle(SiparisDetayID, (int)comboBoxsiparisID.SelectedValue, (int)comboBoxUrun.SelectedValue, decimal.Parse(maskedTextBoxFiyat.Text), int.Parse(textBoxmiktar.Text), decimal.Parse(maskedTextBoxindirim.Text), textBoxcik.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi();
			MessageBox.Show(insertResult);

		}



		private void dataGridViewSiparisler_DoubleClick(object sender, EventArgs e)
		{


			int ID, ID1;
			SiparisID = (int)dataGridViewSiparisler.CurrentRow.Cells["MusteriSiparisleriID"].Value;
			ID = (int)dataGridViewSiparisler.CurrentRow.Cells["MusteriID"].Value;
			//musteri
			comboBoxMusteri.Text = ort.Mustetilertext(ID);
			comboBoxMusteri.SelectedValue = ID;

			ID1 = (int)dataGridViewSiparisler.CurrentRow.Cells["PersonelID"].Value;
			//personel
			comboBoxPersonel.Text = ort.personeltext(ID1);
			comboBoxPersonel.SelectedValue = ID1;

			dateTimePickerIsalim.Text = dataGridViewSiparisler.CurrentRow.Cells["SiparisVerilisTarihi"].Value.ToString();
			dateTimePickerTeslim.Text = dataGridViewSiparisler.CurrentRow.Cells["SiparisTeslimTarihi"].Value.ToString();
			textBoxAciklama.Text = dataGridViewSiparisler.CurrentRow.Cells["Aciklama"].Value.ToString();

		}

		private void dataGridViewSDlistesi_DoubleClick(object sender, EventArgs e)
		{



			int ID, ID1;
			SiparisDetayID = (int)dataGridViewSDlistesi.CurrentRow.Cells["MusteriSiparisDetaylariID"].Value;
			ID = (int)dataGridViewSDlistesi.CurrentRow.Cells["MusteriSiparisID"].Value;
			//musteri
			comboBoxsiparisID.Text = ID.ToString();
			comboBoxUrun
				.SelectedValue = ID;

			ID1 = (int)dataGridViewSDlistesi.CurrentRow.Cells["UrunID"].Value;
			comboBoxUrun.Text = ort.Uruntext(ID1);
			comboBoxUrun.SelectedValue = ID1;




			maskedTextBoxFiyat.Text = dataGridViewSDlistesi.CurrentRow.Cells["Fiyat"].Value.ToString();
			maskedTextBoxindirim.Text = dataGridViewSDlistesi.CurrentRow.Cells["IndirimOrani"].Value.ToString();
			textBoxcik.Text = dataGridViewSDlistesi.CurrentRow.Cells["Aciklama"].Value.ToString();
			textBoxmiktar.Text = dataGridViewSDlistesi.CurrentRow.Cells["Miktar"].Value.ToString();


		}

		private void toolStripButtonSSil_Click(object sender, EventArgs e)
		{
			string insertResult = musteri_mng.SiparisSil(SiparisID);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi();
			MessageBox.Show(insertResult);
			SiparisID = 0;

		}

		private void toolStripButtonSDsil_Click(object sender, EventArgs e)
		{
			string insertResult = musteri_mng.SiparisDetaySil(SiparisDetayID);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
			dataGridViewSDlistesi.DataSource = musteri_mng.detaySiparisListesi();
			MessageBox.Show(insertResult);
			SiparisDetayID = 0;
		}

        private void FrmSiparisler_Load(object sender, EventArgs e)
        {
            /*
             Trigger stok düşümü için Siparisler tablosuna eklendi ama aynı ürün ID değerleri birden fazla varsa eksilmeyi hepsinde yapmaktadır,bunu tedarikçiID ile kontrol etmeliyiz
             */
        }
    }
}
