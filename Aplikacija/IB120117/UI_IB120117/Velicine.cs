using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_IB120117
{
 public   class Velicine
    {
        public Velicine()
        {
        }

        public Velicine(string Naziv, string Cijena)
        {
            this.Naziv = Naziv;
            this.Cijena = Cijena;
        }
        public string Naziv { set; get; }
        public string Cijena { set; get; }
    }
}
