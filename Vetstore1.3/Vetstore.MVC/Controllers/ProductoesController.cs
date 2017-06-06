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
    public class ProductoesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;
        public ProductoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Productoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Productos.GetAll());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = _UnityOfWork.Productos.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,CategoriaProductoId,VentaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Productos.Add(producto);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = _UnityOfWork.Productos.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,CategoriaProductoId,VentaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(producto);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = _UnityOfWork.Productos.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = _UnityOfWork.Productos.Get(id);
            _UnityOfWork.Productos.Delete(producto);
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
