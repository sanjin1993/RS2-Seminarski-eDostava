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
    public class VrsteJelaController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/VrsteJela
        public List<esp_VrsteJelaAll_Result> GetVrsteJelas()
        {
            return db.esp_VrsteJelaAll().ToList(); ;
        }

        // GET: api/VrsteJela/5
        [ResponseType(typeof(VrsteJela))]
        public IHttpActionResult GetVrsteJela(int id)
        {
            VrsteJela vrsteJela = db.VrsteJela.Find(id);
            if (vrsteJela == null)
            {
                return NotFound();
            }

            return Ok(vrsteJela);
        }

        // PUT: api/VrsteJela/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVrsteJela(int id, VrsteJela vrsteJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vrsteJela.VrsteJelaID)
            {
                return BadRequest();
            }

            db.Entry(vrsteJela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VrsteJelaExists(id))
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

        // POST: api/VrsteJela
        [ResponseType(typeof(VrsteJela))]
        public IHttpActionResult PostVrsteJela(VrsteJela vrsteJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VrsteJela.Add(vrsteJela);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vrsteJela.VrsteJelaID }, vrsteJela);
        }

        // DELETE: api/VrsteJela/5
        [ResponseType(typeof(VrsteJela))]
        public IHttpActionResult DeleteVrsteJela(int id)
        {
            VrsteJela vrsteJela = db.VrsteJela.Find(id);
            if (vrsteJela == null)
            {
                return NotFound();
            }

            db.VrsteJela.Remove(vrsteJela);
            db.SaveChanges();

            return Ok(vrsteJela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VrsteJelaExists(int id)
        {
            return db.VrsteJela.Count(e => e.VrsteJelaID == id) > 0;
        }
    }
}