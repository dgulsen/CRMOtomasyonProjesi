using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IUrunler
    {
        string UrunKaydet(string adi, int kategoriId, string birimMiktar, decimal birimFiyat, string aciklama);
        string UrunGuncelle(int urunlerId, string adi, int urunKategoriId, string birimMiktar, decimal birimFiyat, string aciklama);
        string UrunSil(int departmanlarId);

        List<Urunler> UrunListesi();
    }
}
