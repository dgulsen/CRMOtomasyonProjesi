using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class Bankalarmanage : IBankalar
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public string BankaGuncelle(int bankalarId, string adi)
        {
            try
            {
                var guncelle = db.Bankalar.Where(k => k.BankalarID == bankalarId).FirstOrDefault();

                if (guncelle != null)//tıklanan ID değeri varsa DB de
                {
                    if (!string.IsNullOrWhiteSpace(adi))//Adı boş değilse
                    {
                        guncelle.BankaAdi = adi;

                        if (db.SaveChanges() > 0)
                        {
                            return adi + " başarılı bir şekilde güncellendi";
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

        public string BankaKaydet(string adi)
        {
            try
            {
                var varmiBank = db.Bankalar.Where(k => k.BankaAdi == adi).FirstOrDefault();

                if (varmiBank == null)
                {
                    if (!string.IsNullOrWhiteSpace(adi))
                    {
                        Bankalar ekle = new Bankalar();
                        ekle.BankaAdi = adi;
                        db.Bankalar.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Boş alanları doldurun";
                }
                return "Aynı Banka mevcut";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Bankalar> BankaListesi()
        {
            return db.Bankalar.ToList();
        }

        public string BankaSil(int bankalarId)
        {
            try
            {
                if (bankalarId > 0)
                {
                    Bankalar sil = db.Bankalar.Where(k => k.BankalarID == bankalarId).FirstOrDefault();
                    db.Bankalar.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        bankalarId = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                        return sil.BankaAdi + " başarılı bir şekilde silindi";
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
            //her silme,güncelleme metodu çalıştırıldığında işlem başarısızda olsa , başarılı da olda bütün olayları yeniden yaptırmamak için bu metodu yazdık.Sadece başarılı olduğunda bu işlemi yaptıracağız
            kelime = kelime.ToLower();
            bool sonuc = (kelime.Contains("başarılı") || kelime.Contains("Başarılı"));
            return sonuc;
        }
    }
}
