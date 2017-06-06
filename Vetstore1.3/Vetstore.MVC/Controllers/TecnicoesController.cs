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
    public class TecnicoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public TecnicoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Tecnicoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Tecnicos.GetAll());
        }

        // GET: Tecnicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _UnityOfWork.Tecnicos.Get(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TecnicoId")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Tecnicos.Add(tecnico);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnico);
        }

        // GET: Tecnicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _UnityOfWork.Tecnicos.Get(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TecnicoId")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(tecnico) ;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnico);
        }

        // GET: Tecnicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _UnityOfWork.Tecnicos.Get(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = _UnityOfWork.Tecnicos.Get(id);
            _UnityOfWork.Tecnicos.Delete(tecnico);
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
