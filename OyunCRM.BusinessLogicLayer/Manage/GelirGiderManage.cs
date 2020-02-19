using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunCRM.BusinessLogicLayer.OOPClass;
using OyunCRM.DataBaseLogicLayer;
namespace OyunCRM.BusinessLogicLayer.Manage
{
    public class GelirGiderManage : IGelirler, IGiderler
    {


            OyunCRMDBEntities db = new OyunCRMDBEntities();

            //********************************************************************GELİRLER***********************************************************************
            #region GELİRLER

            //public int GelirIDGetir(string GelirId)
            //{
            //  / var Id = db.Gelirler.FirstOrDefault(k => k.GelirlerID == GelirId).GelirlerID;
            //    return Id;
            //}

            public string GelirGuncelle(int gelirlerId, int gelirtipId, decimal gelirmiktari, string geliraciklama, decimal urunsatisfiyati, DateTime gelirislemsaati)
            {
                try
                {


                    if (!string.IsNullOrWhiteSpace(gelirmiktari.ToString()) && !string.IsNullOrWhiteSpace(urunsatisfiyati.ToString()) && !
                       string.IsNullOrWhiteSpace(gelirtipId.ToString()))
                    {
                        var guncelle = db.Gelirler.FirstOrDefault(k => k.GelirlerID == gelirlerId);

                        if (guncelle != null)
                        {
                            guncelle.GelirTipID = gelirtipId;
                            guncelle.GelirMiktari = gelirmiktari;
                            guncelle.GelirAciklama = geliraciklama;
                            guncelle.UrunSatisFiyati = urunsatisfiyati;
                            guncelle.GelirislemSaati = gelirislemsaati;


                            if (db.SaveChanges() > 0)
                            {
                                return "gelir basariyla guncellendi";
                            }
                            return "gunceleniren hata olustu";
                        }

                        return "secim yapmadiniz";

                    }
                    return "Boş alanları doldurun";

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }

            public string GelirKaydet(int gelirtipId, decimal gelirmiktari, string geliraciklama, decimal urunsatisfiyati, DateTime gelirislemsaati)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(gelirmiktari.ToString()) && !string.IsNullOrWhiteSpace(urunsatisfiyati.ToString()) && !string.IsNullOrWhiteSpace(gelirtipId.ToString()))
                    {
                        Gelirler ekle = new Gelirler();

                        ekle.GelirTipID = gelirtipId;
                        ekle.GelirMiktari = gelirmiktari;
                        ekle.GelirAciklama = geliraciklama;
                        ekle.UrunSatisFiyati = urunsatisfiyati;
                        ekle.GelirislemSaati = gelirislemsaati;

                        db.Gelirler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "gelir basariyla eklendi";
                        }


                    }
                    return "Boş alanları doldurun";

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }

            public List<Gelirler> GelirListesi()
            {
                return db.Gelirler.ToList();
            }

            public string GelirSil(int gelirlerID)
            {
                try
                {
                    if (gelirlerID > 0)
                    {
                        Gelirler sil = db.Gelirler.Where(k => k.GelirlerID == gelirlerID).FirstOrDefault();
                        db.Gelirler.Remove(sil);

                        if (db.SaveChanges() > 0)
                        {
                            gelirlerID = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                            return sil.GelirlerID + " başarılı bir şekilde silindi";
                        }
                        return "Silme başarısız oldu";
                    }
                    return "Seçim yapmadınız";
                }
                catch (Exception es)
                {
                    return es.Message;
                }
            }

            public List<GelirTipleri> GelirTipleriListesi()
            {
                return db.GelirTipleri.ToList();
            }


            // GelirTipleri glrtplr = new GelirTipleri();

            public int GelirTipiIDGetir(string gelirtipiadi)
            {
                var Id = db.GelirTipleri.FirstOrDefault(k => k.GelirTipAdi == gelirtipiadi).GelirTipleriID;
                return Id;
            }


            //public void GelirTipleriListesi(ComboBox cmbgelirtipleri)
            //{
            //    glrtplr.DisplayMember = "ilAdi";
            //    glrtplr.ValueMember = "PlakaKodu";
            //    glrtplr.DataSource = ortak.illerListesi();
            //}

            #endregion

            //*****************************************************************************************************************************************************


            //***************************************************************GIDERLER******************************************************************************
            #region GİDERLER

            public string GiderGuncelle(int giderlerId, int gidertipId, decimal gidermiktar, string aciklama, decimal urunalisfiyati, DateTime giderislemsaati)
            {
                try
                {


                    if (!string.IsNullOrWhiteSpace(gidermiktar.ToString()) && !string.IsNullOrWhiteSpace(urunalisfiyati.ToString()) && !
                       string.IsNullOrWhiteSpace(gidertipId.ToString()))
                    {
                        var guncelle = db.Giderler.FirstOrDefault(k => k.GiderlerID == giderlerId);

                        if (guncelle != null)
                        {
                            guncelle.GiderTipID = gidertipId;
                            guncelle.GiderMiktar = gidermiktar;
                            guncelle.Aciklama = aciklama;
                            guncelle.UrunalisFiyati = urunalisfiyati;
                            guncelle.GiderislemSaati = giderislemsaati;


                            if (db.SaveChanges() > 0)
                            {
                                return "gider basariyla guncellendi";
                            }
                            return "gunceleniren hata olustu";
                        }

                        return "secim yapmadiniz";

                    }
                    return "Boş alanları doldurun";

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }

            public string GiderKaydet(int gidertipId, decimal gidermiktar, string aciklama, decimal urunalisfiyati, DateTime giderislemsaati)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(gidermiktar.ToString()) && !string.IsNullOrWhiteSpace(urunalisfiyati.ToString()) && !string.IsNullOrWhiteSpace(gidertipId.ToString()))
                    {
                        Giderler ekle = new Giderler();

                        ekle.GiderTipID = gidertipId;
                        ekle.GiderMiktar = gidermiktar;
                        ekle.Aciklama = aciklama;
                        ekle.UrunalisFiyati = urunalisfiyati;
                        ekle.GiderislemSaati = giderislemsaati;

                        db.Giderler.Add(ekle);
                        if (db.SaveChanges() > 0)
                        {
                            return "gelir basariyla eklendi";
                        }


                    }
                    return "Boş alanları doldurun";

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }

            public List<Giderler> GiderListesi()
            {
                return db.Giderler.ToList();
            }

            public string GiderSil(int giderlerID)
            {
                try
                {
                    if (giderlerID > 0)
                    {
                        Giderler sil = db.Giderler.Where(k => k.GiderlerID == giderlerID).FirstOrDefault();
                        db.Giderler.Remove(sil);

                        if (db.SaveChanges() > 0)
                        {
                            giderlerID = 0;//Silme başarılı ise ID değerini hatalara neden olmasın diye 0 a eşitliyoruz
                            return sil.GiderlerID + " başarılı bir şekilde silindi";
                        }
                        return "Silme başarısız oldu";
                    }
                    return "Seçim yapmadınız";
                }
                catch (Exception es)
                {
                    return es.Message;
                }
            }

            public List<GiderTipleri> GiderTipleriListesi()
            {
                return db.GiderTipleri.ToList();
            }


            GiderTipleri gdrtplr = new GiderTipleri();
            public int GiderTipiIDGetir(string gidertipiadi)
            {
                var Id = db.GiderTipleri.FirstOrDefault(k => k.GiderAdi == gidertipiadi).GiderTipleriID;
                return Id;
            }

            #endregion

            //*****************************************************************************************************************************************************



        }

    }

