using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;


namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IGunlukTakip
    {
        string gunlukTakipEkle(int PersonelID, DateTime GirisSaati, DateTime CikisSaati, string Aciklama);
        string GunlukTakipGuncelle(int PersonleGunlukTakipID, DateTime GirisSaati, DateTime CikisSaati, string Aciklama);
        string GunlukTakipSil(int PersonelgunlukTakipID);
        List<PersonelGunlukTakip> PersonelGunlukTakips();
    }
}
