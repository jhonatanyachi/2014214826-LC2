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
    public class CinturonesController : ApiController
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: api/Cinturones
        public IQueryable<Cinturon> GetCinturones()
        {
            return db.Cinturones;
        }

        // GET: api/Cinturones/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult GetCinturon(int id)
        {
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            return Ok(cinturon);
        }

        // PUT: api/Cinturones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinturon(int id, Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinturon.CinturonId)
            {
                return BadRequest();
            }

            db.Entry(cinturon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinturonExists(id))
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

        // POST: api/Cinturones
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult PostCinturon(Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinturones.Add(cinturon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinturon.CinturonId }, cinturon);
        }

        // DELETE: api/Cinturones/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult DeleteCinturon(int id)
        {
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            db.Cinturones.Remove(cinturon);
            db.SaveChanges();

            return Ok(cinturon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinturonExists(int id)
        {
            return db.Cinturones.Count(e => e.CinturonId == id) > 0;
        }
    }
}