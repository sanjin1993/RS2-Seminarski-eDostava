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
    public class VelicinaJelaController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/VelicinaJela
        [HttpGet]
        [Route("api/VelicinaJela/GetVelicinaJelas")]
        public List<esp_VelicinaJelaAll_Result> GetVelicinaJelas()
        {
            return db.esp_VelicinaJelaAll().ToList();
        }
        
                [HttpGet]
        [Route("api/VelicinaJela/AllVelicineByJeloID/{jeloID}")]
        [ResponseType(typeof(VelicinaJela))]
        public List<esp_VelicinaJelaByJeloID_Result> AllVelicineByJeloID(int jeloID)
        {
            return db.esp_VelicinaJelaByJeloID(jeloID).ToList();
        }
        // GET: api/VelicinaJela/5
        [ResponseType(typeof(VelicinaJela))]
        public IHttpActionResult GetVelicinaJela(int id)
        {
            VelicinaJela velicinaJela = db.VelicinaJela.Find(id);
            if (velicinaJela == null)
            {
                return NotFound();
            }

            return Ok(velicinaJela);
        }

        // PUT: api/VelicinaJela/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVelicinaJela(int id, VelicinaJela velicinaJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != velicinaJela.VelicinaJelaID)
            {
                return BadRequest();
            }

            db.Entry(velicinaJela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VelicinaJelaExists(id))
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

        // POST: api/VelicinaJela
        [ResponseType(typeof(VelicinaJela))]
        public IHttpActionResult PostVelicinaJela(VelicinaJela velicinaJela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VelicinaJela.Add(velicinaJela);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = velicinaJela.VelicinaJelaID }, velicinaJela);
        }

        // DELETE: api/VelicinaJela/5
        [ResponseType(typeof(VelicinaJela))]
        public IHttpActionResult DeleteVelicinaJela(int id)
        {
            VelicinaJela velicinaJela = db.VelicinaJela.Find(id);
            if (velicinaJela == null)
            {
                return NotFound();
            }

            db.VelicinaJela.Remove(velicinaJela);
            db.SaveChanges();

            return Ok(velicinaJela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VelicinaJelaExists(int id)
        {
            return db.VelicinaJela.Count(e => e.VelicinaJelaID == id) > 0;
        }
    }
}