using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
   public class Ocjene
    {
        public int OcjenaID { get; set; }
        public System.DateTime Datum { get; set; }
        public int Ocjena { get; set; }
        public int JeloID { get; set; }
        public int KlijentID { get; set; }

    }
}
