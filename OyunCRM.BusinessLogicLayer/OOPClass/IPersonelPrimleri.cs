using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IPersonelPrimleri
    {
        string PersonelPrimlerKaydet(int personelID, int primGunSayisi, string aciklama);
        string PersonelPrimlerGuncelle(int personelPrimlerID, int personelID, int primGunSayisi, string aciklama);
        string PersonelPrimlerSil(int personelPrimlerID);
        List<PersonelPrimler> PersonelPrimlerListesi();
    }
}

