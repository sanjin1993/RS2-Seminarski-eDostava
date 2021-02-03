using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
  public  class Narudzbe
    {
        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> Otkazana { get; set; }
        public int KlijentID { get; set; }

        public virtual ICollection<NarudzbeStavke> NarudzbaStavke { get; set; }
    }
}
