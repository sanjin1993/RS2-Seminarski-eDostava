using API_IB120117.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_IB120117
{
    public class Preporuka
    {
        Dictionary<int?, List<Ocjene>> jelo = new Dictionary<int?, List<Ocjene>>();
        private IB120117Entities db = new IB120117Entities();


        public List<PreporukaRestorana_Result> GetSlicnost(int JeloID)
        {
            UcitajKupce(JeloID);
            List<Ocjene> ocjene = db.Ocjene.Where(x => x.JeloID == JeloID).OrderBy(x => x.KlijentID).ToList();

            List<Ocjene> zajednickeOcjene1 = new List<Ocjene>();
            List<Ocjene> zajednickeOcjene2 = new List<Ocjene>();

            List<PreporukaRestorana_Result> preporuceno = new List<PreporukaRestorana_Result>();


            foreach (var item in jelo)
            {
                foreach (Ocjene o in ocjene)
                {

                    if (item.Value.Where(x => x.KlijentID == o.KlijentID).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.KlijentID == o.KlijentID).First());
                    }
                }


                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);
                if (slicnost > 0.6)
                    preporuceno.Add(db.PreporukaRestorana(item.Key).FirstOrDefault());


                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }


            return preporuceno;
        }


        private void UcitajKupce(int JeloID)
        {
            List<Jela> aktivnaJela = db.Jela.Where(x => x.JeloID != JeloID).ToList();

            List<Ocjene> ocjene;
            foreach (Jela k in aktivnaJela)
            {
                ocjene = db.Ocjene.Where(x => x.JeloID == k.JeloID).OrderBy(x => x.KlijentID).ToList();
                if (ocjene.Count > 0)
                    jelo.Add(k.JeloID, ocjene);

            }
        }


        double GetSlicnost(List<Ocjene> ocjene1, List<Ocjene> ocjene2)
        {
            if (ocjene1.Count != ocjene2.Count)
                return 0;

            int? brojnik = 0;
            int? int1 = 0;
            int? int2 = 0;

            for (int i = 0; i < ocjene1.Count; i++)
            {
                brojnik += ocjene1[i].Ocjena * ocjene2[i].Ocjena;
                int1 += ocjene1[i].Ocjena * ocjene1[i].Ocjena;
                int2 += ocjene2[i].Ocjena * ocjene2[i].Ocjena;
            }

            double int11 = Math.Sqrt(Convert.ToDouble(int1));
            double int22 = Math.Sqrt(Convert.ToDouble(int2));

            double nazivnik = int11 * int22;
            double brojnik1 = Convert.ToDouble(brojnik);
            if (nazivnik != 0)
                return brojnik1 / nazivnik;

            return 0;

        }
    }
}
    