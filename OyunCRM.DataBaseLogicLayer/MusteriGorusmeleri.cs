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
    
    public partial class MusteriGorusmeleri
    {
        public int MusteriGorusmeleriID { get; set; }
        public int MusteriID { get; set; }
        public Nullable<int> FirmaID { get; set; }
        public int PersonelID { get; set; }
        public int MusteriiletisimSekliID { get; set; }
        public System.DateTime GorusmeTarihi { get; set; }
        public string Aciklama { get; set; }
    
        public virtual Firmalar Firmalar { get; set; }
        public virtual MusteriiletisimSekli MusteriiletisimSekli { get; set; }
        public virtual Musteriler Musteriler { get; set; }
        public virtual Personeller Personeller { get; set; }
    }
}