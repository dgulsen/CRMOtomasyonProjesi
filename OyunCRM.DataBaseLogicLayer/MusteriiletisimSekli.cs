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
    
    public partial class MusteriiletisimSekli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MusteriiletisimSekli()
        {
            this.MusteriGorusmeleri = new HashSet<MusteriGorusmeleri>();
        }
    
        public int MusteriiletisimSekilleriID { get; set; }
        public int MusteriID { get; set; }
        public Nullable<bool> Telefon { get; set; }
        public Nullable<bool> Mail { get; set; }
        public Nullable<bool> Fax { get; set; }
        public string Aciklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusteriGorusmeleri> MusteriGorusmeleri { get; set; }
        public virtual Musteriler Musteriler { get; set; }
    }
}
