using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014214826_ENT;
using _2014214826_PER;

namespace _2014214826_API.Areas.HelpPage.Controllers
{
    public class AsientosController : Controller
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: HelpPage/Asientos
        public ActionResult Index()
        {
            var asientos = db.Asientos.Include(a => a.Cinturon);
            return View(asientos.ToList());
        }

        // GET: HelpPage/Asientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // GET: HelpPage/Asientos/Create
        public ActionResult Create()
        {
            ViewBag.CinturonId = new SelectList(db.Cinturones, "CinturonId", "NumSerieCinturon");
            return View();
        }

        // POST: HelpPage/Asientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsientoId,NumSerieAsiento,CinturonId")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Asientos.Add(asiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinturonId = new SelectList(db.Cinturones, "CinturonId", "NumSerieCinturon", asiento.CinturonId);
            return View(asiento);
        }

        // GET: HelpPage/Asientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinturonId = new SelectList(db.Cinturones, "CinturonId", "NumSerieCinturon", asiento.CinturonId);
            return View(asiento);
        }

        // POST: HelpPage/Asientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsientoId,NumSerieAsiento,CinturonId")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinturonId = new SelectList(db.Cinturones, "CinturonId", "NumSerieCinturon", asiento.CinturonId);
            return View(asiento);
        }

        // GET: HelpPage/Asientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // POST: HelpPage/Asientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            db.Asientos.Remove(asiento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
