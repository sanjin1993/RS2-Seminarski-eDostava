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
    public class NaseljaController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Naselja
        [HttpGet]
        [Route("api/Naselja/getNaselja")]
        public List<esp_AllNaselja_Result> getNaselja()
        {
            return db.esp_AllNaselja().ToList();
        }


        // GET: api/Naselja/5
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult GetNaselja(int id)
        {
            Naselja naselja = db.Naselja.Find(id);
            if (naselja == null)
            {
                return NotFound();
            }

            return Ok(naselja);
        }

        // PUT: api/Naselja/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNaselja(int id, Naselja naselja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != naselja.NaseljeID)
            {
                return BadRequest();
            }

            db.Entry(naselja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaseljaExists(id))
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

        // POST: api/Naselja
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult PostNaselja(Naselja naselja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Naselja.Add(naselja);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = naselja.NaseljeID }, naselja);
        }

        // DELETE: api/Naselja/5
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult DeleteNaselja(int id)
        {
            Naselja naselja = db.Naselja.Find(id);
            if (naselja == null)
            {
                return NotFound();
            }

            db.Naselja.Remove(naselja);
            db.SaveChanges();

            return Ok(naselja);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NaseljaExists(int id)
        {
            return db.Naselja.Count(e => e.NaseljeID == id) > 0;
        }
    }
}