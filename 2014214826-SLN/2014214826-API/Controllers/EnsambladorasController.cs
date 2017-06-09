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
    public class EnsambladorasController : ApiController
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: api/Ensambladoras
        public IQueryable<Ensambladora> GetEnsambladoras()
        {
            return db.Ensambladoras;
        }

        // GET: api/Ensambladoras/5
        [ResponseType(typeof(Ensambladora))]
        public IHttpActionResult GetEnsambladora(int id)
        {
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            if (ensambladora == null)
            {
                return NotFound();
            }

            return Ok(ensambladora);
        }

        // PUT: api/Ensambladoras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnsambladora(int id, Ensambladora ensambladora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ensambladora.EnsambladoraId)
            {
                return BadRequest();
            }

            db.Entry(ensambladora).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnsambladoraExists(id))
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

        // POST: api/Ensambladoras
        [ResponseType(typeof(Ensambladora))]
        public IHttpActionResult PostEnsambladora(Ensambladora ensambladora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ensambladoras.Add(ensambladora);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ensambladora.EnsambladoraId }, ensambladora);
        }

        // DELETE: api/Ensambladoras/5
        [ResponseType(typeof(Ensambladora))]
        public IHttpActionResult DeleteEnsambladora(int id)
        {
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            if (ensambladora == null)
            {
                return NotFound();
            }

            db.Ensambladoras.Remove(ensambladora);
            db.SaveChanges();

            return Ok(ensambladora);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnsambladoraExists(int id)
        {
            return db.Ensambladoras.Count(e => e.EnsambladoraId == id) > 0;
        }
    }
}