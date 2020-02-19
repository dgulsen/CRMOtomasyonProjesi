using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IPersonelToplantilari
    {
        string PersonelToplantilarKaydet(int toplantiTanimiID, int personelID, DateTime tarih, string saat, string aciklama);
        string PersonelToplantilarGuncelle(int personelToplantilariID, int toplantiTanimiID, int personelID, DateTime tarih, string saat, string aciklama);
        string PersonelToplantilarSil(int personelToplantilariID);
        List<PersonelToplantilari> PersonelToplantilarListesi();
    }
}
