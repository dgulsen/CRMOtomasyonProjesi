using OyunCRM.DataBaseLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class OrtakClass
    {
        OyunCRMDBEntities db = new OyunCRMDBEntities();
        //tablo adı doğru yazılınca ctrl+. denilerek using kısmına kütüphane eklenebilir ama References alanına eklenmişse :))
        public List<iller> illerListesi()
        {
            return db.iller.ToList();
        }

        
        public int ilPlakaKoduBul(string iladi)
        {

            return db.iller.Where(k => k.ilAdi == iladi).FirstOrDefault().PlakaKodu;
        }
        public List<Ulkeler> UlkelerListesi()
        {
            return db.Ulkeler.ToList();
        }
        public List<Musteriler> MusterilerIdListesi()
        {
            return db.Musteriler.ToList();
        }
        public List<ilceler> ilcelerListesi(int plakaKodu)
        {
            return db.ilceler.Where(k => k.PlakaKodu == plakaKodu).ToList();
        }
        public List<OdemeSekli> OdemeSekliListesi()
        {
            return db.OdemeSekli.ToList();
        }

    }
}
