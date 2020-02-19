using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.OOPClass
{
    interface IMusteriiletisim
    {
        string iletisimKaydet(int musteriId, bool telefon, bool mail, bool fax, string aciklama);

        string iletisimGuncelle(int iletisimSekliId, int musteriId, bool telefon, bool mail, bool fax, string aciklama);

        string iletisimSil(int iletisimSekliId);

        List<MusteriiletisimSekli> iletisimListesi();
        List<MusteriiletisimSekli> iletisimListesi(int musteriId);
    }
}
