using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Inventarios.Data;
using Proyecto_Inventarios.Models.Inventarios_Generales;

namespace Proyecto_Inventarios.Controllers
{
    public class IjuguetesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ijuguetes
        public ActionResult Index()
        {
            return View(db.ijuguetes.ToList());
        }

        // GET: Ijuguetes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ijuguetes ijuguetes = db.ijuguetes.Find(id);
            if (ijuguetes == null)
            {
                return HttpNotFound();
            }
            return View(ijuguetes);
        }

        // GET: Ijuguetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ijuguetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoproducto,cantexistente")] Ijuguetes ijuguetes)
        {
            if (ModelState.IsValid)
            {
                db.ijuguetes.Add(ijuguetes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ijuguetes);
        }

        // GET: Ijuguetes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ijuguetes ijuguetes = db.ijuguetes.Find(id);
            if (ijuguetes == null)
            {
                return HttpNotFound();
            }
            return View(ijuguetes);
        }

        // POST: Ijuguetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoproducto,cantexistente")] Ijuguetes ijuguetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ijuguetes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ijuguetes);
        }

        // GET: Ijuguetes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ijuguetes ijuguetes = db.ijuguetes.Find(id);
            if (ijuguetes == null)
            {
                return HttpNotFound();
            }
            return View(ijuguetes);
        }

        // POST: Ijuguetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ijuguetes ijuguetes = db.ijuguetes.Find(id);
            db.ijuguetes.Remove(ijuguetes);
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
