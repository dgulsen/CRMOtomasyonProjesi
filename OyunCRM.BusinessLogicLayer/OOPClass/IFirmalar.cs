using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IFirmalar
    {
        string FirmaKaydet(string adi, bool durumu, string aciklama, DateTime kayittarihi, int personelıd, string telefon, string email);

        string FirmaGuncelle(int firmalarId, string adi, bool durumu, string aciklama, DateTime kayittarihi, int personelıd, string telefon, string email);

        string FirmaSil(int firmalarId);

        List<Firmalar> FirmaListesi();
        List<Firmalar> FirmaListesi(string adi);
    }
}