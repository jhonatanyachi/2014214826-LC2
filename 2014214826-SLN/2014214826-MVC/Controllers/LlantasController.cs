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
    public class LlantasController : Controller
    {
        //private EnsambladoraDbContext db = new EnsambladoraDbContext();
        private readonly IUnityofWork _UnityOfWork;
        public LlantasController(IUnityofWork unityofwork)
        {
            _UnityOfWork = unityofwork;
        }
        public LlantasController()
        {

        }
        // GET: Llantas
        public ActionResult Index()
        {
            return View(_UnityOfWork.Llantas.GetAll());
        }

        // GET: Llantas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = _UnityOfWork.Llantas.Get(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            return View(llanta);
        }

        // GET: Llantas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Llantas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LlantaId,NumSerie")] Llanta llanta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Llantas.Add(llanta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(llanta);
        }

        // GET: Llantas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = _UnityOfWork.Llantas.Get(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            return View(llanta);
        }

        // POST: Llantas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LlantaId,NumSerie")] Llanta llanta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(llanta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(llanta);
        }

        // GET: Llantas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llanta llanta = _UnityOfWork.Llantas.Get(id);
            if (llanta == null)
            {
                return HttpNotFound();
            }
            return View(llanta);
        }

        // POST: Llantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Llanta llanta = _UnityOfWork.Llantas.Get(id);
            _UnityOfWork.Llantas.Delete(llanta);
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
