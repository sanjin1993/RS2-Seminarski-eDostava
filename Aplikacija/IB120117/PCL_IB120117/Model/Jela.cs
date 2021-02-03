using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
  public  class Jela
    {
        public int JeloID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public Nullable<bool> Aktivno { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public int KorisnikID { get; set; }
        public int RestoranID { get; set; }
        public int VrsteJelaID { get; set; }
        
        public virtual Restorani Restorani { get; set; }
        public virtual VrsteJela VrsteJela { get; set; }
    }
}
