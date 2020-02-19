using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFramework.Services.FakeData;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class UrunlerManage : IUrunler, ITedarikEdilenUrunler, ITeradikciler
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();


        #region Ürünler
        public void UrunEkleFakeData()
        {
            var sayi_Urun = db.Urunler.Count();
            if (sayi_Urun < 140)
            {
                for (int i = 0; i < 20; i++)
                {
                    UrunKategorileri eklekat = new UrunKategorileri();
                    eklekat.UrunKategoriAdi = TextData.GetSentence();
                    eklekat.Aciklama = TextData.GetSentences(1);
                    db.UrunKategorileri.Add(eklekat);
                    db.SaveChanges();
                }

                for (int i = 0; i < 140; i++)
                {
                    string[] birim_tanimi = { "Kg", "Litre", "Adet", "Metre", "Deste" };
                    Urunler ekle = new Urunler();
                    Random rnd = new Random();
                    ekle.UrunAdi = MFramework.Services.FakeData.TextData.GetAlphabetical(10);
                    ekle.UrunKategoriID = rnd.Next(1, 20);
                    ekle.BirimBasinaMiktar = birim_tanimi[rnd.Next(0, 4)];
                    ekle.BirimFiyati = (decimal)rnd.NextDouble();
                    ekle.Aciklama = TextData.GetSentence();
                    db.Urunler.Add(ekle);
                    db.SaveChanges();
                }
            }

        }

        public List<Urunler> UrunListesi()
        {
            return db.Urunler.ToList();
        }
        public string UrunGuncelle(int urunlerId, string adi, int urunKategoriId, string birimMiktar, decimal birimFiyat, string aciklama)
        {
            Urunler guncelle = new Urunler();
            try
            {
                var GuncelleUrun = db.Urunler.Where(k => k.UrunlerID == urunlerId).FirstOrDefault();
                if (GuncelleUrun != null)
                {
                    if (!string.IsNullOrWhiteSpace(adi) && !string.IsNullOrWhiteSpace(birimMiktar))
                    {
                        GuncelleUrun.UrunAdi = adi;
                        GuncelleUrun.UrunKategoriID = urunKategoriId;
                        GuncelleUrun.BirimBasinaMiktar = birimMiktar;
                        GuncelleUrun.BirimFiyati = birimFiyat;
                        GuncelleUrun.Aciklama = aciklama;
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " Urun Güncellemesi Başarılı.";
                        }
                        return "Güncellenirken Hata Oluştu. Bilgileri kontrol ediniz.";
                    }
                    return "Boş alanları doldurunuz.";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception es)
            {

                return es.Message;
            }
        }

        public string UrunKaydet(string adi, int kategoriId, string birimMiktar, decimal birimFiyat, string aciklama)
        {
            Urunler ekle = new Urunler();
            ekle.UrunAdi = adi;
            ekle.UrunKategoriID = kategoriId;
            ekle.BirimBasinaMiktar = birimMiktar;
            ekle.BirimFiyati = birimFiyat;
            ekle.Aciklama = aciklama;

            try
            {
                var varmiUrunAdi = db.Urunler.Where(k => k.UrunAdi == adi).FirstOrDefault();
                if (varmiUrunAdi == null)
                {
                    if (!string.IsNullOrWhiteSpace(adi) && !string.IsNullOrWhiteSpace(birimMiktar))
                    {
                        db.Urunler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "Urun ekleme başarılı.";
                        }
                        return "Bir hata oluştu.";
                    }
                    return "Boş alanları doldurunuz.";
                }
                return "Aynı isimde bir ürün bulunmaktadır tekrar kontrol ediniz.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UrunSil(int urunId)
        {
            try
            {
                if (urunId > 0)
                {
                    Urunler Sil = db.Urunler.Where(k => k.UrunlerID == urunId).FirstOrDefault();
                    db.Urunler.Remove(Sil);
                    if (db.SaveChanges() > 0)
                    {
                        urunId = 0;
                        return Sil.UrunAdi + "Silme işlemi başarılı";
                    }
                    return "Silme işlemi sırasında bir hata oluştu!";
                }
                return "Seçim Yapmadınız.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        #endregion

        #region ürün kategori kaydet güncel sil

        public string UrunKategoriKaydet(string adi, string aciklama)
        {
            UrunKategorileri ekle = new UrunKategorileri();
            ekle.UrunKategoriAdi = adi;
            ekle.Aciklama = aciklama;
            try
            {
                var varmiUrunKategoriAdi = db.UrunKategorileri.Where(k => k.UrunKategoriAdi == adi).FirstOrDefault();
                if (varmiUrunKategoriAdi == null)
                {
                    if (!string.IsNullOrWhiteSpace(adi))
                    {
                        db.UrunKategorileri.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "Urun Kategori ekleme başarılı";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Boş bırakılan alanları doldurunuz.";
                }
                return "Aynı isme sahip bir ürün kategorisi kayıtlı.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<UrunKategorileri> UrunKategoriListesi()
        {
            return db.UrunKategorileri.ToList();
        }

        public List<Urunler> UrunlerListesi()
        {
            return db.Urunler.ToList();
        }
        public string UrunKategoriGuncelle(int Id, string adi, string aciklama)
        {
            try
            {
                var GuncelleKate = db.UrunKategorileri.Where(k => k.UrunKategorileriID == Id).FirstOrDefault();
                if (GuncelleKate != null)
                {
                    if (!string.IsNullOrWhiteSpace(adi))
                    {
                        GuncelleKate.UrunKategoriAdi = adi;
                        GuncelleKate.Aciklama = aciklama;
                        if (db.SaveChanges() > 0)
                        {
                            return "Kategori Guncelleme Başarılı";
                        }
                        return "Hata oluştu.";
                    }
                    return "Boş alanları doldurunuz.";
                }
                return "Seçim Yapmadınız.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string KategoriAdiGetir(int kategoriId)
        {
            return db.UrunKategorileri.FirstOrDefault(k => k.UrunKategorileriID == kategoriId).UrunKategoriAdi;
        }

        public bool islemOnayBilgisi(string kelime)
        {
            // her silme, güncelleme metodu çalıştırıldığında işlem başarılı veya başarısız olması farketmeksizin bütün olayları yeniden yaptırmamak için bu metod kullanılmakta. Sadece başarılı olduğunda bu işlem yapılmakta
            kelime = kelime.ToLower();
            bool sonuc = kelime.Contains("başarılı");

            return sonuc;
        }
        public string UrunKategoriSil(int urunKategoriId)
        {
            try
            {
                if (urunKategoriId > 0)
                {
                    UrunKategorileri Sil = db.UrunKategorileri.Where(k => k.UrunKategorileriID == urunKategoriId).FirstOrDefault();
                    db.UrunKategorileri.Remove(Sil);
                    if (db.SaveChanges() > 0)
                    {
                        urunKategoriId = 0;
                        return Sil.UrunKategoriAdi + "Silme işlemi başarılı";
                    }
                    return "Silme işlemi sırasında bir hata oluştu!";
                }
                return "Seçim Yapmadınız.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        #endregion

        #region Tedarikçiler ve tedarik edilen ürünler

        public List<Tedarikciler> TedarikcilerListesi()
        {
            return db.Tedarikciler.ToList();
        } // yapıldı



        public string TedarikciGuncelle(int tedarikcilerId, string sirketadi, string kontakadi, string unvan, string adres, string ulke, string sehir, string postakodu, string telefon, string fax, string email, DateTime baslangic, bool durum, string aciklama)
        {
            try
            {
                var guncelle = db.Tedarikciler.Where(k => k.TedarikcilerID == tedarikcilerId).FirstOrDefault();

                if (guncelle != null)
                {
                    if (!string.IsNullOrWhiteSpace(sirketadi))
                    {

                        guncelle.TedarikciSirketAdi = sirketadi;
                        guncelle.TedarikciKontakAdi = kontakadi;
                        guncelle.TedarikciKontakUnvani = unvan;
                        guncelle.Adres = adres;
                        guncelle.Ulkesi = ulke;
                        guncelle.Sehir = sehir;
                        guncelle.PostaKodu = postakodu;
                        guncelle.Telefon = telefon;
                        guncelle.Fax = fax;
                        guncelle.Email = email;
                        guncelle.TedarikciOlmaTarihi = baslangic;
                        guncelle.Durumu = durum;
                        guncelle.Aciklama = aciklama;

                        if (db.SaveChanges() > 0)
                        {
                            return sirketadi + " Şirketi başarılı bir şekilde güncellendi";
                        }
                        return "Güncellerken hata oluştu";
                    }
                    return "Boş alanları doldurun";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // yapıldı

        public string TedarikciKaydet(string sirketadi, string kontakadi, string unvan, string adres, string ulke, string sehir, string postakodu, string telefon, string fax, string email, DateTime baslangic, bool durum, string aciklama)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(sirketadi) && !string.IsNullOrWhiteSpace(baslangic.ToString()))
                {
                    var varmiTedarikci = db.Tedarikciler.FirstOrDefault(k => k.TedarikciSirketAdi == sirketadi);
                    if (varmiTedarikci == null)
                    {
                        Tedarikciler ekle = new Tedarikciler();
                        ekle.TedarikciSirketAdi = sirketadi;
                        ekle.TedarikciKontakAdi = kontakadi;
                        ekle.TedarikciKontakUnvani = unvan;
                        ekle.Adres = adres;
                        ekle.Ulkesi = ulke;
                        ekle.Sehir = sehir;
                        ekle.PostaKodu = postakodu;
                        ekle.Telefon = telefon;
                        ekle.Fax = fax;
                        ekle.Email = email;
                        ekle.TedarikciOlmaTarihi = baslangic;
                        ekle.Durumu = durum;
                        ekle.Aciklama = aciklama;

                        db.Tedarikciler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return sirketadi + " şirketi başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Kayıtlı tedarikçi";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // yapıldı



        public string TedarikciSil(int tedarikcilerId)
        {
            try
            {
                if (tedarikcilerId > 0)
                {
                    Tedarikciler sil = db.Tedarikciler.Where(k => k.TedarikcilerID == tedarikcilerId).FirstOrDefault();
                    db.Tedarikciler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        tedarikcilerId = 0;
                        return sil.TedarikciSirketAdi + " başarılı bir şekilde silindi";
                    }
                    return "Silme başarısız oldu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception es)
            {
                return es.Message;
            }
        } // yapıldı

        public string TedarikEdilenUrunlerGuncelle(int tedarikedilenurunlerId, int urunID, DateTime tedariktarihi, decimal fiyat, string aciklama, int tedarikciID)
        {
            try
            {
                var guncelle = db.TedarikEdilenUrunler.Where(k => k.TedarikEdilenUrunlerID == tedarikedilenurunlerId).FirstOrDefault();

                if (guncelle != null)
                {
                    guncelle.TedarikTarihi = tedariktarihi;
                    guncelle.Fiyat = fiyat;
                    guncelle.Aciklama = aciklama;
                    guncelle.TedarikciID = tedarikciID;
                    guncelle.UrunID = urunID;


                    if (db.SaveChanges() > 0)
                    {
                        return "Başarılı bir şekilde güncellendi";
                    }
                    return "Güncellerken hata oluştu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string TedarikEdilenUrunlerKaydet(int urunID, DateTime tedariktarihi, decimal fiyat, string aciklama, int tedarikciID)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fiyat.ToString()) && !string.IsNullOrWhiteSpace(tedariktarihi.ToString()) && !string.IsNullOrWhiteSpace(aciklama))
                {
                    var varmiTedarikEdilenUrunler = db.TedarikEdilenUrunler.FirstOrDefault(k => k.TedarikTarihi == tedariktarihi);
                    if (varmiTedarikEdilenUrunler == null)
                    {
                        TedarikEdilenUrunler ekle = new TedarikEdilenUrunler();
                        ekle.TedarikTarihi = tedariktarihi;
                        ekle.Fiyat = fiyat;
                        ekle.Aciklama = aciklama;
                        ekle.TedarikciID = tedarikciID;
                        ekle.UrunID = urunID;

                        db.TedarikEdilenUrunler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "Başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Kayıtlı";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string TedarikEdilenUrunlerSil(int tedarikedilenurunlerId)
        {
            try
            {
                if (tedarikedilenurunlerId > 0)
                {
                    TedarikEdilenUrunler sil = db.TedarikEdilenUrunler.Where(k => k.TedarikEdilenUrunlerID == tedarikedilenurunlerId).FirstOrDefault();
                    db.TedarikEdilenUrunler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        tedarikedilenurunlerId = 0;
                        return "Başarılı bir şekilde silindi";
                    }
                    return "Silme başarısız oldu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception es)
            {
                return es.Message;
            }
        }

        public List<TedarikEdilenUrunler> TedarikEdilenUrunlerListesi()
        {
            return db.TedarikEdilenUrunler.ToList();
        }




        #endregion


        #region Ürün Resimleri
        public string UrunResimEkle(string resimadres, int urunId, string resimAdi, string aciklama)
        {

            Resimler ekle = new Resimler();
            ekle.ResimAdres = resimadres;
            ekle.UrunID = urunId;
            ekle.ResimAdi = resimAdi;
            ekle.Aciklama = aciklama;
            db.Resimler.Add(ekle);
            if (db.SaveChanges() > 0)
            {
                return resimAdi + " başarılı bir şekilde eklendi";
            }
            return "Eklenmedi";

        }


        public List<Resimler> UrununResimleri(int urunId)
        {
            return db.Resimler.Where(k => k.UrunID == urunId).ToList();
        }

        public int UrunResimSayisi(int urunId)
        {
            return db.Resimler.Where(k => k.UrunID == urunId).Count();
        }

        public int[] UrunResimlerIDGetir(int urun_ID)
        {
            int[] resimID = new int[UrunResimSayisi(urun_ID)];
            resimID[0] = db.Resimler.Where(k => k.UrunID == urun_ID).FirstOrDefault().ResimlerID;
            // resimID[0]=26;
            for (int i = 0; i < resimID.Length - 1; i++)
            {
                int x = resimID[i];
                //x=26;//x=27                
                resimID[i + 1] = db.Resimler.Where(k => k.UrunID == urun_ID && k.ResimlerID > x).FirstOrDefault().ResimlerID;
                // resimID[i+1]=(k => k.UrunID==urun_ID && k.ResimlerID>26).ResimlerID
                // resimID[1]=27;  // resimID[2]=28              
            }
            return resimID;
        }

        public List<Resimler> ResimYoluGetir(int urunResimID)
        {
            return db.Resimler.Where(k => k.ResimlerID == urunResimID).ToList();
        }


        public string SecilenResmiSil(string adres, int urunId)
        {
            try
            {
                var silinecekID = db.Resimler.FirstOrDefault(k => k.UrunID == urunId && k.ResimAdres == adres).ResimlerID;
                if (silinecekID > 0)
                {
                    //sadece tek resmisilmek için ID ile koşullandırıyoruz.silinecekID ile silinebilir am bir ürünün aynı resimde birden fazla tutuluyorsa o resimlerin hepsini silecektir.
                    var sil = db.Resimler.FirstOrDefault(k => k.ResimlerID == silinecekID);
                    db.Resimler.Remove(sil);
                    if (db.SaveChanges() > 0)
                    {
                        return "Resim silindi";
                    }
                    return "Silerken hata oluştu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception ax )
            {
                return "Silme esnasında hata oluştu:"+ax.Message;
            }

        }


        #endregion

        #region Ürün Stokları


        public string  UrunlerAdiGetir(int urun_Id)
        {
            return db.Urunler.FirstOrDefault(k => k.UrunlerID == urun_Id).UrunAdi;
        }
        public string UrunStoklariKaydet(int urunid, DateTime tarih, int stokmiktari, int kalan)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tarih.ToString()) && !string.IsNullOrWhiteSpace(stokmiktari.ToString()) && !string.IsNullOrWhiteSpace(kalan.ToString()))
                {
                    var varmiUrunStok = db.UrunStoklari.FirstOrDefault(k => k.Tarih == tarih);
                    if (varmiUrunStok == null)
                    {
                        UrunStoklari ekle = new UrunStoklari();
                        ekle.Tarih = tarih;
                        ekle.StokMiktari = stokmiktari;
                        ekle.Kalan = stokmiktari;
                        ekle.UrunID = urunid;

                        db.UrunStoklari.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "Başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Kayıtlı";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UrunStoklariGunceller(int urunstoklariid, int urunid, DateTime tarih, int stokmiktari, int kalan)
        {
            try
            {
                var guncelle = db.UrunStoklari.Where(k => k.UrunStoklariID == urunstoklariid).FirstOrDefault();

                if (guncelle != null)
                {
                    guncelle.Tarih = tarih;
                    guncelle.StokMiktari = stokmiktari;
                    guncelle.Kalan = kalan;
                    guncelle.UrunID = urunid;


                    if (db.SaveChanges() > 0)
                    {
                        return "Başarılı bir şekilde güncellendi";
                    }
                    return "Güncellerken hata oluştu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UrunStoklariSil(int urunstoklariid)
        {
            try
            {
                if (urunstoklariid > 0)
                {
                    UrunStoklari sil = db.UrunStoklari.Where(k => k.UrunStoklariID == urunstoklariid).FirstOrDefault();
                    db.UrunStoklari.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        urunstoklariid = 0;
                        return "Başarılı bir şekilde silindi";
                    }
                    return "Silme başarısız oldu";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception es)
            {
                return es.Message;
            }
        }

        public List<UrunStoklari> UrunStoklariListesi()
        {
            return db.UrunStoklari.ToList();
        }
        #endregion
    }
}
