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
    public class MedioPagoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public MedioPagoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: MedioPagoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.MediosPago.GetAll());
        }

        // GET: MedioPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Get(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // GET: MedioPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedioPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediosPagoId")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.MediosPago.Add(medioPago);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medioPago);
        }

        // GET: MedioPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Get(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // POST: MedioPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedioPagoId")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(medioPago);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medioPago);
        }

        // GET: MedioPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioPago medioPago = _UnityOfWork.MediosPago.Get(id);
            if (medioPago == null)
            {
                return HttpNotFound();
            }
            return View(medioPago);
        }

        // POST: MedioPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedioPago medioPago = _UnityOfWork.MediosPago.Get(id);
            _UnityOfWork.MediosPago.Delete(medioPago);
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
