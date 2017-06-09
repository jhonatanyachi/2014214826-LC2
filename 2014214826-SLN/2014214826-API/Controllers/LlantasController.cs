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
using _2014214826_ENT;
using _2014214826_PER;

namespace _2014214826_API.Controllers
{
    public class LlantasController : ApiController
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: api/Llantas
        public IQueryable<Llanta> GetLlantas()
        {
            return db.Llantas;
        }

        // GET: api/Llantas/5
        [ResponseType(typeof(Llanta))]
        public IHttpActionResult GetLlanta(int id)
        {
            Llanta llanta = db.Llantas.Find(id);
            if (llanta == null)
            {
                return NotFound();
            }

            return Ok(llanta);
        }

        // PUT: api/Llantas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLlanta(int id, Llanta llanta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != llanta.LlantaId)
            {
                return BadRequest();
            }

            db.Entry(llanta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LlantaExists(id))
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

        // POST: api/Llantas
        [ResponseType(typeof(Llanta))]
        public IHttpActionResult PostLlanta(Llanta llanta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Llantas.Add(llanta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = llanta.LlantaId }, llanta);
        }

        // DELETE: api/Llantas/5
        [ResponseType(typeof(Llanta))]
        public IHttpActionResult DeleteLlanta(int id)
        {
            Llanta llanta = db.Llantas.Find(id);
            if (llanta == null)
            {
                return NotFound();
            }

            db.Llantas.Remove(llanta);
            db.SaveChanges();

            return Ok(llanta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LlantaExists(int id)
        {
            return db.Llantas.Count(e => e.LlantaId == id) > 0;
        }
    }
}