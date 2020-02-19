using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
using MFramework.Services.FakeData;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class PersonelManage : IDepartman,IPersoneller,IPersonelMaaslari,IPersonelPrimleri,IGunlukTakip
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();

        #region Departman işlemleri

       
        public string DepartmanGuncelle(int departmanlarId, string adi)
        {
            try
            {
                var guncelle = db.Departmanlar.Where(k => k.DepartmanlarID == departmanlarId).FirstOrDefault();

                if (guncelle != null)//tıklanan ID değeri varsa DB de
                {
                    if (!string.IsNullOrWhiteSpace(adi))//Adı boş değilse
                    {
                        guncelle.DepartmanAdi = adi;

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

        public string DepartmanKaydet(string adi)
        {
            try
            {
                var varmiDep = db.Departmanlar.Where(k => k.DepartmanAdi == adi).FirstOrDefault();

                if (varmiDep == null)
                {
                    if (!string.IsNullOrWhiteSpace(adi))
                    {
                        Departmanlar ekle = new Departmanlar();
                        ekle.DepartmanAdi = adi;
                        db.Departmanlar.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " başarılı bir şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return "Boş alanları doldurun";
                }
                return "Aynı departman mevcut";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Departmanlar> DepartmanListesi()
        {
            return db.Departmanlar.ToList();
        }

        public string DepartmanSil(int departmanlarId)
        {
            try
            {
                if (departmanlarId > 0)
                {
                    Departmanlar sil = db.Departmanlar.Where(k => k.DepartmanlarID == departmanlarId).FirstOrDefault();
                    db.Departmanlar.Remove(sil);

                    if (db.SaveChanges()>0)
                    {
                        departmanlarId = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                        return sil.DepartmanAdi + " başarılı bir şekilde silindi";
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


        #endregion


        #region PERSONEL İŞLEMLERİ
        public void PersonelEkleFakeData()
        {
            string[] medeniHali = { "Evli", "Bekar" };
            Random rnd = new Random();
            int sayi = db.Personeller.Count();

            if (sayi<200)
            {
                for (int i = 0; i < 200; i++)
                {
                    Personeller ekle = new Personeller();
                    ekle.TC = MFramework.Services.FakeData.TextData.GetNumeric(11);

                    if ((rnd.Next(0, 5)) % 2 == 0)
                    {
                        ekle.Adi = NameData.GetFemaleFirstName();
                        ekle.Cinsiyet = "Kadın";
                    }
                    else
                    {
                        ekle.Adi = NameData.GetMaleFirstName();
                        ekle.Cinsiyet = "Erkek";
                    }

                    ekle.Soyadi = NameData.GetSurname();
                    ekle.Telefon = PhoneNumberData.GetPhoneNumber();
                    ekle.Adres = PlaceData.GetAddress();
                    ekle.Email = NetworkData.GetEmail();
                    ekle.MedeniHali = medeniHali[rnd.Next(0, 1)];

                    int p_kodu = rnd.Next(1, 81);
                    ekle.DogumYeri = db.iller.Where(k => k.PlakaKodu == p_kodu).FirstOrDefault().ilAdi;
                    //+ "--" + db.ilceler.Where(k => k.ilcelerID == (rnd.Next(1, 972))).FirstOrDefault().iller.ilAdi;
                    ekle.DogumTarihi = DateTimeData.GetDatetime(DateTime.Parse("02.10.1970"), DateTime.Parse("01.01.2001"));
                    db.Personeller.Add(ekle);
                    db.SaveChanges();

                } 
            }

        }
        public int  PersonelIDGetir(string personelTC)
        {
            var Id = db.Personeller.FirstOrDefault(k=>k.TC==personelTC).PersonellerID;
            return Id;
        }

        public string PersonelGuncelle(int personellerId, string tc, string adi, string soyadi, string telefon, string adres, string email, string medenihali, string cinsiyet, string dogumyeri, DateTime dogumtarihi, string resim)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi) && !string.IsNullOrWhiteSpace(soyadi) && !string.IsNullOrWhiteSpace(telefon))
                {
                    var guncelle = db.Personeller.FirstOrDefault(k =>k.PersonellerID==personellerId);
                    if (guncelle != null)
                    {
                        guncelle.TC = tc;
                        guncelle.Adi = adi;
                        guncelle.Soyadi = soyadi;
                        guncelle.Telefon = telefon;
                        guncelle.Adres = adres;
                        guncelle.Email = email;
                        guncelle.MedeniHali = medenihali;
                        guncelle.Cinsiyet = cinsiyet;
                        guncelle.DogumYeri = dogumyeri;
                        guncelle.DogumTarihi = dogumtarihi;
                        guncelle.Resim = resim;

                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + soyadi + " personeli başarılı bir şekilde güncelledi";
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

        public string PersonelKaydet(string tc, string adi, string soyadi, string telefon, string adres, string email, string medenihali, string cinsiyet, string dogumyeri, DateTime dogumtarihi, string resim)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi)&& !string.IsNullOrWhiteSpace(soyadi)&& !string.IsNullOrWhiteSpace(telefon))
                {
                    var varmiPers = db.Personeller.FirstOrDefault(k => k.TC == tc);
                    if (varmiPers==null)
                    {
                        Personeller ekle = new Personeller();
                        ekle.TC = tc;
                        ekle.Adi = adi;
                        ekle.Soyadi = soyadi;
                        ekle.Telefon = telefon;
                        ekle.Adres = adres;
                        ekle.Email = email;
                        ekle.MedeniHali = medenihali;
                        ekle.Cinsiyet = cinsiyet;
                        ekle.DogumYeri = dogumyeri;
                        ekle.DogumTarihi = dogumtarihi;
                        ekle.Resim = resim;

                        db.Personeller.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + soyadi + " personeli başarılı birşekildeeklendi";
                        }
                        return "Eklerken hata oluştu";  
                    }
                    return varmiPers.Adi + " adında kişi kayıtlı lütfen TC'yi kontrol ediniz";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Personeller> PersonelListesi()
        {
            return db.Personeller.ToList();
        }

        public List<Personeller> PersonelListesi(string adi)
        {
            throw new NotImplementedException();
        }
        public List<sp_PersonelListesi_Result> sp_PersonelListesi()
        {
            return db.sp_PersonelListesi().ToList();
        }
        public string PersonelSil(int personellerId)
        {
            throw new NotImplementedException();
        }


        #endregion


        #region Personel Maaşları

        public string PersonelMaasBilgilerKaydet(int personelID, decimal maas, DateTime baslangicTarihi, DateTime bitisTarihi, string aciklama)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(personelID.ToString()) && !string.IsNullOrWhiteSpace(maas.ToString()) && !string.IsNullOrWhiteSpace(baslangicTarihi.ToString()))
                {
                    PesonelMaasBilgiler ekle = new PesonelMaasBilgiler();
                    ekle.PersonelID = personelID;
                    ekle.Maas = maas;
                    ekle.BaslangicTarihi = baslangicTarihi;
                    ekle.BitisTarihi = bitisTarihi;
                    ekle.Aciklama = aciklama;

                    db.PesonelMaasBilgiler.Add(ekle);
                    if (db.SaveChanges() > 0)
                    {
                        return "Personelin maas bilgisi başarılı bir şekilde eklendi";
                    }
                    return "Eklerken hata oluştu";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PersonelMaasBilgilerGuncelle(int personelMaaslarID, int personelID, decimal maas, DateTime baslangicTarihi, DateTime bitisTarihi, string aciklama)
        {
            try
            {
                var guncelle = db.PesonelMaasBilgiler.Where(k => k.PersonelMaaslarID == personelMaaslarID).FirstOrDefault();

                if (guncelle != null)
                {
                    if (!string.IsNullOrWhiteSpace(personelID.ToString()) && !string.IsNullOrWhiteSpace(maas.ToString()) && !string.IsNullOrWhiteSpace(baslangicTarihi.ToString()))
                    {
                        guncelle.PersonelID = personelID;
                        guncelle.Maas = maas;
                        guncelle.BaslangicTarihi = baslangicTarihi;
                        guncelle.BitisTarihi = bitisTarihi;
                        guncelle.Aciklama = aciklama;

                        if (db.SaveChanges() > 0)
                        {
                            return "Personelin maas bilgisi başarılı bir şekilde güncellendi";
                        }
                        return "Güncellerken hata oluştu";
                    }
                    return "Boş alanları doldurun";
                }
                return "Personel maaş bilgisi bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PersonelMaasBilgilerSil(int personelMaaslarID)
        {
            try
            {
                if (personelMaaslarID > 0)
                {
                    PesonelMaasBilgiler sil = db.PesonelMaasBilgiler.Where(k => k.PersonelMaaslarID == personelMaaslarID).FirstOrDefault();
                    db.PesonelMaasBilgiler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        personelMaaslarID = 0;
                        return "Personelin maaş bilgisi başarılı bir şekilde silindi";
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

        public List<PesonelMaasBilgiler> PersonelMaasBilgilerListesi()
        {
            return db.PesonelMaasBilgiler.ToList();
        }
        #endregion


        #region PERSONEL PRİM İŞLEMLERİ
        public string PersonelPrimlerKaydet(int personelID, int primGunSayisi, string aciklama)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(personelID.ToString()) && !string.IsNullOrWhiteSpace(primGunSayisi.ToString()))
                {
                    PersonelPrimler ekle = new PersonelPrimler();
                    ekle.PersonelID = personelID;
                    ekle.PrimGunSayisi = primGunSayisi;
                    ekle.Aciklama = aciklama;

                    db.PersonelPrimler.Add(ekle);
                    if (db.SaveChanges() > 0)
                    {
                        return "Personelin prim bilgisi başarılı bir şekilde eklendi";
                    }
                    return "Eklerken hata oluştu";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PersonelPrimlerGuncelle(int personelPrimlerID, int personelID, int primGunSayisi, string aciklama)
        {
            try
            {
                var guncelle = db.PersonelPrimler.Where(k => k.PersonelPrimlerID == personelPrimlerID).FirstOrDefault();

                if (guncelle != null)
                {
                    if (!string.IsNullOrWhiteSpace(personelID.ToString()) && !string.IsNullOrWhiteSpace(primGunSayisi.ToString()))
                    {
                        guncelle.PersonelID = personelID;
                        guncelle.PrimGunSayisi = primGunSayisi;
                        guncelle.Aciklama = aciklama;

                        if (db.SaveChanges() > 0)
                        {
                            return "Personelin prim bilgisi başarılı bir şekilde güncellendi";
                        }
                        return "Güncellerken hata oluştu";
                    }
                    return "Boş alanları doldurun";
                }
                return "Personel prim bilgisi bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PersonelPrimlerSil(int personelPrimlerID)
        {
            try
            {
                if (personelPrimlerID > 0)
                {
                    PersonelPrimler sil = db.PersonelPrimler.Where(k => k.PersonelPrimlerID == personelPrimlerID).FirstOrDefault();
                    db.PersonelPrimler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        personelPrimlerID = 0;
                        return "Personelin prim bilgisi başarılı bir şekilde silindi";
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

        public List<PersonelPrimler> PersonelPrimlerListesi()
        {
            return db.PersonelPrimler.ToList();
        }

        #endregion

        public Personeller PersonelBilgisiGetirEmaille(string email)
        {
            var personel = db.Personeller.FirstOrDefault(k => k.Email == email);
            if (personel != null)
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    return personel;
                }
                return null;
            }
            return null;
        }


        #region PERSONEL GÜNLÜK TAKİP

        public string iseBaslamaSaati { get; private set; } 
        public string gunlukTakipEkle(int PersonelID, DateTime GirisSaati, DateTime CikisSaati, string Aciklama)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Aciklama))
                {
                    var varmiTakip = db.PersonelGunlukTakip.FirstOrDefault(k => k.PersonelID == PersonelID);
                    if (varmiTakip == null)
                    {
                        PersonelGunlukTakip ekleTakip = new PersonelGunlukTakip();
                        ekleTakip.PersonelID = PersonelID;
                        ekleTakip.Giris = GirisSaati;
                        ekleTakip.Cikis = CikisSaati;
                        ekleTakip.Aciklama = Aciklama;
                        db.PersonelGunlukTakip.Add(ekleTakip);
                        if (db.SaveChanges() > 0)
                        {
                            return GirisSaati + "Başarılı şekilde eklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return varmiTakip.Giris + "Saatinde Personel Girişi bulunmaktadır. Kontrol ediniz.";
                }
                return "boş alanları doldurun";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string GunlukTakipGuncelle(int personelGunlukTakipID, DateTime GirisSaati, DateTime CikisSaati, string Aciklama)
        {
            try
            {
                var updateTakip = db.PersonelGunlukTakip.Where(k => k.PeronselGunTakipleriID == personelGunlukTakipID).FirstOrDefault();

                if (updateTakip != null)
                {
                    if (!string.IsNullOrWhiteSpace(Aciklama))
                    {
                        updateTakip.Giris = GirisSaati;
                        updateTakip.Cikis = CikisSaati;
                        updateTakip.Aciklama = Aciklama;

                        if (db.SaveChanges() > 0)
                        {
                            return GirisSaati + " Başarılı bir şekilde güncellendi.";
                        }
                        return "Guncellerken Hata oluştu.";
                    }
                    return "Boş alanları doldurun";
                }
                return "Seçim yapmadınız";
            }
            catch (Exception es)
            {

                return es.Message; ;
            }
        }

        public string GunlukTakipSil(int PersonelgunlukTakipID)
        {
            try
            {
                if (PersonelgunlukTakipID > 0)
                {
                    PersonelGunlukTakip sil = db.PersonelGunlukTakip.Where(k => k.PeronselGunTakipleriID == PersonelgunlukTakipID).FirstOrDefault();
                    db.PersonelGunlukTakip.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        PersonelgunlukTakipID = 0;
                        return sil + " Başarılı bir şekilde silindi.";
                    }
                    return "Silme Başarısız oldu.";
                }
                return "Seçim Yapmadınız.";
            }
            catch (Exception es)
            {

                return es.Message;
            }
        }

        public List<PersonelGunlukTakip> PersonelGunlukTakips()
        {
            return db.PersonelGunlukTakip.ToList();
        }

        public List<PersonellerinCalistigiDepartmanlar> personellerinCalistigiDepartmanlars(string Departmanadi)
        {
            return db.PersonellerinCalistigiDepartmanlar.Where(k => k.DerpartmanAdi == Departmanadi).ToList();
        }
        #endregion

    }
}
