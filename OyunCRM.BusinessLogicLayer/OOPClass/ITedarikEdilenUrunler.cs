using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface ITedarikEdilenUrunler
    {
        string TedarikEdilenUrunlerKaydet(int urunid, DateTime tedariktarihi, decimal fiyat, string aciklama, int tedarikciID);
        string TedarikEdilenUrunlerGuncelle(int tedarikedilenurunlerId, int urunid, DateTime tedariktarihi, decimal fiyat, string aciklama, int tedarikciID);
        string TedarikEdilenUrunlerSil(int tedarikedilenurunlerId);
        List<TedarikEdilenUrunler> TedarikEdilenUrunlerListesi();
    }

}
