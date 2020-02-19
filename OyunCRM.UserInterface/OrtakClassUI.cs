using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunCRM.BusinessLogicLayer.Manage;
using OyunCRM.DataBaseLogicLayer;

namespace OyunCRM.UserInterface
{
    class OrtakClassUI
    {
        OrtakClass ortak = new OrtakClass();
        Musteriler musteri_mng = new Musteriler();
        public void illerListesi(ComboBox cmbiller)
        {
            cmbiller.DisplayMember = "ilAdi";
            cmbiller.ValueMember = "PlakaKodu";
            cmbiller.DataSource = ortak.illerListesi();
        }

        public void ilcelerListesi(ComboBox cmbilceler, int plakaKodu)
        {
            cmbilceler.DisplayMember = "ilceAdi";
            cmbilceler.ValueMember = "ilcelerID";
            cmbilceler.DataSource = ortak.ilcelerListesi(plakaKodu);
        }
        public void UlkelerListesi(ComboBox cmbUlkeler)
        {
            cmbUlkeler.DisplayMember = "UlkeAdi";
            cmbUlkeler.ValueMember = "UlkeID";
            cmbUlkeler.DataSource = ortak.UlkelerListesi();
        }

        public int ilPlakaKoduBul(string iladi)
        {

            int plakaKodu = ortak.ilPlakaKoduBul(iladi);
            return plakaKodu;
        }

        OyunCRMDBEntities db = new OyunCRMDBEntities();
        public void MusteriAdiSoyadiListesi(ComboBox cmbMusteri)
        {
            var MusteriAdSoyad = db.Musteriler.Select(k => new
            {
                ID = k.MusterilerID,
                //k.MusterilerID,
                AdSoyad = k.MusteriAdi + " " + k.MusteriSoyadi

            }).ToList();

            //cmbMusteri.ValueMember = "MusterilerID";
            cmbMusteri.ValueMember = "ID";
            cmbMusteri.DisplayMember = "AdSoyad";
            cmbMusteri.DataSource = MusteriAdSoyad;
        }

        UrunlerManage urun_mng = new UrunlerManage();
        public void UrunKategoriListesi(ComboBox cmbUrunKategori)
        {
            cmbUrunKategori.DisplayMember = "UrunKategoriAdi";
            cmbUrunKategori.ValueMember = "UrunKategorileriID";
            cmbUrunKategori.DataSource = urun_mng.UrunKategoriListesi();
        }

		public void musterilistesi(ComboBox cmbmusteri)
		{
			var musteriadsoyad = db.Musteriler.Select(k => new { ID = k.MusterilerID, adsoyad = k.MusteriAdi + " " + k.MusteriSoyadi }).ToList();
			cmbmusteri.DisplayMember = "adsoyad";
			cmbmusteri.ValueMember = "ID";
			cmbmusteri.DataSource = musteriadsoyad;
		}
		public string Mustetilertext(int ID)
		{
			return db.Musteriler.Select(p => new
			{
				MusID = ID,
				Adsoyad = p.MusteriAdi + " " + p.MusteriSoyadi

			}
			   ).Where(k => k.MusID == ID).FirstOrDefault().Adsoyad.ToString();
		}

		public void urunlistesi(ComboBox cmburun
			)
		{
			cmburun.DisplayMember = "UrunAdi";
			cmburun.ValueMember = "UrunlerID";
			cmburun.DataSource = db.Urunler.ToList();

		}
		public void Siparisno(ComboBox cmbsiparis)
		{
			cmbsiparis.DisplayMember = "MusteriSiparisleriID";
			cmbsiparis.ValueMember = "MusteriSiparisleriID";
			cmbsiparis.DataSource = db.MusteriSiparisleri.ToList();
		}

		public string Uruntext(int Id)
		{
			return db.Urunler.Select(p => new
			{
				UID = Id,
				Adsoyad = p.UrunAdi

			}).Where(k => k.UID == Id).FirstOrDefault().Adsoyad;

		}

		public void personellistesi(ComboBox cmbpers)
		{
			var Personeladsoyad = db.Personeller.Select(k => new { ID = k.PersonellerID, adsoyad = k.Adi + " " + k.Soyadi }).ToList();
			cmbpers.DisplayMember = "adsoyad";
			cmbpers.ValueMember = "ID";
			cmbpers.DataSource = Personeladsoyad;


		}

		public string personeltext(int Id)
		{
			return db.Personeller.Select(p => new
			{
				MusID = Id,
				Adsoyad = p.Adi + " " + p.Soyadi

			}).Where(k => k.MusID == Id).FirstOrDefault().Adsoyad;

		}

        public void OdemeSekliListesi(ComboBox cmbOdemeSekli)
        {
            cmbOdemeSekli.DisplayMember = "OdemeAdi";
            cmbOdemeSekli.ValueMember = "OdemeSekilleriID";
            cmbOdemeSekli.DataSource = ortak.OdemeSekliListesi();
        }
        
    }
}
