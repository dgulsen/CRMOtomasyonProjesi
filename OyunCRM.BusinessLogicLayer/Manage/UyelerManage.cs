using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class UyelerManage 
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public List<Personeller> PersonelListesi()
        {
            return db.Personeller.ToList();
        }
        public List<Yetkiler> YetkiListesi()
        {
            return db.Yetkiler.ToList();
        }

        public string UyeGuncelle(int uyeid, int personelid, int yetkiid, string uyeadi, string sifre, bool durum, DateTime kayittarihi, string aciklama)
        {
            try
            {
                var guncelle = db.Uyeler.Where(k => k.UyelerID == uyeid).FirstOrDefault();

                if (guncelle != null)
                {
                    if (!string.IsNullOrWhiteSpace(uyeadi))
                    {

                        guncelle.UyeAdi = uyeadi;
                        guncelle.Sifre = sifre;
                        guncelle.Durum = durum;
                        guncelle.KayitTarihi = kayittarihi;
                        guncelle.Aciklama = aciklama;
                        guncelle.YetkiID = yetkiid;

                        if (db.SaveChanges() > 0)
                        {
                            return uyeadi + " üyesi başarılı bir şekilde güncellendi";
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
        }

        public string UyeKaydet(int personelid, int yetkiid, string uyeadi, string sifre, bool durum, DateTime kayittarihi, string aciklama)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(uyeadi) && !string.IsNullOrWhiteSpace(yetkiid.ToString()))
                {
                    var varmiUye = db.Uyeler.FirstOrDefault(k => k.PersonelID == personelid);
                    if (varmiUye == null)
                    {
                        Uyeler ekle = new Uyeler();
                        ekle.PersonelID = personelid;
                        ekle.UyeAdi = uyeadi;
                        ekle.Sifre = sifre;
                        ekle.Durum = durum;
                        ekle.KayitTarihi = kayittarihi;
                        ekle.Aciklama = aciklama;
                        ekle.YetkiID = yetkiid;

                        db.Uyeler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return uyeadi + " üyesi başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Üye zaten ekli";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Uyeler> UyeListesi()
        {
            return db.Uyeler.ToList();
        }

        public string UyeSil(int uyeid)
        {
            try
            {
                if (uyeid > 0)
                {
                    Uyeler sil = db.Uyeler.Where(k => k.UyelerID == uyeid).FirstOrDefault();
                    db.Uyeler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        uyeid = 0;
                        return sil.UyeAdi + " başarılı bir şekilde silindi";
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
        public bool islemOnayBilgisi(string kelime)
        {

            kelime = kelime.ToLower();
            bool sonuc = kelime.Contains("başarılı");

            return sonuc;
        }
    }
}
