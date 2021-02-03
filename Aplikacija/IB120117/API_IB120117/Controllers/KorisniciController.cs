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
    public class KorisniciController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Korisnici
        public List<esp_KorisniciAllForGrid_Result> GetKorisnicis()
        {
            return db.esp_KorisniciAllForGrid().ToList();
        }
        [HttpGet]
        [Route("api/Korisnici/GetKorisnik/{id}")]
        public esp_KorisnikByID_Result GetKorisnik(int id)
        {
            return db.esp_KorisnikByID(id).FirstOrDefault();
        }
        [HttpGet]
        [Route("api/Korisnici/KorisnikByUserName/{username}")]
        public esp_desktopKorisnickoIme_Result KorisnikByUserName(string username)
        {
            esp_desktopKorisnickoIme_Result d= db.esp_desktopKorisnickoIme(username).FirstOrDefault();
            return d;
        }
        [HttpGet]
        [Route("api/Korisnici/KorisniciByNaselja/{NaseljeID}")]
        public List<esp_KorisniciAll_Result> KorisniciByNaselja(int NaseljeID)
        {
            return db.esp_KorisniciAll(NaseljeID).ToList();
        }
        
        [HttpGet]
        [Route("api/Korisnici/UpdateAktivnost/{KorisnikID}/{Aktivnost}")]
        public int UpdateAktivnost(int KorisnikID,bool Aktivnost)
        {
            return db.usp_UpdateKorisnikAktivnost(KorisnikID,Aktivnost);
        }
        // GET: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult KorisnikByUserName1(string username)
        {
            Korisnici korisnici = db.Korisnici.Where(x=>x.KorisnickoIme==username).FirstOrDefault();
            if (korisnici == null)
            {
                return NotFound();
            }

            return Ok(korisnici);
        }

        // PUT: api/Korisnici/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisnici(int id, Korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnici.KorisnikID)
            {
                return BadRequest();
            }

            db.usp_UpdateKorisnici(id, korisnici.Ime, korisnici.Prezime, korisnici.Mail, korisnici.Telefon, korisnici.Adresa, korisnici.KorisnickoIme, korisnici.LozinkaSalt, korisnici.LozinkaHash, korisnici.Status, korisnici.UlogaID, korisnici.NaseljeID);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciExists(id))
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

        // POST: api/Korisnici
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult PostKorisnici(Korisnici korisnici)
        {
            db.esp_InsertKorisnici(korisnici.Ime, korisnici.Prezime, korisnici.Mail, korisnici.Telefon, korisnici.Adresa, korisnici.KorisnickoIme, korisnici.LozinkaSalt, korisnici.LozinkaHash, korisnici.UlogaID, korisnici.NaseljeID);

            return CreatedAtRoute("DefaultApi", new { id = korisnici.KorisnikID }, korisnici);
        }

        // DELETE: api/Korisnici/5
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult DeleteKorisnici(int id)
        {
            Korisnici korisnici =new Korisnici();
            if (korisnici == null)
            {
                return NotFound();
            }

            db.esp_JeloDelete(id);
            db.esp_KorisnikDelete(id);

            return Ok(korisnici);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisniciExists(int id)
        {
            return db.Korisnici.Count(e => e.KorisnikID == id) > 0;
        }
    }
}