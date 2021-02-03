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
    public class KlijentisController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Klijentis
        public IQueryable<Klijenti> GetKlijenti()
        {
            return db.Klijenti;
        }

        // GET: api/Klijentis/5
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

        // PUT: api/Klijentis/5
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

            db.Entry(klijenti).State = EntityState.Modified;

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

        // POST: api/Klijentis
        [ResponseType(typeof(Klijenti))]
   

        // DELETE: api/Klijentis/5
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