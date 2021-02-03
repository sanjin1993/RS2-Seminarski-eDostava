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
    public class RestoraniController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Restorani
        public IQueryable<Restorani> GetRestoranis()
        {
            return db.Restorani;
        }
        [HttpGet]
        [Route("api/Restorani/AllRestorani")]
        [ResponseType(typeof(Restorani))]
        public List<esp_RestoraniAll_Result> AllRestorani()
        {
            return db.esp_RestoraniAll().ToList();
        }
        [HttpGet]
        [Route("api/Restorani/RestoranByName/{naziv}")]
        [ResponseType(typeof(Restorani))]
        public List<esp_AllRestoraniByNaziv_Result> RestoranByName(string naziv)
        {
            return db.esp_AllRestoraniByNaziv(naziv).ToList();
        }
        // GET: api/Restorani/5
        [ResponseType(typeof(Restorani))]
        [HttpGet]
        [Route("api/Restorani/All")]
        public List< esp_AllRestoraniLista_Result> All()
        {
            return db.esp_AllRestoraniLista().ToList();
        }
        [ResponseType(typeof(Restorani))]
        public esp_RestoraniByID_Result GetRestoran(int id)
        {
            return db.esp_RestoraniByID(id).FirstOrDefault();
        }

        // PUT: api/Restorani/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestorani(int id, Restorani restorani)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restorani.RestoranID)
            {
                return BadRequest();
            }

            db.Entry(restorani).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestoraniExists(id))
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

        // POST: api/Restorani
        [ResponseType(typeof(Restorani))]
        public IHttpActionResult PostRestorani(Restorani restorani)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_InsertRestorani(restorani.Naziv, restorani.Telefon, restorani.Mail, restorani.Adresa, restorani.Aktivno, restorani.Slika, restorani.SlikaThumb,restorani.KorisnikID);
           

            return CreatedAtRoute("DefaultApi", new { id = restorani.RestoranID }, restorani);
        }

        // DELETE: api/Restorani/5
        [ResponseType(typeof(Restorani))]
        public IHttpActionResult DeleteRestorani(int id)
        {
            Restorani restorani = new Restorani();
            if (restorani == null)
            {
                return NotFound();
            }

            db.esp_deleteRestoraniJela(id);
            db.esp_deleteRestorani(id);

            return Ok(restorani);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestoraniExists(int id)
        {
            return db.Restorani.Count(e => e.RestoranID == id) > 0;
        }
    }
}