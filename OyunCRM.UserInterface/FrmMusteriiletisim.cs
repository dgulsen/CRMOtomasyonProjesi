using OyunCRM.BusinessLogicLayer.Manage;
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
    public partial class FrmMusteriiletisim : Form
    {
        Musteriiletisimmanage musteri_mng = new Musteriiletisimmanage();
        public FrmMusteriiletisim()
        {
            InitializeComponent();
        }

        private void toolStripButtoniletisimkaydet_Click_1(object sender, EventArgs e)
        {

            string insertPers = musteri_mng.iletisimKaydet(Convert.ToInt32(comboBoxMusteriler.SelectedValue), SecimCheckBox(checkBoxTelefon), SecimCheckBox(checkBoxEmail), SecimCheckBox(checkBoxFax), textBoxiletisimAciklima.Text);

            //, textBoxPersonelAdi.Text, textBoxPersonelSoyadi.Text, maskedTextBoxTelefon.Text, textBoxAdres.Text, textBoxMail.Text, "Bekar", RadiobuttonCinsiyetSecimi(radioButtonErkek, radioButtonKadin), comboBoxDogumYeri.Text, dateTimePickerDogumTarihi.Value, resimYolu);

            if (musteri_mng.islemOnayBilgisi(insertPers))
            {
                dataGridViewMusteriiletisimListesi.DataSource = musteri_mng.iletisimListesi();
                MessageBox.Show(insertPers);
            }
            else
            {
                MessageBox.Show(insertPers);
            }
        }
        private bool SecimCheckBox(CheckBox cbx)
        {

            if (cbx.Checked == true)
            {
                return true;
            }
            return false;

        }


        private void toolStripButtoniletisimguncelle_Click_1(object sender, EventArgs e)
        {



            string insertPers = musteri_mng.iletisimGuncelle(iletişimId, musteriID, SecimCheckBox(checkBoxTelefon), SecimCheckBox(checkBoxEmail), SecimCheckBox(checkBoxFax), textBoxiletisimAciklima.Text);
            //musteriId, SecimCheckBox(checkBoxTelefon), SecimCheckBox(checkBoxEmail), SecimCheckBox(checkBoxFax), textBoxiletisimAciklima.Text);

            //, textBoxPersonelAdi.Text, textBoxPersonelSoyadi.Text, maskedTextBoxTelefon.Text, textBoxAdres.Text, textBoxMail.Text, "Bekar", RadiobuttonCinsiyetSecimi(radioButtonErkek, radioButtonKadin), comboBoxDogumYeri.Text, dateTimePickerDogumTarihi.Value, resimYolu);

            if (musteri_mng.islemOnayBilgisi(insertPers))
            {
                dataGridViewMusteriiletisimListesi.DataSource = musteri_mng.iletisimListesi();
                MessageBox.Show(insertPers);
                iletişimId = 0;
                musteriID = 0;

            }
            else
            {
                MessageBox.Show(insertPers);
            }
        }

        private void toolStripButtoniletisimsil_Click_1(object sender, EventArgs e)
        {
            if (iletişimId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz?", "SİLMEONAYMESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = musteri_mng.iletisimSil(iletişimId);
                    if (musteri_mng.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewMusteriiletisimListesi.DataSource = musteri_mng.iletisimListesi();
                        MessageBox.Show(deleteResult);
                        iletişimId = 0;
                    }
                    else
                    {
                        MessageBox.Show(deleteResult);
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemini iptal ettiniz.");
                }
            }
            else
            {
                MessageBox.Show("Seçim Yapmadınız.");
            }
            //string deleteResult = musteri_mng.iletisimSil(musteri_mng.iletisimIDGetir(Convert.ToInt32(comboBoxMusteriler.SelectedValue))); /*musteri_mng.iletisimSil(musteri_mng.iletisimIDGetir((Convert.ToInt32(comboBoxMusteriler.SelectedValue))));*/
            //dataGridViewMusteriiletisimListesi.DataSource = musteri_mng.iletisimListesi();
        }
        int iletişimId;
        int musteriID;
        private void dataGridViewMusteriiletisimListesi_DoubleClick_1(object sender, EventArgs e)
        {
            string isim = musteri_mng.Musteriisimgetir((int)dataGridViewMusteriiletisimListesi.CurrentRow.Cells["MusteriID"].Value);
            comboBoxMusteriler.Text = isim;
            musteriID = (int)dataGridViewMusteriiletisimListesi.CurrentRow.Cells["MusteriID"].Value;
            textBoxiletisimAciklima.Text = dataGridViewMusteriiletisimListesi.CurrentRow.Cells["Aciklama"].Value.ToString();
            iletişimId = (int)dataGridViewMusteriiletisimListesi.CurrentRow.Cells["MusteriiletisimSekilleriID"].Value;

        }
        OrtakClassUI ort = new OrtakClassUI();

        private void FrmMusteriiletisim_Load(object sender, EventArgs e)
        {
            ort.musterilistesi(comboBoxMusteriler);
            dataGridViewMusteriiletisimListesi.DataSource = musteri_mng.iletisimListesi();
        }

    }
}
