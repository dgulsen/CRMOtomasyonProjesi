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
    public partial class FrmFirmalar : Form
    {
        FirmalarManage frm_mng = new FirmalarManage();
        public FrmFirmalar()
        {
            InitializeComponent();
        }


        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            dataGridViewFirmalarListesi.DataSource = frm_mng.FirmaListesi();
        }
        int firmalarId;
        private void dataGridViewFirmalarListesi_DoubleClick_1(object sender, EventArgs e)
        {
            textBoxFirmaAdi.Text = dataGridViewFirmalarListesi.CurrentRow.Cells["FirmaAdi"].Value.ToString();
            textBoxFirmaAciklama.Text = dataGridViewFirmalarListesi.CurrentRow.Cells["Aciklama"].Value.ToString();
            firmalarId = (int)dataGridViewFirmalarListesi.CurrentRow.Cells["FirmalarID"].Value;
        }

        private void toolStripButtoniletisimKaydet_Click(object sender, EventArgs e)
        {
            string insertPers = frm_mng.FirmaKaydet(textBoxFirmaAdi.Text, RadiobuttonDurumSecimi(radioButtonAktif, radioButtonPasif), textBoxFirmaAciklama.Text, dateTimePickerKayitTarihi.Value.Date, Convert.ToInt32(textBoxPersonelID.Text), maskedTextBoxTelefon.Text, textBoxMail.Text);

            //, textBoxPersonelAdi.Text, textBoxPersonelSoyadi.Text, maskedTextBoxTelefon.Text, textBoxAdres.Text, textBoxMail.Text, "Bekar", RadiobuttonCinsiyetSecimi(radioButtonErkek, radioButtonKadin), comboBoxDogumYeri.Text, dateTimePickerDogumTarihi.Value, resimYolu);

            if (frm_mng.islemOnayBilgisi(insertPers))
            {
                dataGridViewFirmalarListesi.DataSource = frm_mng.FirmaListesi();
                MessageBox.Show(insertPers);
            }
            else
            {
                MessageBox.Show(insertPers);
            }
        }
        private bool RadiobuttonDurumSecimi(RadioButton rdbAktif, RadioButton rdbPasif)
        {
            if (rdbAktif.Checked == true)
            {
                return true;
            }
            else if (rdbPasif.Checked == true)
            {
                return false;
            }
            return false;
        }

        private void toolStripButtoniletisimGuncelle_Click(object sender, EventArgs e)
        {
            int tiklananID = frm_mng.FirmaIDGetir(textBoxFirmaAdi.Text);
            string updateResult = frm_mng.FirmaGuncelle(tiklananID, textBoxFirmaAdi.Text, RadiobuttonDurumSecimi(radioButtonAktif, radioButtonPasif), textBoxFirmaAciklama.Text, dateTimePickerKayitTarihi.Value, Convert.ToInt32(textBoxPersonelID.Text), maskedTextBoxTelefon.Text, textBoxMail.Text);
            dataGridViewFirmalarListesi.DataSource = frm_mng.FirmaListesi();
            MessageBox.Show(updateResult);
        }

        private void toolStripButtoniletisimSil_Click(object sender, EventArgs e)
        {
            string deleteResult = frm_mng.FirmaSil(frm_mng.FirmaIDGetir(textBoxFirmaAdi.Text));
            dataGridViewFirmalarListesi.DataSource = frm_mng.FirmaListesi();

        }


    }
}
