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
    public class KomentariController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Komentari
        public List<esp_AllKomentariOcjene_Result> GetKomentari()
        {
            return db.esp_AllKomentariOcjene().ToList();
        }

        // GET: api/Komentari/5
        [ResponseType(typeof(Komentari))]
        public IHttpActionResult GetKomentari(int id)
        {
            Komentari komentari = db.Komentari.Find(id);
            if (komentari == null)
            {
                return NotFound();
            }

            return Ok(komentari);
        }

        // PUT: api/Komentari/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKomentari(int id, Komentari komentari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komentari.KomenatarID)
            {
                return BadRequest();
            }

            db.Entry(komentari).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentariExists(id))
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

        // POST: api/Komentari
        [ResponseType(typeof(Komentari))]
        public IHttpActionResult PostKomentari(Komentari komentari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_InsertKomentari1(komentari.JeloID,komentari.KlijentID,komentari.Datum,komentari.Komentar);

            return CreatedAtRoute("DefaultApi", new { id = komentari.KomenatarID }, komentari);
        }

        // DELETE: api/Komentari/5
        [ResponseType(typeof(Komentari))]
        public IHttpActionResult DeleteKomentari(int id)
        {
            Komentari komentari = db.Komentari.Find(id);
            if (komentari == null)
            {
                return NotFound();
            }

            db.Komentari.Remove(komentari);
            db.SaveChanges();

            return Ok(komentari);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KomentariExists(int id)
        {
            return db.Komentari.Count(e => e.KomenatarID == id) > 0;
        }
    }
}