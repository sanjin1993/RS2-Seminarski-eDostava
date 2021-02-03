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
    public class NarudzbaStavkeController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/NarudzbaStavke
        public IQueryable<NarudzbaStavke> GetNarudzbaStavke()
        {
            return db.NarudzbaStavke;
        }
        
               [HttpGet]
        [Route("api/NarudzbaStavke/StavkeNarudzbe/{naruzbaID}")]
        public List<esp_AllNarudzbeStavkeByNarudzba_Result> StavkeNarudzbe(int naruzbaID)
        {
            return db.esp_AllNarudzbeStavkeByNarudzba(naruzbaID).ToList();
        }


        [HttpGet]
        [Route("api/NarudzbaStavke/KlijentNarudzba/{naruzbaID}")]
        public esp_PodaciOKlijentuNarudzbeStavkeByNarudzba1_Result KlijentNarudzba(int naruzbaID)
        {
            return db.esp_PodaciOKlijentuNarudzbeStavkeByNarudzba1(naruzbaID).FirstOrDefault();
        }
        // GET: api/NarudzbaStavke/5
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult GetNarudzbaStavke(int id)
        {
            NarudzbaStavke narudzbaStavke = db.NarudzbaStavke.Find(id);
            if (narudzbaStavke == null)
            {
                return NotFound();
            }

            return Ok(narudzbaStavke);
        }

        // PUT: api/NarudzbaStavke/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzbaStavke(int id, NarudzbaStavke narudzbaStavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzbaStavke.NarudzbaStavkeID)
            {
                return BadRequest();
            }

            db.Entry(narudzbaStavke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaStavkeExists(id))
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

        // POST: api/NarudzbaStavke
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult PostNarudzbaStavke(NarudzbaStavke narudzbaStavke)
        {

            db.esp_NarudzbaStavke_Insert(narudzbaStavke.NarudzbaID, narudzbaStavke.JeloID, narudzbaStavke.Kolicina,narudzbaStavke.VelicinaJelaID);
            return CreatedAtRoute("DefaultApi", new { id = narudzbaStavke.NarudzbaStavkeID }, narudzbaStavke);
        }

        // DELETE: api/NarudzbaStavke/5
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult DeleteNarudzbaStavke(int id)
        {
            NarudzbaStavke narudzbaStavke = db.NarudzbaStavke.Find(id);
            if (narudzbaStavke == null)
            {
                return NotFound();
            }

            db.NarudzbaStavke.Remove(narudzbaStavke);
            db.SaveChanges();

            return Ok(narudzbaStavke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaStavkeExists(int id)
        {
            return db.NarudzbaStavke.Count(e => e.NarudzbaStavkeID == id) > 0;
        }
    }
}