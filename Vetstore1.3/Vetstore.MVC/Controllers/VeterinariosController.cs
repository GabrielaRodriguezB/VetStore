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
    public class VeterinariosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public VeterinariosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Veterinarios
        public ActionResult Index()
        {
            return View(_UnityOfWork.Veterinarios.GetAll());
        }

        // GET: Veterinarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = _UnityOfWork.Veterinarios.Get(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        // GET: Veterinarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeterinarioId")] Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Veterinarios.Add(veterinario);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinario);
        }

        // GET: Veterinarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = _UnityOfWork.Veterinarios.Get(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        // POST: Veterinarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeterinarioId")] Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(veterinario);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinario);
        }

        // GET: Veterinarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinario veterinario = _UnityOfWork.Veterinarios.Get(id);
            if (veterinario == null)
            {
                return HttpNotFound();
            }
            return View(veterinario);
        }

        // POST: Veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinario veterinario = _UnityOfWork.Veterinarios.Get(id);
            _UnityOfWork.Veterinarios.Delete(veterinario);
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
