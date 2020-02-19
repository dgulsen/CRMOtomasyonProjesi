using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IMusteriOdemeleri
    {
        string MusteriOdemesiKaydet(int odemesekliid, DateTime odemetarihi, decimal odenecekmiktar, string aciklama, int musteriid, string bankaadi);
        string MusteriOdemeGuncelle(int musteriodemeleriid, int odemesekliid, DateTime odemetarihi, decimal odenecekmiktar, string aciklama, int musteriid, string bankaadi);
        string MusteriOdemeSil(int musteriodemeleriid);
        List<MusteriOdemeleri> MusteriOdemeleriListesi();
        string OdemeSekliAdiGetir(int id);
    }
}
