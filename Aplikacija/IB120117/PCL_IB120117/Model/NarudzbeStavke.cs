using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
 public   class NarudzbeStavke
    {
        public int NarudzbaStavkeID { get; set; }
        public int NarudzbaID { get; set; }
        public int JeloID { get; set; }
        public int Kolicina { get; set; }
        public Nullable<int> VelicinaJelaID { get; set; }

        public virtual Jela Jela { get; set; }
        public virtual VelicinaJela VelicinaJela { get; set; }

    }
}
