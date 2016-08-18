using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_Alvaro.Models;

namespace Examen_Alvaro.Controllers
{
    public class inventariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: inventarios
        public ActionResult Index()
        {
            var inventarios = db.Inventarios.Include(i => i.Productos);
            return View(inventarios.ToList());
        }

        // GET: inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: inventarios/Create
        public ActionResult Create()
        {
            ViewBag.ProductosID = new SelectList(db.Productos, "Id", "Nombre");
            return View();
        }

        // POST: inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,CantidadMinima,CantidadMaxima,Tipo,ProductosID")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Inventarios.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductosID = new SelectList(db.Productos, "Id", "Nombre", inventario.ProductosID);
            return View(inventario);
        }

        // GET: inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductosID = new SelectList(db.Productos, "Id", "Nombre", inventario.ProductosID);
            return View(inventario);
        }

        // POST: inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,CantidadMinima,CantidadMaxima,Tipo,ProductosID")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductosID = new SelectList(db.Productos, "Id", "Nombre", inventario.ProductosID);
            return View(inventario);
        }

        // GET: inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inventario inventario = db.Inventarios.Find(id);
            db.Inventarios.Remove(inventario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
