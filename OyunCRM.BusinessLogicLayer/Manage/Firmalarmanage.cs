using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class FirmalarManage : IFirmalar
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public int FirmaIDGetir(string firmaadi)
        {
            var Id = db.Firmalar.FirstOrDefault(k => k.FirmaAdi == firmaadi).FirmalarID;
            return Id;
        }
        public string FirmaGuncelle(int firmalarId, string adi, bool durumu, string aciklama, DateTime kayittarihi, int personelıd, string telefon, string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi))
                {
                    var guncelle = db.Firmalar.FirstOrDefault(k => k.FirmalarID == firmalarId);
                    if (guncelle != null)
                    {
                        guncelle.FirmaAdi = adi;
                        guncelle.FirmaDurumu = durumu;
                        guncelle.Aciklama = aciklama;
                        guncelle.Telefon = telefon;
                        guncelle.FirmaKayitTarihi = kayittarihi;
                        guncelle.PersonelID = personelıd;
                        guncelle.Mail = email;

                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + " firması başarılı bir şekilde güncellendi";
                        }
                        return "Güncellerken hata oluştu";
                    }
                    return "Seçim yapmadınız";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string FirmaKaydet(string adi, bool durumu, string aciklama, DateTime kayittarihi, int personelıd, string telefon, string email)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi))
                {
                    var varmiFirma = db.Firmalar.FirstOrDefault(k => k.FirmaAdi == adi);
                    if (varmiFirma == null)
                    {
                        Firmalar ekle = new Firmalar();
                        ekle.FirmaAdi = adi;
                        ekle.FirmaDurumu = durumu;
                        ekle.Aciklama = aciklama;
                        ekle.Telefon = telefon;
                        ekle.FirmaKayitTarihi = kayittarihi;
                        ekle.PersonelID = personelıd;
                        ekle.Mail = email;
                        db.Firmalar.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + " firması başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return varmiFirma.FirmaAdi + " adında firma kayıtlı, lütfen firma adını kontrol ediniz";
                }
                return "Boş alanları doldurun";
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

        public List<Firmalar> FirmaListesi()
        {
            return db.Firmalar.ToList();
        }

        public List<Firmalar> FirmaListesi(string adi)
        {
            throw new NotImplementedException();
        }

        public string FirmaSil(int firmalarId)
        {
            try
            {
                if (firmalarId > 0)
                {
                    Firmalar sil = db.Firmalar.Where(k => k.FirmalarID == firmalarId).FirstOrDefault();
                    db.Firmalar.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        firmalarId = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                        return sil.FirmaAdi + " başarılı bir şekilde silindi";
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
