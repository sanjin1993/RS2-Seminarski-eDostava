using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
   public class esp_JelaByRestoranID_Result
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
    }
}
