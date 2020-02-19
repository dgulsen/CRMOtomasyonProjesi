using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IPersonelMaaslari
    {
        string PersonelMaasBilgilerKaydet(int personelID, decimal maas, DateTime baslangicTarihi, DateTime bitisTarihi, string aciklama);
        string PersonelMaasBilgilerGuncelle(int personelMaaslarID, int personelID, decimal maas, DateTime baslangicTarihi, DateTime bitisTarihi, string aciklama);
        string PersonelMaasBilgilerSil(int personelMaaslarID);
        List<PesonelMaasBilgiler> PersonelMaasBilgilerListesi();

    }
}
