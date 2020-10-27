using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Inventarios.Data;
using Proyecto_Inventarios.Models.Bodegas_Inventarios;

namespace Proyecto_Inventarios.Controllers
{
    public class BjuguetesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Bjuguetes
        public ActionResult Index()
        {
            return View(db.bjuguetes.ToList());
        }

        // GET: Bjuguetes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bjuguetes bjuguetes = db.bjuguetes.Find(id);
            if (bjuguetes == null)
            {
                return HttpNotFound();
            }
            return View(bjuguetes);
        }

        // GET: Bjuguetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bjuguetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoproducto,cantexistente")] Bjuguetes bjuguetes)
        {
            if (ModelState.IsValid)
            {
                db.bjuguetes.Add(bjuguetes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bjuguetes);
        }

        // GET: Bjuguetes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bjuguetes bjuguetes = db.bjuguetes.Find(id);
            if (bjuguetes == null)
            {
                return HttpNotFound();
            }
            return View(bjuguetes);
        }

        // POST: Bjuguetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoproducto,cantexistente")] Bjuguetes bjuguetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bjuguetes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bjuguetes);
        }

        // GET: Bjuguetes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bjuguetes bjuguetes = db.bjuguetes.Find(id);
            if (bjuguetes == null)
            {
                return HttpNotFound();
            }
            return View(bjuguetes);
        }

        // POST: Bjuguetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bjuguetes bjuguetes = db.bjuguetes.Find(id);
            db.bjuguetes.Remove(bjuguetes);
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
