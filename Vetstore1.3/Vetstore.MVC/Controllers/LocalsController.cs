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
    public class LocalsController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public LocalsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Locals
        public ActionResult Index()
        {
            return View(_UnityOfWork.Locales.GetAll());
        }

        // GET: Locals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = _UnityOfWork.Locales.Get(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // GET: Locals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalId,DireccionId")] Local local)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Locales.Add(local);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(local);
        }

        // GET: Locals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = _UnityOfWork.Locales.Get(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: Locals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocalId,DireccionId")] Local local)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(local);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(local);
        }

        // GET: Locals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Local local = _UnityOfWork.Locales.Get(id);
            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Local local = _UnityOfWork.Locales.Get(id);
            _UnityOfWork.Locales.Delete(local);
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
