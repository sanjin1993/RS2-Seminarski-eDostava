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
    
    public partial class esp_Narudzbe_DateOdDateDo_Result
    {
        public int NarudzbaID { get; set; }
        public int KlijentID { get; set; }
        public string DatumNarudzbe { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Nullable<decimal> Iznos { get; set; }
        public string StatusNarudzbe { get; set; }
    }
}
