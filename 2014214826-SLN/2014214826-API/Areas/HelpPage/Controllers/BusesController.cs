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
    public class BusesController : Controller
    {
        private EnsambladoraDbContext db = new EnsambladoraDbContext();

        // GET: Buses
        public ActionResult Index()
        {
            var carros = db.Carroes.Include(b => b.Asiento).Include(b => b.Ensambladora).Include(b => b.Llanta).Include(b => b.Parabrisas).Include(b => b.Propietario).Include(b => b.Volante);
            return View(carros.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Carros.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Buses/Create
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

        // POST: Buses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,PropietarioId,ParabrisasId,VolanteId,TipoCarro,AsientoId,LlantaId,EnsambladoraId,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Carros.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", bus.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", bus.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", bus.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Carros.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", bus.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", bus.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", bus.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // POST: Buses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,PropietarioId,ParabrisasId,VolanteId,TipoCarro,AsientoId,LlantaId,EnsambladoraId,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsientoId = new SelectList(db.Asientos, "AsientoId", "NumSerieAsiento", bus.AsientoId);
            ViewBag.EnsambladoraId = new SelectList(db.Ensambladoras, "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.LlantaId = new SelectList(db.Llantas, "LlantaId", "NumSerie", bus.LlantaId);
            ViewBag.ParabrisasId = new SelectList(db.Parabrisas, "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioId", "DNI", bus.PropietarioId);
            ViewBag.VolanteId = new SelectList(db.Volantes, "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Carros.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro bus = db.Carros.Find(id);
            db.Carros.Remove(bus);
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
