using System;
using System.Collections;
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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        UrunlerManage urun_manage = new UrunlerManage();
        private void toolStripButtonUrunKaydet_Click(object sender, EventArgs e)
        {
            int kategoriId = (int)comboBoxUrunKategorisi.SelectedValue;
            string insertResult = urun_manage.UrunKaydet(textBoxUrunAdi.Text, kategoriId, textBoxBirimMiktar.Text, Convert.ToDecimal(textBoxBirimFiyat.Text), textBoxAciklama.Text);
            dataGridViewUrunlerListesi.DataSource = urun_manage.UrunlerListesi();
            MessageBox.Show(insertResult);
        }
        int urunkategoriId;
        int urunId;
        private void dataGridViewUrunlerListesi_DoubleClick(object sender, EventArgs e)
        {
            textBoxUrunAdi.Text = dataGridViewUrunlerListesi.CurrentRow.Cells["UrunAdi"].Value.ToString();
            //*******************************************************
            //int KId = (int)dataGridViewUrunlerListesi.CurrentRow.Cells["UrunKategoriID"].Value;
            //string isim = urun_manage.KategoriAdiGetir(KId);
            string isim = urun_manage.KategoriAdiGetir((int)dataGridViewUrunlerListesi.CurrentRow.Cells["UrunKategoriID"].Value);

            comboBoxUrunKategorisi.Text = isim;
            textBoxBirimMiktar.Text = dataGridViewUrunlerListesi.CurrentRow.Cells["BirimBasinaMiktar"].Value.ToString();
            textBoxBirimFiyat.Text = dataGridViewUrunlerListesi.CurrentRow.Cells["BirimFiyati"].Value.ToString();
            textBoxAciklama.Text = dataGridViewUrunlerListesi.CurrentRow.Cells["Aciklama"].Value.ToString();
            urunId = (int)dataGridViewUrunlerListesi.CurrentRow.Cells["UrunlerID"].Value;

            //***********************************************
             indexResim = 0;
            if (urun_manage.UrunResimSayisi(urunId) > 0)
            {               
                pictureBoxUrunResimleri.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[0]).FirstOrDefault().ResimAdres;
            }
            else
            {
                pictureBoxUrunResimleri.ImageLocation = "";
            }
            //***********************************************

        }
        int indexResim = 0;
        private void SonrakiResmiGetir(int Id)
        {
             indexResim++;
            if (indexResim < urun_manage.UrunResimSayisi(Id))
            {               
                pictureBoxUrunResimleri.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(Id)[indexResim]).FirstOrDefault().ResimAdres;
            }
            else
            {
                indexResim = 0;
                pictureBoxUrunResimleri.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(Id)[indexResim]).FirstOrDefault().ResimAdres;  
            }
          
        }

        private void OncekiResmiGetir(int Id)
        {
            indexResim--;
            if (indexResim>=0 && indexResim < urun_manage.UrunResimSayisi(Id))
            {
                pictureBoxUrunResimleri.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(Id)[indexResim]).FirstOrDefault().ResimAdres;
               
            }
            else if(indexResim==-1)
            {
                //ilk resimde iken önceki resime gelirken UrunResimsayısından 1 eksiltme yapıyoruz,inde numarasında göre işlem yapıyoruz
                indexResim = urun_manage.UrunResimSayisi(Id)-1;
                pictureBoxUrunResimleri.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(Id)[indexResim]).FirstOrDefault().ResimAdres;
            }
           

        }

        private void dataGridViewUrunKategorileri_DoubleClick(object sender, EventArgs e)
        {
            textBoxKategoriAdi.Text = dataGridViewUrunKategorileri.CurrentRow.Cells["UrunKategoriAdi"].Value.ToString();
            textBoxKategoriAciklama.Text = dataGridViewUrunKategorileri.CurrentRow.Cells["Aciklama"].Value.ToString();
            urunkategoriId = (int)dataGridViewUrunKategorileri.CurrentRow.Cells["UrunKategorileriID"].Value;
        }

        private void toolStripButtonUrunGuncelle_Click(object sender, EventArgs e)
        {
            int kategoriId = (int)comboBoxUrunKategorisi.SelectedValue;
            string updateResult = urun_manage.UrunGuncelle(urunId, textBoxUrunAdi.Text, kategoriId, textBoxBirimMiktar.Text, Convert.ToDecimal(textBoxBirimFiyat.Text), textBoxAciklama.Text);
            dataGridViewUrunlerListesi.DataSource = urun_manage.UrunlerListesi();
            MessageBox.Show(updateResult);
        }

        private void toolStripButtonUrunSil_Click(object sender, EventArgs e)
        {
            if (urunId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz?", "SİLMEONAYMESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = urun_manage.UrunSil(urunId);
                    if (urun_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewUrunlerListesi.DataSource = urun_manage.UrunlerListesi();
                        MessageBox.Show(deleteResult);
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
        }
        OrtakClassUI ort = new OrtakClassUI();
        private void tabPageUrunler_Enter(object sender, EventArgs e)
        {
            ort.UrunKategoriListesi(comboBoxUrunKategorisi);
            dataGridViewUrunlerListesi.DataSource = urun_manage.UrunlerListesi();


        }

        private void tabPageUrunKategorileri_Enter(object sender, EventArgs e)
        {
            dataGridViewUrunKategorileri.DataSource = urun_manage.UrunKategoriListesi();
        }

        private void toolStripButtonUrunKategoriEkle_Click(object sender, EventArgs e)
        {
            string insertResult = urun_manage.UrunKategoriKaydet(textBoxKategoriAdi.Text, textBoxKategoriAciklama.Text);
            dataGridViewUrunKategorileri.DataSource = urun_manage.UrunKategoriListesi();
            MessageBox.Show(insertResult);
        }

        private void toolStripButtonUrunKategoriGuncelle_Click(object sender, EventArgs e)
        {
            string updateResult = urun_manage.UrunKategoriGuncelle(urunkategoriId, textBoxKategoriAdi.Text, textBoxKategoriAciklama.Text);
            dataGridViewUrunKategorileri.DataSource = urun_manage.UrunKategoriListesi();
            MessageBox.Show(updateResult);
            urunkategoriId = 0;
        }

        private void toolStripButtonUrunKategoriSil_Click(object sender, EventArgs e)
        {
            if (urunkategoriId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz?", "SİLMEONAYMESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = urun_manage.UrunKategoriSil(urunkategoriId);
                    if (urun_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewUrunKategorileri.DataSource = urun_manage.UrunKategoriListesi();
                        MessageBox.Show(deleteResult);
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
        }

        private void toolStripButtonTedarikciEkle_Click(object sender, EventArgs e)
        {
            string insertTedarikci = urun_manage.TedarikciKaydet(textBoxTedarikciSirket.Text, textBoxTedarikciKontakAd.Text, textBoxTedarikciUnvan.Text, textBoxTedarikciAdres.Text, comboBoxTedarikciUlke.Text, comboBoxTedarikciSehir.Text, textBoxTedarikciPostaKodu.Text, maskedTextBoxTedarikciTelefon.Text, maskedTextBoxTedarikciFax.Text, textBoxTedarikciEmail.Text, dateTimePickerTedarikciBaslangic.Value, TedarikciDurumu(), textBoxTedarikciAciklama.Text);

            if (urun_manage.islemOnayBilgisi(insertTedarikci))
            {
                dataGridViewTedarikciler.DataSource = urun_manage.TedarikcilerListesi();
                MessageBox.Show(insertTedarikci);
            }
            else
            {
                MessageBox.Show(insertTedarikci);
            }
        }

        public bool TedarikciDurumu()
        {
            if (radioButtonTedarikciAktif.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void toolStripButtonTedarikciSil_Click(object sender, EventArgs e)
        {
            if (tedarikcilerId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = urun_manage.TedarikciSil(tedarikcilerId);

                    if (urun_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewTedarikciler.DataSource = urun_manage.TedarikcilerListesi();
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

        private void toolStripButtonTedarikciGuncelle_Click(object sender, EventArgs e)
        {
            int tedarikciID = (int)dataGridViewTedarikciler.CurrentRow.Cells["TedarikcilerID"].Value;

            string updateResult = urun_manage.TedarikciGuncelle(tedarikciID, textBoxTedarikciSirket.Text, textBoxTedarikciKontakAd.Text, textBoxTedarikciUnvan.Text, textBoxTedarikciAdres.Text, comboBoxTedarikciUlke.Text, comboBoxTedarikciSehir.Text, textBoxTedarikciPostaKodu.Text, maskedTextBoxTedarikciTelefon.Text, maskedTextBoxTedarikciFax.Text, textBoxTedarikciEmail.Text, dateTimePickerTedarikciBaslangic.Value, TedarikciDurumu(), textBoxTedarikciAciklama.Text);

            dataGridViewTedarikciler.DataSource = urun_manage.TedarikcilerListesi();
            MessageBox.Show(updateResult);
        }

        private void Temizle()
        {
            textBoxTedarikciSirket.Clear();
            textBoxTedarikciUnvan.Clear();
            textBoxTedarikciKontakAd.Clear();
            textBoxTedarikciPostaKodu.Clear();
            textBoxTedarikciEmail.Clear();
            textBoxTedarikciAdres.Clear();
            textBoxTedarikciAciklama.Clear();
            maskedTextBoxTedarikciTelefon.Clear();
            maskedTextBoxTedarikciFax.Clear();

            textBoxTedarikciSirket.Focus();

            tedarikcilerId = 0;
        }
        int tedarikcilerId;
        private void dataGridViewTedarikciler_DoubleClick(object sender, EventArgs e)
        {
            textBoxTedarikciSirket.Text = dataGridViewTedarikciler.CurrentRow.Cells["TedarikciSirketAdi"].Value.ToString();
            textBoxTedarikciKontakAd.Text = dataGridViewTedarikciler.CurrentRow.Cells["TedarikciKontakAdi"].Value.ToString();
            textBoxTedarikciUnvan.Text = dataGridViewTedarikciler.CurrentRow.Cells["TedarikciKontakUnvani"].Value.ToString();
            textBoxTedarikciAdres.Text = dataGridViewTedarikciler.CurrentRow.Cells["Adres"].Value.ToString();
            comboBoxTedarikciUlke.Text = dataGridViewTedarikciler.CurrentRow.Cells["Ulkesi"].Value.ToString();
            comboBoxTedarikciSehir.Text = dataGridViewTedarikciler.CurrentRow.Cells["Sehir"].Value.ToString();
            textBoxTedarikciPostaKodu.Text = dataGridViewTedarikciler.CurrentRow.Cells["PostaKodu"].Value.ToString();
            maskedTextBoxTedarikciTelefon.Text = dataGridViewTedarikciler.CurrentRow.Cells["Telefon"].Value.ToString();
            dataGridViewTedarikciler.CurrentRow.Cells["Fax"].Value.ToString();
            textBoxTedarikciEmail.Text = dataGridViewTedarikciler.CurrentRow.Cells["Email"].Value.ToString();

            tedarikcilerId = (int)dataGridViewTedarikciler.CurrentRow.Cells["TedarikcilerID"].Value;
        }

        private void toolStripButtonTedarikEdilenUrunlerEkle_Click(object sender, EventArgs e)
        {
            string insertTedarikEdilenUrunler = urun_manage.TedarikEdilenUrunlerKaydet(
               (int)comboBoxTedarikEdilenUrunlerUrunleri.SelectedValue,
               dateTimePickerTedarikEdilenUrunlerTarihi.Value,
               Convert.ToDecimal(textBoxTedarikEdilenUrunlerFiyat.Text.ToString()), textBoxTedarikUrunlerAciklama.Text, ((int)comboBoxTedarikEdilenUrunlerTedarikciler.SelectedValue));

            if (urun_manage.islemOnayBilgisi(insertTedarikEdilenUrunler))
            {
                dataGridViewTedarikEdilenUrunlerListesi.DataSource = urun_manage.TedarikEdilenUrunlerListesi();
                MessageBox.Show(insertTedarikEdilenUrunler);
            }
            else
            {
                MessageBox.Show(insertTedarikEdilenUrunler);
            }
        }

        private void toolStripButtonTedarikEdilenUrunlerGuncelle_Click(object sender, EventArgs e)
        {
            int TedarikEdilenUrunlerId = (int)dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["TedarikEdilenUrunlerID"].Value;

            string updateResult = urun_manage.TedarikEdilenUrunlerGuncelle(tedarikEdilenUrunlerId,
                (int)comboBoxTedarikEdilenUrunlerUrunleri.SelectedValue,
                dateTimePickerTedarikEdilenUrunlerTarihi.Value,
                Convert.ToDecimal(textBoxTedarikEdilenUrunlerFiyat.Text.ToString()), textBoxTedarikUrunlerAciklama.Text, ((int)comboBoxTedarikEdilenUrunlerTedarikciler.SelectedValue));

            dataGridViewTedarikEdilenUrunlerListesi.DataSource = urun_manage.TedarikEdilenUrunlerListesi();
            MessageBox.Show(updateResult);
        }

        private void toolStripButtonTedarikEdilenUrunlerSil_Click(object sender, EventArgs e)
        {
            if (tedarikEdilenUrunlerId > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = urun_manage.TedarikEdilenUrunlerSil(tedarikEdilenUrunlerId);

                    if (urun_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewTedarikEdilenUrunlerListesi.DataSource = urun_manage.TedarikEdilenUrunlerListesi();
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

        private void tabPageTedarikEdilenUrunler_Enter(object sender, EventArgs e)
        {
            comboBoxTedarikEdilenUrunlerUrunleri.DataSource = urun_manage.UrunListesi();
            comboBoxTedarikEdilenUrunlerUrunleri.DisplayMember = "UrunAdi";
            comboBoxTedarikEdilenUrunlerUrunleri.ValueMember = "UrunlerID";
            comboBoxTedarikEdilenUrunlerTedarikciler.DataSource = urun_manage.TedarikcilerListesi();
            comboBoxTedarikEdilenUrunlerTedarikciler.DisplayMember = "TedarikciSirketAdi";
            comboBoxTedarikEdilenUrunlerTedarikciler.ValueMember = "TedarikcilerID";

            dataGridViewTedarikEdilenUrunlerListesi.DataSource = urun_manage.TedarikEdilenUrunlerListesi();

        }

        private void dataGridViewTedarikEdilenUrunlerListesi_DoubleClick(object sender, EventArgs e)
        {
            comboBoxTedarikEdilenUrunlerUrunleri.SelectedValue = dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["UrunID"].Value;

            dateTimePickerTedarikEdilenUrunlerTarihi.Text = dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["TedarikTarihi"].Value.ToString();

            textBoxTedarikEdilenUrunlerFiyat.Text = dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["Fiyat"].Value.ToString();

            textBoxTedarikUrunlerAciklama.Text = dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["Aciklama"].Value.ToString();

            comboBoxTedarikEdilenUrunlerTedarikciler.SelectedValue = dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["TedarikciID"].Value;


            tedarikEdilenUrunlerId = (int)dataGridViewTedarikEdilenUrunlerListesi.CurrentRow.Cells["TedarikEdilenUrunlerID"].Value;
        }
        int tedarikEdilenUrunlerId;

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            //urun_manage.UrunEkleFakeData();
        }

        private void linkLabelResim1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string adres=ResimEkle(adres,)
            //OpenFileDialog acDosya = new OpenFileDialog();
            //acDosya.ShowDialog();
            //string ResimYolu = acDosya.FileName;
            //string isim = acDosya.SafeFileName;
            //pictureBoxResim1.ImageLocation = ResimYolu;
            //urun_manage.UrunResimEkle()

            ResimEkle(pictureBoxResim1);
            //pictureBoxResim1.ImageLocation = ResimKolonlari[0].ToString();
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }
        ArrayList ResimKolonlari;
        public void ResimEkle(PictureBox pcbResim)
        {
            ResimKolonlari = new ArrayList();//ArrayList her bu metot çalıştığında sıfırlanacaktır.
            OpenFileDialog acDosya = new OpenFileDialog();
            acDosya.ShowDialog();
            pcbResim.ImageLocation = acDosya.FileName;
            ResimKolonlari.Add(acDosya.FileName);
            ResimKolonlari.Add(acDosya.SafeFileName);
        }

        private void linkLabelResim2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim2);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim3);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim4);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim5);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim6);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim7);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim8);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim9);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void linkLabelResim10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResimEkle(pictureBoxResim10);
            string pictureinsert = urun_manage.UrunResimEkle(ResimKolonlari[0].ToString(), urunId, ResimKolonlari[1].ToString(), null);
            MessageBox.Show(pictureinsert);
        }

        private void tabPageUrunResimleri_Enter(object sender, EventArgs e)
        {

            if (urunId <= 0)
            {
                foreach (Control item in tabPageUrunResimleri.Controls)
                {
                    //bu alanda picturebox,linklabel ve checkbox lar visible false yapılacak
                }
            }

            foreach (var item in tabPageUrunResimleri.Controls)
            {
                //her resim alanına girildiğinde daha önce picturebox larda yer alan fotoları silelim
                if (item is PictureBox)
                {
                    PictureBox pcb = item as PictureBox;
                    pcb.ImageLocation = "";
                }
                //bütün resimleri ikinci kez geldiğimizde siliyor ama resmiolan bir ürüne de geldiğimizde o ürünün resimleri de gelmiyor. Gelmesini sağlayalım
            }
            ArrayList resim_list = new ArrayList();
            if (urunId > 0)
            {
                //int sonID;
                for (int i = 0; i < urun_manage.UrunResimSayisi(urunId); i++)
                {
                    resim_list.Add(urun_manage.UrununResimleri(urunId).FirstOrDefault().ResimAdres);

                    //int Id = urun_manage.UrununResimleri(urunId).FirstOrDefault().ResimlerID;

                    //if (true)
                    //{
                    //    string resimyoluGetir = urun_manage.UrununResimleri(urunId).FirstOrDefault().ResimAdres;

                    //    resim_list.Add(resimyoluGetir);
                    //    sonID = Id;

                    //}

                }
            }

            #region Resimler Göster
            try
            {

                //string adres = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[0]).FirstOrDefault().ResimAdres;
                pictureBoxResim1.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[0]).FirstOrDefault().ResimAdres;

                pictureBoxResim2.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[1]).FirstOrDefault().ResimAdres;
                pictureBoxResim3.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[2]).FirstOrDefault().ResimAdres;
                pictureBoxResim4.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[3]).FirstOrDefault().ResimAdres;
                pictureBoxResim5.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[4]).FirstOrDefault().ResimAdres;
                pictureBoxResim6.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[5]).FirstOrDefault().ResimAdres;
                pictureBoxResim7.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[6]).FirstOrDefault().ResimAdres;
                pictureBoxResim8.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[7]).FirstOrDefault().ResimAdres;
                pictureBoxResim9.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[8]).FirstOrDefault().ResimAdres;
                pictureBoxResim10.ImageLocation = urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[9]).FirstOrDefault().ResimAdres;
            }
            catch (Exception)
            {
            }

            #endregion

        }
        ArrayList ResimId;
        private void checkBoxSil1_CheckedChanged(object sender, EventArgs e)
        {
            ResimId = new ArrayList();
            for (int i = 0; i < urun_manage.UrunResimSayisi(urunId); i++)
            {
                ResimId.Add(urun_manage.ResimYoluGetir(urun_manage.UrunResimlerIDGetir(urunId)[i]).FirstOrDefault().ResimAdres);
            }
            //ResimSilOlayi(checkBoxSil1, 1);

            silResim(pictureBoxResim1, checkBoxSil1);


        }

        private void silResim(PictureBox pcbResimSil, CheckBox chbSecim)
        {
            if (chbSecim.Checked == true)
            {
                string adresResim = pcbResimSil.ImageLocation.ToString();
                //MessageBox.Show(adresResim);

                DialogResult silmeOnay = MessageBox.Show("Seçilen resim silineceketir, ONAYLIYOR MUSUNUZ?", "ONAYLAMA PENCERESİ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (silmeOnay == DialogResult.OK)
                {
                    //Bu alana gelindiğinde elimizde urunID ve Resim yolu  değerleri olacaktır. Bu iki değer üzerinde silme işlemini yapacağız
                    string deleteResult = urun_manage.SecilenResmiSil(adresResim, urunId);
                    MessageBox.Show(deleteResult);
                    pcbResimSil.ImageLocation = "";
                    chbSecim.Checked = false;
                }
            }

        }

        private void ResimSilOlayi(CheckBox chbSil, int arananSayi)
        {
            //bir resim silme yöntemidir.başka bir yöntemle çözdüğümüzden dolayı bu yöntemi kendiniz yapmanız için yarıda bırakıyorum
            bool kosul = chbSil.Name.Contains(arananSayi.ToString());
            //MessageBox.Show(kosul); 
            if (kosul)
            {
                string deger = chbSil.Name.Substring(chbSil.Name.Length - 1);
                MessageBox.Show(deger);
            }
        }

        private void checkBoxSil2_CheckedChanged(object sender, EventArgs e)
        {
            //ResimSilOlayi(checkBoxSil2, 2);
            silResim(pictureBoxResim2, checkBoxSil2);

        }

        private void checkBoxSil3_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim3, checkBoxSil3);

        }

        private void checkBoxSil4_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim4, checkBoxSil4);

        }

        private void checkBoxSil5_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim5, checkBoxSil5);

        }

        private void checkBoxSil6_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim6, checkBoxSil6);

        }

        private void checkBoxSil7_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim7, checkBoxSil7);

        }

        private void checkBoxSil8_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim8, checkBoxSil8);

        }

        private void checkBoxSil9_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim9, checkBoxSil9);

        }

        private void checkBoxSil10_CheckedChanged(object sender, EventArgs e)
        {
            silResim(pictureBoxResim10, checkBoxSil10);

        }

        private void toolStripButtonUrunStokEkle_Click(object sender, EventArgs e)
        {
            string insertUrunStok = urun_manage.UrunStoklariKaydet((int)comboBoxStokUrunleri.SelectedValue, dateTimePickerUrunStokTarih.Value, Convert.ToInt32(textBoxStokMiktari.Text), Convert.ToInt32(textBoxStokMiktari.Text));

            if (urun_manage.islemOnayBilgisi(insertUrunStok))
            {

                dataGridViewUrunStoklariListesi.DataSource = urun_manage.UrunStoklariListesi();

                MessageBox.Show(insertUrunStok);
            }
            else
            {
                MessageBox.Show(insertUrunStok);
            }

        }

        private void toolStripButtonUrunStokGuncelle_Click(object sender, EventArgs e)
        {
            int UrunStoklariid = (int)dataGridViewUrunStoklariListesi.CurrentRow.Cells["UrunStoklariID"].Value;

            string updateResult = urun_manage.UrunStoklariGunceller(UrunStoklariid, (int)comboBoxStokUrunleri.SelectedValue, dateTimePickerUrunStokTarih.Value, Convert.ToInt32(textBoxStokMiktari.Text), 10);


            dataGridViewUrunStoklariListesi.DataSource = urun_manage.UrunStoklariListesi();
            MessageBox.Show(updateResult);
            //textBoxStokKalan.Clear();
            textBoxStokMiktari.Clear();
            comboBoxStokUrunleri.Focus();
        }

        private void toolStripButtonUrunStokSil_Click(object sender, EventArgs e)
        {
            if ((int)comboBoxStokUrunleri.SelectedValue > 0)
            {
                DialogResult OnaySil = MessageBox.Show("Silmek istediğinize emin misiniz??", "SİLME ONAY MESAJI", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (OnaySil == DialogResult.OK)
                {
                    string deleteResult = urun_manage.UrunStoklariSil((int)comboBoxStokUrunleri.SelectedValue);

                    if (urun_manage.islemOnayBilgisi(deleteResult))
                    {
                        dataGridViewUrunStoklariListesi.DataSource = urun_manage.UrunStoklariListesi();
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

        private void tabPageUrunStoklari_Enter(object sender, EventArgs e)
        {
            comboBoxStokUrunleri.DataSource = urun_manage.UrunListesi();
            comboBoxStokUrunleri.DisplayMember = "UrunAdi";
            comboBoxStokUrunleri.ValueMember = "UrunlerID";
            comboBoxTedarikciListesi.DataSource = urun_manage.TedarikcilerListesi();
            comboBoxTedarikciListesi.DisplayMember = "TedarikciSirketAdi";
            comboBoxTedarikciListesi.ValueMember = "TedarikcilerID";

            dataGridViewUrunStoklariListesi.DataSource = urun_manage.UrunStoklariListesi();
        }

        private void dataGridViewUrunStoklariListesi_DoubleClick(object sender, EventArgs e)
        {
            //textBoxStokKalan.Text = dataGridViewUrunStoklariListesi.CurrentRow.Cells["Kalan"].Value.ToString();
            textBoxStokMiktari.Text = dataGridViewUrunStoklariListesi.CurrentRow.Cells["StokMiktari"].Value.ToString();
            dateTimePickerUrunStokTarih.Text = dataGridViewUrunStoklariListesi.CurrentRow.Cells["Tarih"].Value.ToString();
            //   comboBoxStokUrunleri.SelectedValue 
            int urun_Id = (int)dataGridViewUrunStoklariListesi.CurrentRow.Cells["UrunID"].Value;
            //comboBoxStokUrunleri.Text = dataGridViewUrunStoklariListesi.CurrentRow.Cells["UrunAdi"].Value.ToString();
            comboBoxStokUrunleri.Text = urun_manage.UrunlerAdiGetir(urun_Id);
        }

        private void toolStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPageTedarikciler_Enter(object sender, EventArgs e)
        {
            dataGridViewTedarikciler.DataSource = urun_manage.TedarikcilerListesi();
        }

        private void buttonSonaki_Click(object sender, EventArgs e)
        {
            SonrakiResmiGetir(urunId);
        }

        private void buttonOnceki_Click(object sender, EventArgs e)
        {
            OncekiResmiGetir(urunId);
        }
    }
}
