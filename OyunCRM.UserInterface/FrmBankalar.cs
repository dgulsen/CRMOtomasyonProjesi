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
    public partial class FrmBankalar : Form
    {
        Bankalarmanage banka_mng = new Bankalarmanage();
        public FrmBankalar()
        {
            InitializeComponent();
        }

        private void toolStripButtonBankaKaydet_Click_1(object sender, EventArgs e)
        {
            string insertResult = banka_mng.BankaKaydet(textBoxBankaAdi.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
            dataGridViewBankalarListesi.DataSource = banka_mng.BankaListesi();
            MessageBox.Show(insertResult);
            Temizle();
        }
        int bankalarId;
        private void Temizle()
        {
            textBoxBankaAdi.Clear();
            textBoxBankaAdi.Focus();
            bankalarId = 0;
        }
        private void toolStripButtonBankaSil_Click_1(object sender, EventArgs e)
        {
            if (bankalarId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = banka_mng.BankaSil(bankalarId);

                    if (banka_mng.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewBankalarListesi.DataSource = banka_mng.BankaListesi();
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

        private void dataGridViewBankalarListesi_DoubleClick_1(object sender, EventArgs e)
        {
            textBoxBankaAdi.Text = dataGridViewBankalarListesi.CurrentRow.Cells["BankaAdi"].Value.ToString();
            bankalarId = (int)dataGridViewBankalarListesi.CurrentRow.Cells["BankalarID"].Value;
            //MessageBox.Show(departmanlarId.ToString());
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            dataGridViewBankalarListesi.DataSource = banka_mng.BankaListesi();
        }

        private void toolStripButtonBankaGuncelle_Click(object sender, EventArgs e)
        {
            string updateResult = banka_mng.BankaGuncelle(bankalarId, textBoxBankaAdi.Text);
            if (banka_mng.islemOnayBilgisi(updateResult))
            {
                dataGridViewBankalarListesi.DataSource = banka_mng.BankaListesi();
                MessageBox.Show(updateResult);
                Temizle();
            }
            else
            {
                MessageBox.Show(updateResult);
            }


        }

    }
}
