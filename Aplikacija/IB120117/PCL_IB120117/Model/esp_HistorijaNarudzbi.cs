using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
  public  class esp_HistorijaNarudzbi
    {
        public int NarudzbaID { get; set; }
        public int NarudzbaID1 { get; set; }
        public int NarudzbaStavkeID { get; set; }
        public string DatumNarudzbe { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Nullable<decimal> Iznos { get; set; }
        public string StatusNarudzbe { get; set; }
    }
}
