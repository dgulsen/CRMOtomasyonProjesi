using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunCRM.BusinessLogicLayer;
using OyunCRM.BusinessLogicLayer.Manage;
using OyunCRM.UserInterface;

namespace OyunCRM.UserInterface
{
    public partial class FrmToplantilar : Form
    {

        public FrmToplantilar()
        {
            InitializeComponent();
        }

        ToplantiManage toplanti_mng = new ToplantiManage();
        OrtakClassUI ort = new OrtakClassUI();

        private void FrmToplantilar_Load(object sender, EventArgs e)
        {

        }
        private void toolStripButtonEkle_Click_1(object sender, EventArgs e)
        {
            var insertResult = toplanti_mng.ToplantiTanimiKaydet(textBoxToplantiTanimi.Text, dateTimePickerOlusturmaTarihi.Value, textBoxAciklama.Text);
            dataGridViewToplantiTanimlar.DataSource = toplanti_mng.ToplantiTanimiListesi();
            MessageBox.Show(insertResult);
        }

        MusteriManage musteri_mng = new MusteriManage();
        PersonelManage personel_mng = new PersonelManage();

        private void toolStripButtonMEkle_Click(object sender, EventArgs e)
        {
            var personel = personel_mng.PersonelBilgisiGetirEmaille(textBoxPersonelEmail.Text);
            var musteri = musteri_mng.MusteriGetirTelNoIle(textBoxMusteriTelNo.Text);

            var EkleResult = toplanti_mng.MusteriToplantilariKaydet(dateTimePickerMusteriTarih.Value, musteri.MusterilerID, personel.PersonellerID, Convert.ToInt32(textBoxToplantiNo.Text), textBoxMusteriSaat.Text, textBoxMusteriAciklama.Text);
            MessageBox.Show(EkleResult);
            dataGridViewMusteriToplantilar.DataSource = toplanti_mng.MusteriToplantilarListesi();


        }



        int toplantiTanimlarId;
        private void ToolStripButtonGuncelle_Click_1(object sender, EventArgs e)
        {
            var updateResult = toplanti_mng.ToplantiTanimiGuncelle(toplantiTanimlarId, textBoxToplantiTanimi.Text, dateTimePickerOlusturmaTarihi.Value, textBoxAciklama.Text);
            MessageBox.Show(updateResult);
            dataGridViewToplantiTanimlar.DataSource = toplanti_mng.ToplantiTanimiListesi();
        }


        private void dataGridViewToplantiTanimlar_DoubleClick(object sender, EventArgs e)
        {
            textBoxToplantiTanimi.Text = dataGridViewToplantiTanimlar.CurrentRow.Cells["ToplantiTanimi1"].Value.ToString();
            toplantiTanimlarId = (int)dataGridViewToplantiTanimlar.CurrentRow.Cells["ToplantiTanimlarID"].Value;
        }
        int musteriToplantilariId;
        private void toolStripButtonMGuncelle_Click(object sender, EventArgs e)
        {
            var CustomerUpdateResult = toplanti_mng.MusteriToplantilariGuncelle(musteriToplantilariId, dateTimePickerMusteriTarih.Value, textBoxMusteriSaat.Text, textBoxMusteriAciklama.Text);
            MessageBox.Show(CustomerUpdateResult);
            dataGridViewToplantiTanimlar.DataSource = toplanti_mng.ToplantiTanimiListesi();

        }


        private void dataGridViewMusteriToplantilar_DoubleClick(object sender, EventArgs e)
        {
            textBoxMusteriAciklama.Text = dataGridViewMusteriToplantilar.CurrentRow.Cells["Aciklama"].Value.ToString();
            textBoxMusteriSaat.Text = dataGridViewMusteriToplantilar.CurrentRow.Cells["Saat"].Value.ToString();
            musteriToplantilariId = (int)dataGridViewMusteriToplantilar.CurrentRow.Cells["MusteriToplantilariID"].Value;
        }

        private void toolStripButtonSil_Click_1(object sender, EventArgs e)
        {
            if (toplantiTanimlarId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize eminmisiniz?", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    var deleteResult = toplanti_mng.ToplantiTanimiSil(toplantiTanimlarId);
                    dataGridViewToplantiTanimlar.DataSource = toplanti_mng.ToplantiTanimiListesi();
                }

            }
        }

        private void toolStripButtonMSil_Click(object sender, EventArgs e)
        {
            if (musteriToplantilariId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize eminmisiniz?", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    var deleteResult = toplanti_mng.MusteriToplantilariSil(musteriToplantilariId);
                    dataGridViewMusteriToplantilar.DataSource = toplanti_mng.MusteriToplantilarListesi();

                }
            }
        }

        
    }
}

