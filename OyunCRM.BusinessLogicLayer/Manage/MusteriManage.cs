using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.BusinessLogicLayer.OOPClass;
using MFramework.Services.FakeData;
namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class MusteriManage : IMusteriler, ISiparisler, ISiparisdetay, IMusteriOdemeleri
	{
        OyunCRMDBEntities db = new OyunCRMDBEntities();

        public List<MusteriFirmalari> MusteriFirmalariListele(int musteriID)
        {
            throw new NotImplementedException();
        }

        public string MusteriGuncelle(int musteriID, string adi, string soyadi, string telefon, string email, string fax, string adres, bool durum, string ulke, string sehir, string plakakodu)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi) && !string.IsNullOrWhiteSpace(soyadi) && !string.IsNullOrWhiteSpace(telefon))
                {
                    var guncelle = db.Musteriler.FirstOrDefault(k => k.MusterilerID == musteriID);
                    if (guncelle != null)
                    {
                        guncelle.MusteriAdi = adi;
                        guncelle.MusteriSoyadi = soyadi;
                        guncelle.Telefon = telefon;
                        guncelle.Email = email;
                        guncelle.Adres = adres;
                        guncelle.Fax = fax;
                        guncelle.Durumu = durum;
                        guncelle.Ulkesi = ulke;
                        guncelle.Sehir = sehir;
                        guncelle.PostaKodu = plakakodu;


                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + soyadi + " Musteri başarılı bir şekilde güncelledi";
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

        public string MusteriKaydet(string adi, string soyadi, string telefon, string email, string adres, string fax, string ulke, string sehir, string plakakodu, bool durum, DateTime kayitTarihi)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(adi) && !string.IsNullOrWhiteSpace(soyadi) && !string.IsNullOrWhiteSpace(telefon))
                {
                    var varmiMus = db.Musteriler.FirstOrDefault(k => k.MusteriAdi == adi && k.MusteriSoyadi == soyadi && k.Telefon == telefon);
                    if (varmiMus == null)
                    {
                        Musteriler ekle = new Musteriler();

                        ekle.MusteriAdi = adi;
                        ekle.MusteriSoyadi = soyadi;
                        ekle.Telefon = telefon;
                        ekle.Adres = adres;
                        ekle.Email = email;
                        ekle.Fax = fax;
                        ekle.Ulkesi = ulke;
                        ekle.Sehir = sehir;
                        ekle.PostaKodu = plakakodu;
                        ekle.MusteriOlmaTarihi = kayitTarihi;
                        ekle.Durumu = durum;

                        db.Musteriler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return adi + " " + soyadi + " Musteri başarılı birşekildeeklendi";
                        }
                        return "Eklerken hata oluştu";
                    }
                    return varmiMus.MusteriAdi + " adında kişi kayıtlı.";
                }
                return "Boş alanları doldurun";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Musteriler> MusteriListele()
        {
            return db.Musteriler.ToList();
        }

        public string MusteriSil(int musteriID)
        {
            try
            {
                if (musteriID > 0)
                {
                    Musteriler sil = db.Musteriler.Where(k => k.MusterilerID == musteriID).FirstOrDefault();
                    db.Musteriler.Remove(sil);

                    if (db.SaveChanges() > 0)
                    {
                        musteriID = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                        return sil.MusteriAdi + " başarılı bir şekilde silindi";
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

        public void MusteriEkleFakeData()
        {
            var sayiSorgusu = db.Musteriler.Count();
            if (sayiSorgusu < 1300)
            {
                for (int i = 0; i < 100; i++)
                {
                    Musteriler ekle = new Musteriler();
                    ekle.MusteriAdi = NameData.GetFirstName();
                    ekle.MusteriSoyadi = NameData.GetSurname();
                    ekle.Adres = PlaceData.GetAddress();
                    //MFramework.Services.FakeData.
                    ekle.Ulkesi = PlaceData.GetCountry();
                    ekle.Sehir = PlaceData.GetCity();
                    ekle.PostaKodu = PlaceData.GetPostCode();
                    ekle.Telefon = PhoneNumberData.GetPhoneNumber();
                    ekle.Fax = PhoneNumberData.GetInternationalPhoneNumber();
                    ekle.Email = NetworkData.GetEmail();
                    ekle.MusteriOlmaTarihi = DateTimeData.GetDatetime(Convert.ToDateTime("01.01.2005"), DateTime.Now);
                    ekle.Durumu = BooleanData.GetBoolean();
                    ekle.Aciklama = TextData.GetSentences(1);
                    db.Musteriler.Add(ekle);
                    db.SaveChanges();

                }
            }
        }
		#region siparislerimlement
		public string SiparisGuncelle(int siparisID, int musteriID, int personelD, DateTime Baslangic, DateTime bitis, string aciklama)
		{
			OyunCRMDBEntities db = new OyunCRMDBEntities();
			try
			{
				if (!string.IsNullOrWhiteSpace(siparisID.ToString()) && !string.IsNullOrWhiteSpace(musteriID.ToString()) && !string.IsNullOrWhiteSpace(Baslangic.ToString()))
				{
					var guncelle = db.MusteriSiparisleri.FirstOrDefault(k => k.MusteriSiparisleriID == siparisID);
					if (guncelle != null)
					{
						guncelle.MusteriID = musteriID;
						guncelle.PersonelID = personelD;
						guncelle.SiparisVerilisTarihi = Baslangic;
						guncelle.SiparisTeslimTarihi = bitis;
						guncelle.Aciklama = aciklama;


						//     db.MusteriSiparisleris.Add(guncelle);
						if (db.SaveChanges() > 0)
						{
							return siparisID + "  No'lu sipariş başarı ile Güncellendi ";
						}
						return "Eklerken hata oluştu";
					}
					return guncelle.MusteriSiparisleriID + "Sipariş bulunmuyor ";
				}
				return "Boş alanları doldurun";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string SiparisKaydet(int musteriID, int personelD, DateTime Baslangic, DateTime bitis, string aciklama)
		{
			OyunCRMDBEntities db = new OyunCRMDBEntities();
			try
			{
				if (!string.IsNullOrWhiteSpace(personelD.ToString()) && !string.IsNullOrWhiteSpace(musteriID.ToString()) && !string.IsNullOrWhiteSpace(Baslangic.ToString()))
				{


					MusteriSiparisleri ekle
					= new MusteriSiparisleri();
					ekle.MusteriID = musteriID;
					ekle.PersonelID = personelD;
					ekle.SiparisVerilisTarihi = Baslangic;
					ekle.SiparisTeslimTarihi = bitis;
					ekle.Aciklama = aciklama;


					db.MusteriSiparisleri.Add(ekle);
					if (db.SaveChanges() > 0)
					{
						return musteriID + "  No'lu Müşterinin  siparişi başarı ile eklendi ";
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

		public List<MusteriSiparisleri> SiparisListesi()
		{
			return db.MusteriSiparisleri.ToList();
		}

		public List<MusteriSiparisleri> SiparisListesi(int musteriID)
		{
			return db.MusteriSiparisleri.Where(k => k.MusteriID == musteriID).ToList();
		}

		public string SiparisSil(int SiparisID)
		{
			try
			{
				if (SiparisID > 0)
				{
					MusteriSiparisleri sil = db.MusteriSiparisleri.Where(k => k.MusteriSiparisleriID == SiparisID).FirstOrDefault();
					db.MusteriSiparisleri.Remove(sil);

					if (db.SaveChanges() > 0)
					{
						SiparisID = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
						return sil.MusteriSiparisleriID + " başarılı bir şekilde silindi";
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
		#endregion
		#region SiparişDetay









		public string SiparisDetayKaydet(int siparisID, int urunID, decimal fiyat, int miktar, decimal indirim, string aciklama)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(siparisID.ToString()) && !string.IsNullOrWhiteSpace(urunID.ToString()) && !string.IsNullOrWhiteSpace(fiyat.ToString()))
				{


					MusteriSiparisDetay ekle
					= new MusteriSiparisDetay();
					ekle.MusteriSiparisID = siparisID;
					ekle.UrunID = urunID;
					ekle.Fiyat = fiyat;
					ekle.Miktar = miktar;
					ekle.Aciklama = aciklama;
					ekle.IndirimOrani = indirim;


					db.MusteriSiparisDetay.Add(ekle);
					if (db.SaveChanges() > 0)
					{
						return siparisID + "  No'lu siparişin  ürünü başarı ile eklendi ";
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

		public string SiparisDetayGuncelle(int siparisdetayID, int siparisID, int urunID, decimal fiyat, int miktar, decimal indirim, string aciklama)
		{
			try
			{

				if (!string.IsNullOrWhiteSpace(siparisID.ToString()) && !string.IsNullOrWhiteSpace(urunID.ToString()) && !string.IsNullOrWhiteSpace(fiyat.ToString()))
				{
					var varmisiparis = db.MusteriSiparisDetay.FirstOrDefault(k => k.MusteriSiparisDetaylariID == siparisdetayID);
					if (varmisiparis != null)
					{


						varmisiparis.MusteriSiparisID = siparisID;
						varmisiparis.UrunID = urunID;
						varmisiparis.Fiyat = fiyat;
						varmisiparis.Miktar = miktar;
						varmisiparis.Aciklama = aciklama;
						varmisiparis.IndirimOrani = indirim;

						//   db.MusteriSiparisDetays.Add(varmisiparis);
						if (db.SaveChanges() > 0)
						{
							return siparisID + "  No'lu siparişin  ürünü başarı ile guncellendi ";
						}




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

		public List<Musteriler> Musterilistesi()
		{
			return db.Musteriler.ToList();
		}

		public List<MusteriSiparisDetay> detaySiparisListesi()
		{
			return db.MusteriSiparisDetay.ToList();
		}

		public List<MusteriSiparisDetay> detaySiparisListesi(int SiparisNO)
		{
			return db.MusteriSiparisDetay.Where(k => k.MusteriSiparisID == SiparisNO).ToList();
		}

		public string SiparisDetaySil(int siparisdetayID)
		{
			try
			{
				if (siparisdetayID > 0)
				{
					MusteriSiparisDetay sill = db.MusteriSiparisDetay.Where(k => k.MusteriSiparisDetaylariID == siparisdetayID).FirstOrDefault();
					db.MusteriSiparisDetay.Remove(sill);

					if (db.SaveChanges() > 0)
					{
						siparisdetayID = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
						return sill.MusteriSiparisDetaylariID + " başarılı bir şekilde silindi";
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





        #endregion
        public List<Musteriler> MusteriListele1()
        {
            return db.Musteriler.ToList();
        }

        public Musteriler MusteriGetirTelNoIle(string telno)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(telno))
                {
                    var musteri = db.Musteriler.FirstOrDefault(k => k.Telefon == telno);
                    if (musteri != null)
                    {
                        return musteri;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region Müşteri Ödemeleri

        public string MusteriOdemesiKaydet(int odemesekliid, DateTime odemetarihi, decimal odenecekmiktar, string aciklama, int musteriid, string bankaadi)
        {
            try
            {
                if (odenecekmiktar < 0)
                {
                    return "Ödenecek miktar değeri negatif olamaz";
                }
                else
                {
                    if (odenecekmiktar > 0)
                    {
                        MusteriOdemeleri ekle = new MusteriOdemeleri();
                        ekle.OdemeSekliID = odemesekliid;
                        ekle.OdemeTarihi = odemetarihi;
                        ekle.OdenecekMiktar = odenecekmiktar;
                        ekle.Aciklama = aciklama;
                        ekle.MusteriID = musteriid;
                        ekle.BankaAdi = bankaadi;
                        db.MusteriOdemeleri.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "Müşteri ödemesi başarılı bir şekilde eklendi.";
                        }
                        return "Eklerken hata oluştu.";
                    }
                    else
                    {
                        return "Ödeme miktarı alanı boş geçilemez!";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string MusteriOdemeGuncelle(int musteriodemeleriid, int odemesekliid, DateTime odemetarihi, decimal odenecekmiktar, string aciklama, int musteriid, string bankaadi)
        {
            try
            {
                var guncelle = db.MusteriOdemeleri.Where(i => i.MusteriOdemeleriID == musteriodemeleriid).FirstOrDefault();
                if (guncelle != null)
                {
                    if (odenecekmiktar < 0)
                    {
                        return "Ödenecek miktar değeri negatif olamaz";
                    }
                    else
                    {
                        if (odenecekmiktar > 0)
                        {
                            guncelle.OdemeSekliID = odemesekliid;
                            guncelle.OdemeTarihi = odemetarihi;
                            guncelle.OdenecekMiktar = odenecekmiktar;
                            guncelle.Aciklama = aciklama;
                            guncelle.MusteriID = musteriid;
                            guncelle.BankaAdi = bankaadi;
                            if (db.SaveChanges() > 0)
                            {
                                return "Müşteri ödemesi başarılı bir şekilde güncellendi.";
                            }
                            return "Güncellerken hata oluştu.";
                        }
                        else
                        {
                            return "Ödeme miktarı alanı boş geçilemez!";
                        }
                    }
                }
                return "Seçim yapmadınız!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string MusteriOdemeSil(int musteriodemeleriid)
        {
            try
            {
                if (musteriodemeleriid > 0)
                {
                    MusteriOdemeleri sil = db.MusteriOdemeleri.Where(i => i.MusteriOdemeleriID == musteriodemeleriid).FirstOrDefault();
                    db.MusteriOdemeleri.Remove(sil);
                    if (db.SaveChanges() > 0)
                    {
                        musteriodemeleriid = 0;
                        return "Başarılı bir şekilde silindi";
                    }
                    return "Silme başarısız oldu";
                }
                return "Seçim yapmadınız.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<MusteriOdemeleri> MusteriOdemeleriListesi()
        {
            return db.MusteriOdemeleri.ToList();
        }

        public string OdemeSekliAdiGetir(int id)
        {
            string Adi = db.OdemeSekli.Select(k => new
            {
                ID = k.OdemeSekilleriID,
                odemeadi = k.OdemeAdi
            }).Where(k => k.ID == id).FirstOrDefault().odemeadi.ToString();
            return Adi;
        }

        #endregion

        public string MusteriAdSoyadGetir(int id)
        {
            string AdSoyad = db.Musteriler.Select(p => new
            {
                musID = p.MusterilerID,
                AdSoyad = p.MusteriAdi + " " + p.MusteriSoyadi
            }).Where(p => p.musID == id).FirstOrDefault().AdSoyad.ToString();
            return AdSoyad;
        }
    }
}
