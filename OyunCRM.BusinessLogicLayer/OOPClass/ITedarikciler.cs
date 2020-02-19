using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface ITeradikciler
    {
        string TedarikciKaydet(string sirketadi, string kontakadi, string unvan, string adres, string ulke, string sehir, string postakodu, string telefon, string fax, string email, DateTime baslangic, bool durum, string aciklama);
        string TedarikciGuncelle(int tedarikcilerId, string sirketadi, string kontakadi, string unvan, string adres, string ulke, string sehir, string postakodu, string telefon, string fax, string email, DateTime baslangic, bool durum, string aciklama);
        string TedarikciSil(int tedarikcilerId);
        List<Tedarikciler> TedarikcilerListesi();

    }
}
