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
    public class VolantesController : Controller
    {
        //private EnsambladoraDbContext db = new EnsambladoraDbContext();
        private readonly IUnityofWork _UnityOfWork;
        public VolantesController(IUnityofWork unityofwork)
        {
            _UnityOfWork = unityofwork;
        }
        public VolantesController()
        {

        }
        // GET: Volantes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Volantes.GetAll());
        }

        // GET: Volantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = _UnityOfWork.Volantes.Get(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // GET: Volantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolanteId,NumSerie")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Volantes.Add(volante);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volante);
        }

        // GET: Volantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = _UnityOfWork.Volantes.Get(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // POST: Volantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolanteId,NumSerie")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(volante);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volante);
        }

        // GET: Volantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = _UnityOfWork.Volantes.Get(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // POST: Volantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volante volante = _UnityOfWork.Volantes.Get(id);
            _UnityOfWork.Volantes.Delete(volante);
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
