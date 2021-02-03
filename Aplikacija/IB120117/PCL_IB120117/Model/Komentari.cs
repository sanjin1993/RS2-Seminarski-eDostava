using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
  public  class Komentari
    {
        public int KomenatarID { get; set; }
        public string Komentar { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public int JeloID { get; set; }
        public int KlijentID { get; set; }

    }
}
