using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    public interface IToplantilar
    {
        string ToplantiTanimiKaydet(string toplantiTanimi, DateTime olusturmaTarihi, string acikla);
        string ToplantiTanimiGuncelle(int toplantiTanimlarId, string toplantiTanimi, DateTime olusturmaTarihi, string acikla);
        string ToplantiTanimiSil(int toplantiTanimlarId);

        List<ToplantiTanimi> ToplantiTanimiListesi();

        string MusteriToplantilariKaydet(DateTime tarih, int musteriId, int personelId, int toplantiTanimId, string saat, string aciklama);
        string MusteriToplantilariGuncelle(int MusteriToplantilariId, DateTime tarih, string saat, string aciklama);
        string MusteriToplantilariSil(int MusteriToplantilariId);

        List<MusteriToplantilari> MusteriToplantilarListesi();
    }
}
