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
    public class ParabrisasController : Controller
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: HelpPage/Parabrisas
        public ActionResult Index()
        {
            return View(db.Parabrisas.ToList());
        }

        // GET: HelpPage/Parabrisas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            return View(parabrisas);
        }

        // GET: HelpPage/Parabrisas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HelpPage/Parabrisas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParabrisasId,NumSerie")] Parabrisas parabrisas)
        {
            if (ModelState.IsValid)
            {
                db.Parabrisas.Add(parabrisas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parabrisas);
        }

        // GET: HelpPage/Parabrisas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            return View(parabrisas);
        }

        // POST: HelpPage/Parabrisas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParabrisasId,NumSerie")] Parabrisas parabrisas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parabrisas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parabrisas);
        }

        // GET: HelpPage/Parabrisas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return HttpNotFound();
            }
            return View(parabrisas);
        }

        // POST: HelpPage/Parabrisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            db.Parabrisas.Remove(parabrisas);
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
