
using PCL_IB120117.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile_IB120117
{
  public  class Global
    {
        public static Klijenti prijavljeniKlijent { get; set; }
        public static NaseljaKlijenti prijavljeniKlijentNaselje { get; set; }
        public static PCL_IB120117.Model.Narudzbe AktivnaNarudzba { get; set; }

        #region API Routes

        public const string JelaRoute = "api/Jela";
        public const string KlijentiRoute = "api/Klijenti";
        public const string KlijentisRoute = "api/Klijentis";
        public const string KomentariRoute = "api/Komentari";
        public const string KorisniciRoute = "api/Korisnici";
        public const string OcjeneRoute = "api/Ocjene";
        public const string NarudzbeRoute = "api/Narudzbe";
        public const string NarudzbaStavkeRoute = "api/NarudzbaStavke";
        public const string NaseljaRoute = "api/Naselja";
        public const string NaseljaKlijentiRoute = "api/NaseljaKlijenti";
        public const string RestoraniRoute = "api/Restorani";
        public const string VelicinaJelaRoute = "api/VelicinaJela";
        public const string UlogeRoute = "api/Uloge";
        public const string VrstaJelaRoute = "api/VrstaJela";
        public const string VelicinaJelaTabelaRoute = "api/VelicinaJelaTabela";

        #endregion
    }
}
