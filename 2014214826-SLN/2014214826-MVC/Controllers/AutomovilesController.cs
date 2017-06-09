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

namespace _2014214826_MVC.Controllers
{
    public class AutomovilesController : Controller
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: Automoviles
        public ActionResult Index()
        {
            var carros = db._Carroes.Include(a => a.Asiento).Include(a => a.Ensambladora).Include(a => a.Llanta).Include(a => a.Parabrisas).Include(a => a.Propietario).Include(a => a.Volante);
            return View(carros.ToList());
        }

        // GET: Automoviles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automovil = db.Carros.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automoviles/Create
        public ActionResult Create()
        {
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento");
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora");
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie");
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie");
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI");
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie");
            return View();
        }

        // POST: Automoviles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,PropietarioId,ParabrisasId,VolanteId,TipoCarro,AsientoId,LlantaId,EnsambladoraId,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Carros.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", automovil.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", automovil.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", automovil.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", automovil.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", automovil.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.VolanteId);
            return View(automovil);
        }

        // GET: Automoviles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automovil = db.Carros.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", automovil.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", automovil.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", automovil.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", automovil.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", automovil.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.VolanteId);
            return View(automovil);
        }

        // POST: Automoviles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,PropietarioId,ParabrisasId,VolanteId,TipoCarro,AsientoId,LlantaId,EnsambladoraId,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", automovil.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", automovil.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", automovil.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", automovil.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", automovil.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", automovil.VolanteId);
            return View(automovil);
        }

        // GET: Automoviles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automovil = db.Carros.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automoviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro automovil = db.Carros.Find(id);
            db.Carros.Remove(automovil);
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
