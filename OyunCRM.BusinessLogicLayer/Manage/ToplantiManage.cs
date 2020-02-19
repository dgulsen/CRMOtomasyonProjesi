using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.Manage
{
      
    public class ToplantiManage:IToplantilar
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        #region TOPLANTI TANIMLARI
        public string ToplantiTanimiGuncelle(int toplantiTanimlarId, string toplantiTanimi, DateTime olusturmaTarihi, string acikla)
        {
            if (!string.IsNullOrWhiteSpace(toplantiTanimi) && !string.IsNullOrWhiteSpace(olusturmaTarihi.ToString()))
            {
                var guncelle = db.ToplantiTanimi.Where(i => i.ToplantiTanimlarID == toplantiTanimlarId).FirstOrDefault();
                if (guncelle != null)
                {

                    guncelle.ToplantiTanimi1 = toplantiTanimi;
                    guncelle.Aciklama = acikla;
                    guncelle.OlusturmaTarihi = olusturmaTarihi;
                    if (db.SaveChanges() > 0)
                    {
                        return "Başarılı bir şekilde güncelleme gerçekleşti.";
                    }
                    return "Güncelleme yapılırken hata meydana geldi";
                }
                return "Seçim yapmadınız.";
            }
            return "Boş alanları doldurunuz.";

            throw new NotImplementedException();
        }

        public string ToplantiTanimiKaydet(string toplantiTanimi, DateTime olusturmaTarihi, string aciklama)
        {
            var topVarmi = db.ToplantiTanimi.Where(i => i.ToplantiTanimi1 == toplantiTanimi).FirstOrDefault();
            if (topVarmi == null)
            {
                if (!string.IsNullOrWhiteSpace(toplantiTanimi))
                {
                    ToplantiTanimi eklenecekNesne = new ToplantiTanimi();
                    eklenecekNesne.ToplantiTanimi1 = toplantiTanimi;
                    eklenecekNesne.OlusturmaTarihi = olusturmaTarihi;
                    eklenecekNesne.Aciklama = aciklama;
                    db.ToplantiTanimi.Add(eklenecekNesne);
                    if (db.SaveChanges() > 0)
                    {
                        return "Başarılı şekilde ekleme yaptınız.";
                    }
                    return "Ekleme yaparken hata meydana geldi";
                }
                return "Boşlukları doldurunuz.";
            }
            return "Bu Toplantı zaten mevcut";
            throw new NotImplementedException();
        }

        public List<ToplantiTanimi> ToplantiTanimiListesi()
        {
            return db.ToplantiTanimi.ToList();
        }

        public string ToplantiTanimiSil(int toplantiTanimlarId)
        {
            if (toplantiTanimlarId > 0)
            {
                ToplantiTanimi sil = db.ToplantiTanimi.Where(i => i.ToplantiTanimlarID == toplantiTanimlarId).FirstOrDefault();
                db.ToplantiTanimi.Remove(sil);
                if (db.SaveChanges() > 0)
                {
                    toplantiTanimlarId = 0;
                    return sil.ToplantiTanimi1 + " Başarılı şekilde silindi";
                }
                return "Silme başarısız oldu";
            }
            return "Seçim yapmadınız";
            throw new NotImplementedException();
        }
        #endregion

        #region MÜŞTERİ TOPLANTILARI
        public string MusteriToplantilariGuncelle(int MusteriToplantilariId, DateTime tarih, string saat, string aciklama)
        {
            var guncelle = db.MusteriToplantilari.Where(i => i.MusteriToplantilariID == MusteriToplantilariId).FirstOrDefault();
            if (guncelle != null)
            {
                guncelle.Tarih = tarih;
                guncelle.Saat = saat;
                guncelle.Aciklama = aciklama;
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı şekilde güncellediniz.";
                }
                return "Güncelleme başarısız.";
            }
            return "Seçim yapmadınız.";
            throw new NotImplementedException();
        }

        public string MusteriToplantilariKaydet(DateTime tarih, int musteriId, int personelId, int toplantiTanimId, string saat, string aciklama)
        {

            if (!string.IsNullOrWhiteSpace(tarih.ToString()) && !string.IsNullOrWhiteSpace(saat))
            {
                MusteriToplantilari ekle = new MusteriToplantilari();
                ekle.Saat = saat;
                ekle.Tarih = tarih;
                ekle.Aciklama = aciklama;
                ekle.MusteriID = musteriId;
                ekle.PersonelID = personelId;
                ekle.ToplantiTanimiID = toplantiTanimId;
                db.MusteriToplantilari.Add(ekle);
                if (db.SaveChanges() > 0)
                {
                    return "Başarılı şekilde eklediniz.";
                }
                return "Ekleme sırasında hata meydana geldi.";
            }
            return "Boş değer girdiniz tekrar deneyiniz.";

            throw new NotImplementedException();
        }

        public string MusteriToplantilariSil(int MusteriToplantilariId)
        {
            if (MusteriToplantilariId > 0)
            {
                MusteriToplantilari sil = db.MusteriToplantilari.Where(i => i.MusteriToplantilariID == MusteriToplantilariId).FirstOrDefault();
                db.MusteriToplantilari.Remove(sil);
                if (db.SaveChanges() > 0)
                {
                    MusteriToplantilariId = 0;
                    return sil.ToplantiTanimi + " başarılı şekilde silindi.";
                }
                return "Silme başarısız oldu";
            }
            return "Seçimi yapmadınız.";
            throw new NotImplementedException();
        }

        public List<MusteriToplantilari> MusteriToplantilarListesi()
        {
            return db.MusteriToplantilari.ToList();

        }
        #endregion

    }
}
