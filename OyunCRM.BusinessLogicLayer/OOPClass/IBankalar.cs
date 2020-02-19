using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IBankalar
    {
        string BankaKaydet(string adi);
        string BankaGuncelle(int bankalarId, string adi);
        string BankaSil(int bankalarId);
        List<Bankalar> BankaListesi();
    }
}
