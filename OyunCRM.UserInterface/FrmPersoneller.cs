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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        PersonelManage personel_mng = new PersonelManage();
        OrtakClassUI ort = new OrtakClassUI();
        private void toolStripButtonDepartmanKaydet_Click(object sender, EventArgs e)
        {
            string insertResult = personel_mng.DepartmanKaydet(textBoxDepartmanAdi.Text);//Manage class ında yazılan metot çağrıldı,parametre doğru girildikten sonra kullanılabilir.
            dataGridViewDepartmanListesi.DataSource = personel_mng.DepartmanListesi();
            MessageBox.Show(insertResult);
            Temizle();
        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            //dataGridViewDepartmanListesi.DataSource = personel_mng.DepartmanListesi();
            //ort.illerListesi(comboBoxDogumYeri);
            //dataGridViewPersoneller.DataSource = personel_mng.PersonelListesi();
            personel_mng.PersonelEkleFakeData();

        }

        private void toolStripButtonDepartmanGuncelle_Click(object sender, EventArgs e)
        {
            string updateResult = personel_mng.DepartmanGuncelle(departmanlarId, textBoxDepartmanAdi.Text);
            if (personel_mng.islemOnayBilgisi(updateResult))
            {
                dataGridViewDepartmanListesi.DataSource = personel_mng.DepartmanListesi();
                MessageBox.Show(updateResult);
                Temizle();
            }
            else
            {
                MessageBox.Show(updateResult);
            }
          
           


        }

        int departmanlarId;
        private void dataGridViewDepartmanListesi_DoubleClick(object sender, EventArgs e)
        {
            textBoxDepartmanAdi.Text = dataGridViewDepartmanListesi.CurrentRow.Cells["DepartmanAdi"].Value.ToString();
            departmanlarId = (int)dataGridViewDepartmanListesi.CurrentRow.Cells["DepartmanlarID"].Value;
            //MessageBox.Show(departmanlarId.ToString());


        }

        private void toolStripButtonDepartmanSil_Click(object sender, EventArgs e)
        {

            if (departmanlarId>0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = personel_mng.DepartmanSil(departmanlarId);

                    if (personel_mng.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewDepartmanListesi.DataSource = personel_mng.DepartmanListesi();
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

        private void Temizle()
        {
            textBoxDepartmanAdi.Clear();
            textBoxDepartmanAdi.Focus();
            departmanlarId = 0;
        }
        string resimYolu;
        private void linkLabelResimYukle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dosyaAl = new OpenFileDialog();//programda dosya seçiminisağlar
            dosyaAl.ShowDialog();//dosya seçimi için pencere açar
            pictureBox1.ImageLocation = dosyaAl.FileName;//açılan pencereden seçilen resmi picturebox a atmasını sağlar
           //dosyaAl.Filter = ".jpeg||.png";//sadece almak istediğiniz uzantıları almak için filter kodu kullanılır
             resimYolu = dosyaAl.FileName;   
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonPersonelKaydet_Click(object sender, EventArgs e)
        {
            string insertPers = personel_mng.PersonelKaydet(maskedTextBoxTC.Text, textBoxPersonelAdi.Text, textBoxPersonelSoyadi.Text, maskedTextBoxTelefon.Text, textBoxAdres.Text, textBoxMail.Text, "Bekar", RadiobuttonCinsiyetSecimi(radioButtonErkek, radioButtonKadin), comboBoxDogumYeri.Text, dateTimePickerDogumTarihi.Value,resimYolu);
          
            if (personel_mng.islemOnayBilgisi(insertPers))
            {
                dataGridViewPersoneller.DataSource = personel_mng.PersonelListesi();
                MessageBox.Show(insertPers);
            }
            else
            {
                MessageBox.Show(insertPers);
            }

        }

        private string RadiobuttonCinsiyetSecimi(RadioButton rdbErkek,RadioButton rdbKadin)
        {
            if (rdbErkek.Checked==true)
            {
                return "ERKEK";
            }
            else if (rdbKadin.Checked==true)
            {
                return "KADIN";
            }
            return null;

        }

        private string RadiobuttonMHaliSecimi(RadioButton rdbBekar, RadioButton rdbEvli)
        {
            if (rdbBekar.Checked == true)
            {
                return "Bekar";
            }
            else if (rdbEvli.Checked == true)
            {
                return "Evli";
            }
            return null;

        }

        private void checkBoxAyrintiliListe_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAyrintiliListe.Checked==true)
            {
                dataGridViewPersoneller.DataSource = personel_mng.sp_PersonelListesi();
            }
            else
            {
                dataGridViewPersoneller.DataSource = personel_mng.PersonelListesi();
            }
        }

        private void checkBoxNormalListe_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewPersoneller.DataSource = personel_mng.PersonelListesi();
        }

        private void tabPagePersoneller_Enter(object sender, EventArgs e)
        {
            comboBoxDepartman.DisplayMember = "DepartmanAdi";
            comboBoxDepartman.DataSource = personel_mng.DepartmanListesi();
            ort.illerListesi(comboBoxDogumYeri);
            dataGridViewPersoneller.DataSource = personel_mng.PersonelListesi();
        }

            private void tabPagePersonelizinleri_Enter(object sender, EventArgs e)
        {

        }

        private void tabPageDepartmanlar_Enter(object sender, EventArgs e)
        {
            dataGridViewDepartmanListesi.DataSource = personel_mng.DepartmanListesi();
        }

        private void dataGridViewPersoneller_DoubleClick(object sender, EventArgs e)
        {
            #region Güncelleme için alan seçimi
            maskedTextBoxTC.Text = dataGridViewPersoneller.CurrentRow.Cells["TC"].Value.ToString();
            textBoxPersonelAdi.Text = dataGridViewPersoneller.CurrentRow.Cells["Adi"].Value.ToString();
            textBoxPersonelSoyadi.Text = dataGridViewPersoneller.CurrentRow.Cells["Soyadi"].Value.ToString();
            maskedTextBoxTelefon.Text = dataGridViewPersoneller.CurrentRow.Cells["Telefon"].Value.ToString();
            textBoxAdres.Text = dataGridViewPersoneller.CurrentRow.Cells["adres"].Value.ToString();
            textBoxMail.Text = dataGridViewPersoneller.CurrentRow.Cells["email"].Value.ToString();
            dateTimePickerDogumTarihi.Text = dataGridViewPersoneller.CurrentRow.Cells["DogumTarihi"].Value.ToString();
            comboBoxDogumYeri.Text = dataGridViewPersoneller.CurrentRow.Cells["DogumYeri"].Value.ToString();
            textBoxTakipID.Text = dataGridViewPersoneller.CurrentRow.Cells["PersonellerID"].Value.ToString();
            maskedTextBoxTakipTC.Text = dataGridViewPersoneller.CurrentRow.Cells["TC"].Value.ToString();
            textBoxTakipAdi.Text = dataGridViewPersoneller.CurrentRow.Cells["Adi"].Value.ToString();
            textBoxTakipSoyadi.Text = dataGridViewPersoneller.CurrentRow.Cells["Soyadi"].Value.ToString();
            #endregion
            //*************************************
            #region Cinsiyet Seçimi
            string tiklananCinsiyet = dataGridViewPersoneller.CurrentRow.Cells["Cinsiyet"].Value.ToString().ToLower();
            if (tiklananCinsiyet == "erkek")
            {
                radioButtonErkek.Checked = true;
            }
            else if (tiklananCinsiyet == "kadın")
            {
                radioButtonKadin.Checked = true;
            }
            //**********************************************
            #endregion
            //********************
            #region Medeni hali seçimi
            string tiklananMHali = dataGridViewPersoneller.CurrentRow.Cells["MedeniHali"].Value.ToString().ToLower();
            if (tiklananMHali == "bekar")
            {
                radioButtonBekar.Checked = true;
            }
            else if (tiklananCinsiyet == "evli")
            {
                radioButtonEvli.Checked = true;
            }
            #endregion


        }

        private void toolStripButtonPersonelGuncelle_Click(object sender, EventArgs e)
        {
            int tiklananID = personel_mng.PersonelIDGetir(maskedTextBoxTC.Text);
            string updateResult = personel_mng.PersonelGuncelle(tiklananID, maskedTextBoxTC.Text, textBoxPersonelAdi.Text, textBoxPersonelSoyadi.Text, maskedTextBoxTelefon.Text, textBoxAdres.Text, textBoxMail.Text, RadiobuttonMHaliSecimi(radioButtonBekar, radioButtonEvli), RadiobuttonCinsiyetSecimi(radioButtonErkek, radioButtonKadin), comboBoxDogumYeri.Text, dateTimePickerDogumTarihi.Value, resimYolu);
            dataGridViewPersoneller.DataSource = personel_mng.sp_PersonelListesi();
            MessageBox.Show(updateResult);

        }

        private void toolStripButtonTakipEkle_Click(object sender, EventArgs e)
        {
           
        }
        public int personelGunlukTakipID { get; set; }

        private void toolStripButtonTakipGuncelle_Click(object sender, EventArgs e)
        {
            var UpdateResult = personel_mng.GunlukTakipGuncelle(personelGunlukTakipID, dateTimePickerGiris.Value, dateTimePickerCikis.Value, textBoxTakipAciklama.Text);
            dataGridViewGunlukTakip.DataSource = personel_mng.PersonelGunlukTakips();
            MessageBox.Show(UpdateResult);

        }
        int PersonID;
        int PersonelGunlukTakipID;
        private void toolStripButtonTakipSil_Click(object sender, EventArgs e)
        {
            if (personelGunlukTakipID > 0)
            {
                DialogResult TakipSil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (TakipSil == DialogResult.OK)
                {
                    string deleteResult = personel_mng.GunlukTakipSil(personelGunlukTakipID);

                    if (personel_mng.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewGunlukTakip.DataSource = personel_mng.PersonelGunlukTakips();
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
        private void dataGridViewGunlukTakip_DoubleClick(object sender, EventArgs e)
        {
            PersonelGunlukTakipID = (int)dataGridViewGunlukTakip.CurrentRow.Cells["PeronselGunTakipleriID"].Value;
            textBoxTakipID.Text = dataGridViewGunlukTakip.CurrentRow.Cells["PersonelID"].Value.ToString();
            dateTimePickerGiris.Value = Convert.ToDateTime(dataGridViewGunlukTakip.CurrentRow.Cells["Giris"].Value.ToString());
            dateTimePickerCikis.Value = Convert.ToDateTime(dataGridViewGunlukTakip.CurrentRow.Cells["Cikis"].Value.ToString());
            textBoxTakipAciklama.Text = dataGridViewGunlukTakip.CurrentRow.Cells["Aciklama"].Value.ToString();
            PersonID = (int)dataGridViewGunlukTakip.CurrentRow.Cells["PersonelID"].Value;

        }
        private void tabPageGunlukTakip_Enter(object sender, EventArgs e)
        {
            dataGridViewGunlukTakip.DataSource = personel_mng.PersonelGunlukTakips();
        }

        private void toolStripButtonTakipEkle_Click_1(object sender, EventArgs e)
        {
            var insertTakip = personel_mng.gunlukTakipEkle(Convert.ToInt32(textBoxTakipID.Text), dateTimePickerGiris.Value, (dateTimePickerCikis.Value), textBoxTakipAciklama.Text);

            if (personel_mng.islemOnayBilgisi(insertTakip))
            {
                dataGridViewGunlukTakip.DataSource = personel_mng.PersonelGunlukTakips();
                MessageBox.Show(insertTakip);
            }
            else
            {
                MessageBox.Show(insertTakip);
            }
        }
    }
}
