//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poseduje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poseduje()
        {
            this.Brodogradiliste = new HashSet<Brodogradiliste>();
        }
    
        public System.Guid IDBroda { get; set; }
        public System.Guid BrLin { get; set; }
    
        public virtual Brod Brod { get; set; }
        public virtual Brodska_Linija Brodska_Linija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brodogradiliste> Brodogradiliste { get; set; }
    }
}
