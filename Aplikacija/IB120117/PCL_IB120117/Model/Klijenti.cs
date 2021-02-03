using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL_IB120117.Model
{
    public class Klijenti
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Telefon { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Adresa { get; set; }
    }
}
