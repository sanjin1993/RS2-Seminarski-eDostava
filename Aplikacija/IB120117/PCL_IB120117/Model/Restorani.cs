using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
  public  class Restorani
    {

        public int RestoranID { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public Nullable<bool> Aktivno { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Nullable<int> KorisnikID { get; set; }
    }
}
