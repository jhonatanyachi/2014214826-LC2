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
using _2014214826_ENT.IRepositories;

namespace _2014214826_MVC.Controllers
{
    public class BusesController : Controller
    {
        //private EnsambladoraDbContext db = new EnsambladoraDbContext();
        private readonly IUnityofWork _UnityOfWork;
        public BusesController(IUnityofWork unityofwork)
        {
            _UnityOfWork = unityofwork;
        }
        public BusesController()
        {

        }
        // GET: Buses
        public ActionResult Index()
        {
            var carroes = _UnityOfWork.Carros.GetEntity().Include(b => b.Ensambladora).Include(b => b.Parabrisas).Include(b => b.Volante);
            return View(carroes.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = _UnityOfWork.Buses.Get(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Buses/Create
        public ActionResult Create()
        {
            ViewBag.EnsambladoraId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Ensambladora), "EnsambladoraId", "_Ensambladora");
            ViewBag.ParabrisasId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Parabrisas), "ParabrisasId", "NumSerie");
            ViewBag.VolanteId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Volante), "VolanteId", "NumSerie");
            return View();
        }

        // POST: Buses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,ParabrisasId,VolanteId,TipoCarro,EnsambladoraId,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Carros.Add(bus);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnsambladoraId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Ensambladora), "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.ParabrisasId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Parabrisas), "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.VolanteId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Volante), "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = _UnityOfWork.Buses.Get(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnsambladoraId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Ensambladora), "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.ParabrisasId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Parabrisas), "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.VolanteId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Volante), "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // POST: Buses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarroId,NumSerieMotor,NumSerieChasis,ParabrisasId,VolanteId,TipoCarro,EnsambladoraId,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(bus);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnsambladoraId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Ensambladora), "EnsambladoraId", "_Ensambladora", bus.EnsambladoraId);
            ViewBag.ParabrisasId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Parabrisas), "ParabrisasId", "NumSerie", bus.ParabrisasId);
            ViewBag.VolanteId = new SelectList(_UnityOfWork.Carros.GetEntity().Include(b => b.Volante), "VolanteId", "NumSerie", bus.VolanteId);
            return View(bus);
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = _UnityOfWork.Buses.Get(id);
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
            Bus bus = _UnityOfWork.Buses.Get(id);
            _UnityOfWork.Carros.Delete(bus);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
