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
    public class VelicinaJelaTabelaController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/VelicinaJelaTabela
        public IQueryable<VelicinaJelaTabela> GetVelicinaJelaTabelas()
        {
            return db.VelicinaJelaTabela;
        }

        // GET: api/VelicinaJelaTabela/5
        [ResponseType(typeof(VelicinaJelaTabela))]
        public IHttpActionResult GetVelicinaJelaTabela(int id)
        {
            VelicinaJelaTabela velicinaJelaTabela = db.VelicinaJelaTabela.Find(id);
            if (velicinaJelaTabela == null)
            {
                return NotFound();
            }

            return Ok(velicinaJelaTabela);
        }

        // PUT: api/VelicinaJelaTabela/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVelicinaJelaTabela(int id, VelicinaJelaTabela velicinaJelaTabela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != velicinaJelaTabela.VelicinaJelaTabelaID)
            {
                return BadRequest();
            }

            db.Entry(velicinaJelaTabela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VelicinaJelaTabelaExists(id))
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

        // POST: api/VelicinaJelaTabela
        [ResponseType(typeof(VelicinaJelaTabela))]
        public IHttpActionResult PostVelicinaJelaTabela(VelicinaJelaTabela velicinaJelaTabela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_VelicineJelaTableInsert(velicinaJelaTabela.Cijena,velicinaJelaTabela.VelicinaJelaID,velicinaJelaTabela.JeloID);

            return CreatedAtRoute("DefaultApi", new { id = velicinaJelaTabela.VelicinaJelaTabelaID }, velicinaJelaTabela);
        }

        // DELETE: api/VelicinaJelaTabela/5
        [ResponseType(typeof(VelicinaJelaTabela))]
        public IHttpActionResult DeleteVelicinaJelaTabela(int id)
        {
            VelicinaJelaTabela velicinaJelaTabela = db.VelicinaJelaTabela.Find(id);
            if (velicinaJelaTabela == null)
            {
                return NotFound();
            }

            db.VelicinaJelaTabela.Remove(velicinaJelaTabela);
            db.SaveChanges();

            return Ok(velicinaJelaTabela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VelicinaJelaTabelaExists(int id)
        {
            return db.VelicinaJelaTabela.Count(e => e.VelicinaJelaTabelaID == id) > 0;
        }
    }
}