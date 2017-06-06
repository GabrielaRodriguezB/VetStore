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
    public class DireccionsController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public DireccionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Direccions
        public ActionResult Index()
        {
            return View(_UnityOfWork.Direcciones.GetAll());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionId,LocalId,UbigeoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Direcciones.Add(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }

            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DireccionId,LocalId,UbigeoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = _UnityOfWork.Direcciones.Get(id);
            _UnityOfWork.Direcciones.Delete(direccion);
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
