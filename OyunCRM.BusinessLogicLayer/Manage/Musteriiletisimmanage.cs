using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class Musteriiletisimmanage : IMusteriiletisim
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public string iletisimGuncelle(int iletisimSekliId, int musteriId, bool telefon, bool mail, bool fax, string aciklama)
        {
            try
            {
                if (iletisimSekliId > 0)
                {
                    var varmiiletisim = db.MusteriiletisimSekli.FirstOrDefault(k => k.MusteriiletisimSekilleriID == iletisimSekliId);
                    if (varmiiletisim != null)
                    {
                        varmiiletisim.MusteriID = musteriId;
                        varmiiletisim.Telefon = telefon;
                        varmiiletisim.Mail = mail;
                        varmiiletisim.Fax = fax;
                        varmiiletisim.Aciklama = aciklama;
                        if (db.SaveChanges() > 0)
                        {
                            return varmiiletisim.MusteriiletisimSekilleriID + " " + " ID li iletişim başarılı bir şekilde güncellendi";
                        }
                        return "Güncellerken hata oluştu";
                    }
                    return musteriId + " ID'li iletisim kayıtlı değil, lütfen kontrol ediniz";
                }
                return "Secim yapılmadı";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public int iletisimIDGetir(int musteriID)
        {
            var Id = db.MusteriiletisimSekli.FirstOrDefault(k => k.MusteriID == musteriID).MusteriiletisimSekilleriID;
            return Id;
        }
        public string Musteriisimgetir(int musteriId)
        {
            return db.Musteriler.FirstOrDefault(k => k.MusterilerID == musteriId).MusteriAdi + db.Musteriler.FirstOrDefault(k => k.MusterilerID == musteriId).MusteriSoyadi;
        }
        public string iletisimKaydet(int musteriId, bool telefon, bool mail, bool fax, string aciklama)
        {
            try
            {
                if (musteriId > 0)
                {
                    var varmiiletisim = db.MusteriiletisimSekli.FirstOrDefault(k => k.MusteriID == musteriId);
                    if (varmiiletisim == null)
                    {
                        MusteriiletisimSekli ekle = new MusteriiletisimSekli();
                        ekle.MusteriID = musteriId;
                        ekle.Telefon = telefon;
                        ekle.Mail = mail;
                        ekle.Fax = fax;
                        ekle.Aciklama = aciklama;
                        db.MusteriiletisimSekli.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return musteriId + " " + " ID li müşteri başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return musteriId + " ID'li musteri iletisimi mevcut, lütfen MusteriID yi kontrol ediniz";
                }
                return "Secim yapılmadı";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool islemOnayBilgisi(string kelime)
        {
            //her silme,güncelleme metodu çalıştırıldığında işlem başarısızda olsa , başarılı da olda bütün olayları yeniden yaptırmamak için bu metodu yazdık.Sadece başarılı olduğunda bu işlemi yaptıracağız
            kelime = kelime.ToLower();
            bool sonuc = (kelime.Contains("başarılı") || kelime.Contains("Başarılı"));
            return sonuc;
        }

        public List<MusteriiletisimSekli> iletisimListesi()
        {
            return db.MusteriiletisimSekli.ToList();
        }

        public List<MusteriiletisimSekli> iletisimListesi(int musteriId)
        {
            throw new NotImplementedException();
        }

        public string iletisimSil(int iletisimSekliId)
        {
            try
            {
                if (iletisimSekliId > 0)
                {
                    MusteriiletisimSekli sil = db.MusteriiletisimSekli.Where(k => k.MusteriiletisimSekilleriID == iletisimSekliId).FirstOrDefault();
                    db.MusteriiletisimSekli.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        iletisimSekliId = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                        return sil.MusteriiletisimSekilleriID + " ID'li iletişim başarılı bir şekilde silindi";
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
    }
}

