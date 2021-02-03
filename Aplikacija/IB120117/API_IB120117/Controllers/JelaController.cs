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
using Mobile_IB120117;

namespace API_IB120117.Controllers
{
    public class JelaController : ApiController
    {
        private IB120117Entities db = new IB120117Entities();

        // GET: api/Jela
        public IQueryable<Jela> GetJelas()
        {
            return db.Jela;
        }
        [HttpGet]
        [ResponseType(typeof(Jela))]

        [Route("api/Jela/PreporuceniRestorani/{jeloID}")]
        public List<PreporukaRestorana_Result> PreporuceniRestorani(int jeloID)
        {
            Preporuka p = new Preporuka();
            return p.GetSlicnost(jeloID);
        }
        [HttpGet]
        [Route("api/Jela/AllJelaPretraga")]
        public List<esp_JelaZaPretraguAll_Result> AllJelaPretraga()
        {
            return db.esp_JelaZaPretraguAll().ToList();
        }
        [HttpGet]
        [Route("api/Jela/GetJela/{username}")]
        public esp_JeloByID_Result GetJela(int id)
        {
            return db.esp_JeloByID(id).FirstOrDefault();
        }
        
             [HttpGet]
        [Route("api/Jela/JeloByID/{jeloID}")]
        public esp_JeloByJeloID2_Result JeloByID(int jeloID)
        {
            return db.esp_JeloByJeloID2(jeloID).FirstOrDefault();
        }
        [HttpGet]
        [Route("api/Jela/JelaByRestoran/{restoranID}")]
        public List<esp_JelaByRestoranID_Result> JelaByRestoran (int restoranID)
        {
            return db.esp_JelaByRestoranID(restoranID).ToList();
        }
        
             [HttpGet]
        [Route("api/Jela/JelaByRestoranVrsta/{restoranID}/{vrstaID}")]
        public List<esp_JelaByRestoranIDVrstaID_Result> JelaByRestoranVrsta(int restoranID,int vrstaID)
        {
            return db.esp_JelaByRestoranIDVrstaID(restoranID,vrstaID).ToList();
        }
        [HttpGet]
        [Route("api/Jela/JelaByRestoranVrstaNaziv/{restoranID}/{vrstaID}/{naziv}")]
        public List<esp_JelaByRestoranIDVrstaIDNazivv_Result> JelaByRestoranVrstaNaziv(int restoranID, int vrstaID,string naziv)
        {
            return db.esp_JelaByRestoranIDVrstaIDNazivv(restoranID, vrstaID,naziv).ToList();
        }
        [HttpGet]
        [Route("api/Jela/LastJelo")]
        public esp_LastJelo_Result LastJelo()
        {
            return db.esp_LastJelo().FirstOrDefault();
        }


        [HttpGet]
        [Route("api/Jela/AllJelaPretragaByNaziv/{Naziv?}/{VrstaID?}/{RestoranID?}")]
        public List<AllJelaPretragaByNaziv_Result> AllJelaPretragaByNaziv(string Naziv, int VrstaID, int RestoranID)
        {
            return db.AllJelaPretragaByNaziv(Naziv, VrstaID, RestoranID).ToList();
        }
        

            [HttpGet]
        [Route("api/Jela/AllJelaPretragaByVrstaRestoran/{VrstaID?}/{RestoranID?}")]
        public List<AllJelaPretragaByVrstaRestoran_Result> AllJelaPretragaByVrstaRestoran(int VrstaID, int RestoranID)
        {
            return db.AllJelaPretragaByVrstaRestoran(VrstaID, RestoranID).ToList();
        }
      
        // PUT: api/Jela/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJela(int id, Jela jela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jela.JeloID)
            {
                return BadRequest();
            }

            db.Entry(jela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JelaExists(id))
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

        // POST: api/Jela
        [ResponseType(typeof(Jela))]
        public IHttpActionResult PostJela(Jela jela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.esp_JeloAdd(jela.Naziv, jela.Opis, jela.Aktivno, jela.Slika, jela.SlikaThumb, jela.KorisnikID,jela.RestoranID, jela.VrsteJelaID);



            return CreatedAtRoute("DefaultApi", new { id = jela.JeloID }, jela);
        }

        // DELETE: api/Jela/5
        [ResponseType(typeof(Jela))]
        public IHttpActionResult DeleteJela(int id)
        {
            Jela jela = new Jela();
            if (jela == null)
            {
                return NotFound();
            }

            db.esp_deleteKomentari(id);

            db.esp_deleteNarudzbaStavke(id);

            db.esp_deleteOcjeneJelo(id);
            db.esp_deleteVelicinaJelaTabela(id);
            db.esp_deleteJelo(id);

            return Ok(jela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JelaExists(int id)
        {
            return db.Jela.Count(e => e.JeloID == id) > 0;
        }
    }
}