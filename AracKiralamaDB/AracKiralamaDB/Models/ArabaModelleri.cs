//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracKiralamaDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArabaModelleri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArabaModelleri()
        {
            this.Arabalar = new HashSet<Arabalar>();
        }
    
        public int ArabaModelID { get; set; }
        public Nullable<int> ArabaMarkaID { get; set; }
        public string ArabaModelAdi { get; set; }
    
        public virtual ArabaMarkalari ArabaMarkalari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arabalar> Arabalar { get; set; }
    }
}