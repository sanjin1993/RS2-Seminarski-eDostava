//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_IB120117.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VelicinaJela
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VelicinaJela()
        {
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
            this.VelicinaJelaTabela = new HashSet<VelicinaJelaTabela>();
        }
    
        public int VelicinaJelaID { get; set; }
        public string Naziv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VelicinaJelaTabela> VelicinaJelaTabela { get; set; }
    }
}
