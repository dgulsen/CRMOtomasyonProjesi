//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OyunCRM.DataBaseLogicLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class MusteriSiparisDetay
    {
        public int MusteriSiparisDetaylariID { get; set; }
        public int MusteriSiparisID { get; set; }
        public int UrunID { get; set; }
        public decimal Fiyat { get; set; }
        public int Miktar { get; set; }
        public Nullable<decimal> IndirimOrani { get; set; }
        public string Aciklama { get; set; }
    
        public virtual MusteriSiparisleri MusteriSiparisleri { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}
