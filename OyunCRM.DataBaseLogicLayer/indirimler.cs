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
    
    public partial class indirimler
    {
        public int indirimlerID { get; set; }
        public string indirimTurAdi { get; set; }
        public string indirimFiyatSekli { get; set; }
        public System.DateTime BaslamaTarihi { get; set; }
        public System.TimeSpan BitisTarihi { get; set; }
        public decimal indirimMiktari { get; set; }
        public Nullable<bool> Durumu { get; set; }
        public string Aciklama { get; set; }
    }
}
