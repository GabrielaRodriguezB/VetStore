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
    public class VacunasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public VacunasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Vacunas
        public ActionResult Index()
        {
           return View(_UnityOfWork.Vacunas.GetAll());
        }

        // GET: Vacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = _UnityOfWork.Vacunas.Get(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // GET: Vacunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacunaId,MascotaId,ServicioClinicoId")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Vacunas.Add(vacuna);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(vacuna);
        }

        // GET: Vacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = _UnityOfWork.Vacunas.Get(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }

            return View(vacuna);
        }

        // POST: Vacunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacunaId,MascotaId,ServicioClinicoId")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(vacuna);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacuna);
        }

        // GET: Vacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = _UnityOfWork.Vacunas.Get(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: Vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacuna vacuna = _UnityOfWork.Vacunas.Get(id);
            _UnityOfWork.Vacunas.Delete(vacuna);
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
