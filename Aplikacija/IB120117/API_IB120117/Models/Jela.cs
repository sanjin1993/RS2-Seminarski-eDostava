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
    
    public partial class Jela
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jela()
        {
            this.Komentari = new HashSet<Komentari>();
            this.NarudzbaStavke = new HashSet<NarudzbaStavke>();
            this.Ocjene = new HashSet<Ocjene>();
            this.VelicinaJelaTabela = new HashSet<VelicinaJelaTabela>();
        }
    
        public int JeloID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Nullable<bool> Aktivno { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int KorisnikID { get; set; }
        public int RestoranID { get; set; }
        public int VrsteJelaID { get; set; }
    
        public virtual Korisnici Korisnici { get; set; }
        public virtual Restorani Restorani { get; set; }
        public virtual VrsteJela VrsteJela { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Komentari> Komentari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocjene> Ocjene { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VelicinaJelaTabela> VelicinaJelaTabela { get; set; }
    }
}