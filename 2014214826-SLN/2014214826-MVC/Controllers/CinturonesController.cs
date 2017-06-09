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
    public class CinturonesController : Controller
    {
        //private EnsambladoraDbContext db = new EnsambladoraDbContext();
        private readonly IUnityofWork _UnityOfWork;
        public CinturonesController(IUnityofWork unityofwork)
        {
            _UnityOfWork = unityofwork;
        }
        public CinturonesController()
        {

        }
        // GET: Cinturones
        public ActionResult Index()
        {
            return View(_UnityOfWork.Cinturones.GetAll());
        }

        // GET: Cinturones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = _UnityOfWork.Cinturones.Get(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // GET: Cinturones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinturones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinturonId,NumSerieCinturon,Metraje")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Cinturones.Add(cinturon);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinturon);
        }

        // GET: Cinturones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = _UnityOfWork.Cinturones.Get(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // POST: Cinturones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinturonId,NumSerieCinturon,Metraje")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(cinturon);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinturon);
        }

        // GET: Cinturones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = _UnityOfWork.Cinturones.Get(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // POST: Cinturones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinturon cinturon = _UnityOfWork.Cinturones.Get(id);
            _UnityOfWork.Cinturones.Delete(cinturon);
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
