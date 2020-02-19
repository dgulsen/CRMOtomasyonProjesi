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
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();

        }
        GelirGiderManage glrgdr_mng = new GelirGiderManage();


        private void toolStripButtonEkle_Click(object sender, EventArgs e)
        {
            //DateTime tarih =Convert.ToDateTime( dateTimePickerislemtarihi.Value.ToShortDateString() + dateTimePickerislemsaati.Value.ToShortTimeString());
            DateTime tarih = Convert.ToDateTime(dateTimePickerislemsaati.Value.ToShortTimeString());

            string insertResult = glrgdr_mng.GelirKaydet((int)comboBoxGelirTipi.SelectedValue, Convert.ToDecimal(textBoxGelirMiktari.Text), textBoxGelirAciklama.Text, Convert.ToDecimal(textBoxUrunSatisFiyati.Text), tarih);
            dataGridViewGelirListesi.DataSource = glrgdr_mng.GelirListesi();
            MessageBox.Show(insertResult);
        }


        private void FrmGelirGider_Load(object sender, EventArgs e)
        {

            dataGridViewGelirListesi.DataSource = glrgdr_mng.GelirListesi();
            comboBoxGelirTipi.DisplayMember = "GelirTipAdi";
            comboBoxGelirTipi.ValueMember = "GelirTipleriID";
            comboBoxGelirTipi.DataSource = glrgdr_mng.GelirTipleriListesi();

            dataGridViewGiderListesi.DataSource = glrgdr_mng.GiderListesi();
            comboBoxGiderTipi.DisplayMember = "GiderAdi";
            comboBoxGiderTipi.ValueMember = "GiderTipleriID";
            comboBoxGiderTipi.DataSource = glrgdr_mng.GiderTipleriListesi();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            // BU GİDERLERİN KAYDETME BUTTONUDUR

            DateTime tarih2 = Convert.ToDateTime(dateTimePickerGiderislemSaati.Value.ToShortTimeString());

            string insertResult = glrgdr_mng.GiderKaydet((int)comboBoxGiderTipi.SelectedValue, Convert.ToDecimal(textBoxGiderMiktar.Text), textBoxAciklama.Text, Convert.ToDecimal(textBoxUrunAlisFiyati.Text), tarih2);
            MessageBox.Show(insertResult);


        }


        private void ToolStripButtonGuncelle_Click(object sender, EventArgs e)
        {
            //GELİRLERİN GUNCELLEME BUTTONU
            DateTime tarih = Convert.ToDateTime(dateTimePickerislemsaati.Value.ToShortTimeString());

            string updateresult = glrgdr_mng.GelirGuncelle(GelirlerID, (int)comboBoxGelirTipi.SelectedValue, Convert.ToDecimal(textBoxGelirMiktari.Text), textBoxGelirAciklama.Text, Convert.ToDecimal(textBoxUrunSatisFiyati.Text), tarih);

            dataGridViewGelirListesi.DataSource = glrgdr_mng.GelirListesi();
            MessageBox.Show(updateresult);

        }
        int GelirlerID;
        private void DataGridViewGelirListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            GelirlerID = (int)dataGridViewGelirListesi.CurrentRow.Cells["GelirlerID"].Value;
            comboBoxGelirTipi.Text = dataGridViewGelirListesi.CurrentRow.Cells["GelirTipID"].Value.ToString();



            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirMiktari"].Value != null)
            {
                textBoxGelirMiktari.Text = dataGridViewGelirListesi.CurrentRow.Cells["GelirMiktari"].Value.ToString();
            }
            else
            {
                textBoxGelirMiktari.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirAciklama"].Value != null)
            {
                textBoxGelirAciklama.Text = dataGridViewGelirListesi.CurrentRow.Cells["GelirAciklama"].Value.ToString();
            }
            else
            {
                textBoxGelirAciklama.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["UrunSatisFiyati"].Value != null)
            {
                textBoxUrunSatisFiyati.Text = dataGridViewGelirListesi.CurrentRow.Cells["UrunSatisFiyati"].Value.ToString();
            }
            else
            {
                textBoxUrunSatisFiyati.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirislemSaati"].Value != null)
            {
                dateTimePickerislemsaati.Text = dataGridViewGelirListesi.CurrentRow.Cells["GelirislemSaati"].Value.ToString();
            }
            else
            {
                dateTimePickerislemsaati.Text = "";
            }




        }

        private void ToolStripButtonSil_Click(object sender, EventArgs e)
        {
            //GELİRLERİN SİL BUTTONU
            string deleteResult = glrgdr_mng.GelirSil(GelirlerID);

            dataGridViewGelirListesi.DataSource = glrgdr_mng.GelirListesi();
            GelirlerID = 0;

        }

        int GiderlerID;
        private void DataGridViewGiderListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GiderlerID = (int)dataGridViewGiderListesi.CurrentRow.Cells["GiderlerID"].Value;
            comboBoxGiderTipi.Text = dataGridViewGiderListesi.CurrentRow.Cells["GiderTipID"].Value.ToString();



            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirMiktari"].Value != null)
            {
                textBoxGiderMiktar.Text = dataGridViewGiderListesi.CurrentRow.Cells["GiderMiktar"].Value.ToString();
            }
            else
            {
                textBoxGiderMiktar.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirAciklama"].Value != null)
            {
                textBoxAciklama.Text = dataGridViewGiderListesi.CurrentRow.Cells["Aciklama"].Value.ToString();
            }
            else
            {
                textBoxAciklama.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["UrunSatisFiyati"].Value != null)
            {
                textBoxUrunAlisFiyati.Text = dataGridViewGiderListesi.CurrentRow.Cells["UrunalisFiyati"].Value.ToString();
            }
            else
            {
                textBoxUrunAlisFiyati.Text = "";
            }

            if (dataGridViewGelirListesi.CurrentRow.Cells["GelirislemSaati"].Value != null)
            {
                dateTimePickerGiderislemSaati.Text = dataGridViewGiderListesi.CurrentRow.Cells["GiderislemSaati"].Value.ToString();
            }
            else
            {
                dateTimePickerGiderislemSaati.Text = "";
            }
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            // gider silme buttonu

            string deleteResult = glrgdr_mng.GiderSil(GiderlerID);

            dataGridViewGiderListesi.DataSource = glrgdr_mng.GelirListesi();
            GiderlerID = 0;
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            // giderlerin guncele buttonu
            DateTime tarih2 = Convert.ToDateTime(dateTimePickerGiderislemSaati.Value.ToShortTimeString());

            string updateresult = glrgdr_mng.GiderGuncelle(GiderlerID, (int)comboBoxGiderTipi.SelectedValue, Convert.ToDecimal(textBoxGiderMiktar.Text), textBoxAciklama.Text, Convert.ToDecimal(textBoxUrunAlisFiyati.Text), tarih2);

            dataGridViewGiderListesi.DataSource = glrgdr_mng.GiderListesi();
            MessageBox.Show(updateresult);
        }
    }
}
