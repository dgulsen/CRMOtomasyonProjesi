using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IMusteriler
    {
        string MusteriKaydet(string adi, string soyadi, string telefon, string email, string adres, string fax, string ulke, string sehir, string plakakodu, bool durum, DateTime kayitTarihi);

        string MusteriGuncelle(int musteriID, string adi, string soyadi, string telefon, string email, string fax, string adres, bool durum, string ulke, string sehir, string plakakodu);

        string MusteriSil(int musteriID);

        List<Musteriler> MusteriListele();
        List<MusteriFirmalari> MusteriFirmalariListele(int musteriID);
    }
}
