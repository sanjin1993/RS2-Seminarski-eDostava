using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
   public class esp_VelicinaJelaByJeloID_Result
    {
        public int VelicinaJelaID { get; set; }
        public string Naziv { get; set; }
        public Nullable<decimal> Cijena { get; set; }
        public int JeloID { get; set; }
    }
}
