using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;


namespace OyunCRM.BusinessLogicLayer.OOPClass
{
	interface ISiparisler
	{
		string SiparisKaydet(int musteriID, int personelD, DateTime Baslangic, DateTime bitis, string aciklama);
		string SiparisGuncelle(int siparisID, int musteriID, int personelD, DateTime Baslangic, DateTime bitis, string aciklama);
		string SiparisSil(int SiparisID);
		List<MusteriSiparisleri> SiparisListesi();
		List<MusteriSiparisleri> SiparisListesi(int musteriID);




	}

	interface ISiparisdetay
	{
		string SiparisDetayKaydet(int siparisID, int urunID, decimal fiyat, int miktar, decimal indirim, string aciklama);
		string SiparisDetayGuncelle(int siparisdetayID, int siparisID, int urunID, decimal fiyat, int miktar, decimal indirim, string aciklama);
		string SiparisDetaySil(int siparisdetayID);
		List<MusteriSiparisDetay> detaySiparisListesi();
		List<MusteriSiparisDetay> detaySiparisListesi(int SiparisNO);

	}
}
