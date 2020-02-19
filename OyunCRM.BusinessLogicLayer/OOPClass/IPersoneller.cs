using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IPersoneller
    {
        string PersonelKaydet(string tc, string adi, string soyadi, string telefon, string adres, string email, string medenihali, string cinsiyet, string dogumyeri, DateTime dogumtarihi,string resim);

        string PersonelGuncelle(int personellerId,string tc, string adi, string soyadi, string telefon, string adres, string email, string medenihali, string cinsiyet, string dogumyeri, DateTime dogumtarihi, string resim);

        string PersonelSil(int personellerId);

        List<Personeller> PersonelListesi();
        List<Personeller> PersonelListesi(string adi);
    }
}
