using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vetstore.Entities;
using Vetstore.Entities.IRepositories;
using Vetstore.Persistence;

namespace Vetstore.MVC.Controllers
{
    public class AtencionsController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public AtencionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Atencions
        public ActionResult Index()
        {
            return View(_UnityOfWork.Atenciones.GetAll());
        }

        // GET: Atencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = _UnityOfWork.Atenciones.Get(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }
            return View(atencion);
        }

        // GET: Atencions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtencionId,ClienteId,MascotaId")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Atenciones.Add(atencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atencion);
        }

        // GET: Atencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = _UnityOfWork.Atenciones.Get(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }

            return View(atencion);
        }

        // POST: Atencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtencionId,ClienteId,MascotaId")] Atencion atencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(atencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atencion);
        }

        // GET: Atencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atencion atencion = _UnityOfWork.Atenciones.Get(id);
            if (atencion == null)
            {
                return HttpNotFound();
            }
            return View(atencion);
        }

        // POST: Atencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atencion atencion = _UnityOfWork.Atenciones.Get(id);
            _UnityOfWork.Atenciones.Delete(atencion);
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
