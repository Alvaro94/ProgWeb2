using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TareasCRUD.Models;

namespace TareasCRUD.Controllers
{
    public class tareas_crudController : Controller
    {
        private tareasEntities1 db = new tareasEntities1();

        // GET: tareas_crud
        public ActionResult Index()
        {
            return View(db.tareas_crud.ToList());
        }

        // GET: tareas_crud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tareas_crud tareas_crud = db.tareas_crud.Find(id);
            if (tareas_crud == null)
            {
                return HttpNotFound();
            }
            return View(tareas_crud);
        }

        // GET: tareas_crud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tareas_crud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tecnico,descripcion,prioridad,estado")] tareas_crud tareas_crud)
        {
            if (ModelState.IsValid)
            {
                db.tareas_crud.Add(tareas_crud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tareas_crud);
        }

        // GET: tareas_crud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tareas_crud tareas_crud = db.tareas_crud.Find(id);
            if (tareas_crud == null)
            {
                return HttpNotFound();
            }
            return View(tareas_crud);
        }

        // POST: tareas_crud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tecnico,descripcion,prioridad,estado")] tareas_crud tareas_crud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tareas_crud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tareas_crud);
        }

        // GET: tareas_crud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tareas_crud tareas_crud = db.tareas_crud.Find(id);
            if (tareas_crud == null)
            {
                return HttpNotFound();
            }
            return View(tareas_crud);
        }

        // POST: tareas_crud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tareas_crud tareas_crud = db.tareas_crud.Find(id);
            db.tareas_crud.Remove(tareas_crud);
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
