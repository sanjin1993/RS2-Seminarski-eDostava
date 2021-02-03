using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_IB120117.Models;

namespace API_IB120117.Controllers
{
    public class NarudzbeController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Narudzbe
        [HttpGet]

        [Route("api/Narudzbe/GetNarudzbe")]
        public List<esp_AllNarudzbe_Result> GetNarudzbe()
        {
            return db.esp_AllNarudzbe().ToList();
        }
        [HttpGet]
        [ResponseType(typeof(Narudzbe))]

        [Route("api/Narudzbe/NarudzbeDateOdDateDo/{datumOd?}/{datumDo?}")]
        public List<esp_AllNarudzbeDatumi_Result> NarudzbeDateOdDateDo(DateTime? datumOd, DateTime? datumDo)
        {
            return db.esp_AllNarudzbeDatumi(datumOd, datumDo).ToList();
        }
        [HttpGet]
        [Route("api/Narudzbe/AllIsporuceni/{datumOd?}/{datumDo?}/{status}")]
        public List<esp_AllNarudzbeStatusDatumi_Result> AllIsporuceni(DateTime? datumOd, DateTime? datumDo,bool status)
        {
            return db.esp_AllNarudzbeStatusDatumi(datumOd, datumDo,status).ToList();
        }
        
              [HttpGet]
        [ResponseType(typeof(Narudzbe))]

        [Route("api/Narudzbe/Report/{klijentID?}/{status?}/{datumOd?}/{datumDo?}")]
        public List<esp_Narudzbe_DateOdDateDoREPORT_Result> Report(int klijentID, bool status,DateTime? datumOd, DateTime? datumDo)
        {
            return db.esp_Narudzbe_DateOdDateDoREPORT(klijentID, status, datumOd, datumDo).ToList();
        }
        [HttpGet]
        [Route("api/Narudzbe/Isporuci/{naruzbaID}")]
        public int Isporuci(int naruzbaID)
        {
            return db.esp_SetIsporuceno(naruzbaID);
        }
        // GET: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult GetNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            return Ok(narudzbe);
        }

        // PUT: api/Narudzbe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzbe(int id, Narudzbe narudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzbe.NarudzbaID)
            {
                return BadRequest();
            }

            db.Entry(narudzbe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/Narudzbe/NarudzbaZadnja")]

        public esp_Narudzba_Zadnja_Result NarudzbaZadnja()
        {
            return db.esp_Narudzba_Zadnja().FirstOrDefault();
        }
        // POST: api/Narudzbe
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult PostNarudzbe(Narudzbe narudzbe)
        {
            db.esp_Narudzbe_Insert(narudzbe.BrojNarudzbe, narudzbe.KlijentID, narudzbe.Datum).FirstOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = narudzbe.NarudzbaID }, narudzbe);
        }
        [HttpGet]
        [Route("api/Narudzbe/Historija/{klijentID?}")]

        public List<esp_HistorijaNarudzbi2_Result> Historija(int klijentID)
        {
            return db.esp_HistorijaNarudzbi2(klijentID).ToList();


        }

        // DELETE: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult DeleteNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            db.Narudzbe.Remove(narudzbe);
            db.SaveChanges();

            return Ok(narudzbe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbeExists(int id)
        {
            return db.Narudzbe.Count(e => e.NarudzbaID == id) > 0;
        }
    }
}