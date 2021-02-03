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
    public class NaseljaKlijentiController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/NaseljaKlijenti
        public IQueryable<NaseljaKlijenti> GetNaseljaKlijentis()
        {
            return db.NaseljaKlijenti;
        }

        // GET: api/NaseljaKlijenti/5
        [ResponseType(typeof(NaseljaKlijenti))]
        public IHttpActionResult GetNaseljaKlijenti(int id)
        {
            NaseljaKlijenti naseljaKlijenti = db.NaseljaKlijenti.Find(id);
            if (naseljaKlijenti == null)
            {
                return NotFound();
            }

            return Ok(naseljaKlijenti);
        }

        // PUT: api/NaseljaKlijenti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNaseljaKlijenti(int id, NaseljaKlijenti naseljaKlijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != naseljaKlijenti.NaseljaKlijentiID)
            {
                return BadRequest();
            }

            db.esp_UpadateNaseljaKlijenti(id, naseljaKlijenti.KlijentID, naseljaKlijenti.NaseljeID);


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaseljaKlijentiExists(id))
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

        // POST: api/NaseljaKlijenti
        [ResponseType(typeof(NaseljaKlijenti))]
        public IHttpActionResult PostNaseljaKlijenti(NaseljaKlijenti naseljaKlijenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_InsertNaseljeKlijenti2(naseljaKlijenti.NaseljeID, naseljaKlijenti.KlijentID);

            return CreatedAtRoute("DefaultApi", new { id = naseljaKlijenti.NaseljaKlijentiID }, naseljaKlijenti);
        }

        // DELETE: api/NaseljaKlijenti/5
        [ResponseType(typeof(NaseljaKlijenti))]
        public IHttpActionResult DeleteNaseljaKlijenti(int id)
        {
            NaseljaKlijenti naseljaKlijenti = db.NaseljaKlijenti.Find(id);
            if (naseljaKlijenti == null)
            {
                return NotFound();
            }

            db.NaseljaKlijenti.Remove(naseljaKlijenti);
            db.SaveChanges();

            return Ok(naseljaKlijenti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NaseljaKlijentiExists(int id)
        {
            return db.NaseljaKlijenti.Count(e => e.NaseljaKlijentiID == id) > 0;
        }
    }
}