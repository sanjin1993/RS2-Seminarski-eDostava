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
    public class KlijentiController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Klijenti
        public List<esp_AllKlijenti_Result> GetKlijentis()
        {
            return db.esp_AllKlijenti().ToList();
        }
        
              [HttpGet]
        //   [ResponseType(typeof(Klijenti))]
        [Route("api/Klijenti/GetKlijentLast")]
        public esp_LastKlijent2_Result GetKlijentLast()
        {
            esp_LastKlijent2_Result k = db.esp_LastKlijent2().FirstOrDefault();
            return k;
        }
        [HttpGet]
        //   [ResponseType(typeof(Klijenti))]
        [Route("api/Klijenti/GetByUserNameKlijent/{KorisnickoIme}")]
        public KlijentByKorisnickoIme1_Result GetByUserNameKlijent(string KorisnickoIme)
        {
            KlijentByKorisnickoIme1_Result k = db.KlijentByKorisnickoIme1(KorisnickoIme).FirstOrDefault();
            return k;
        }
        
              [HttpGet]
        //   [ResponseType(typeof(Klijenti))]
        [Route("api/Klijenti/GetNaseljeIDByKlijentID/{KlijentID}")]
        public esp_NaseljeIDByKlijentID_Result GetNaseljeIDByKlijentID(int KlijentID)
        {
            esp_NaseljeIDByKlijentID_Result k = db.esp_NaseljeIDByKlijentID(KlijentID).FirstOrDefault();
            return k;
        }
        // GET: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult GetKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            return Ok(klijenti);
        }

        // PUT: api/Klijenti/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlijenti(int id, Klijenti klijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klijenti.KlijentID)
            {
                return BadRequest();
            }

            db.esp_UpdateKlijenti(id,klijenti.Ime,klijenti.Prezime,klijenti.Adresa,klijenti.Telefon,klijenti.KorisnickoIme,klijenti.LozinkaSalt,klijenti.LozinkaHash,klijenti.Status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlijentiExists(id))
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
        [HttpPost]
        // POST: api/Klijenti
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult PostKlijenti(Klijenti klijenti)
        {
           
            db.esp_InsertKlijenti2(klijenti.Ime,klijenti.Prezime,klijenti.Telefon,klijenti.Adresa,klijenti.KorisnickoIme,klijenti.LozinkaSalt,klijenti.LozinkaHash,klijenti.Status);

            return CreatedAtRoute("DefaultApi", new { id = klijenti.KlijentID }, klijenti);
        }

        // DELETE: api/Klijenti/5
        [ResponseType(typeof(Klijenti))]
        public IHttpActionResult DeleteKlijenti(int id)
        {
            Klijenti klijenti = db.Klijenti.Find(id);
            if (klijenti == null)
            {
                return NotFound();
            }

            db.Klijenti.Remove(klijenti);
            db.SaveChanges();

            return Ok(klijenti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlijentiExists(int id)
        {
            return db.Klijenti.Count(e => e.KlijentID == id) > 0;
        }
    }
}