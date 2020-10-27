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
    public class BelectroesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Belectroes
        public ActionResult Index()
        {
            return View(db.belectro.ToList());
        }

        // GET: Belectroes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belectro belectro = db.belectro.Find(id);
            if (belectro == null)
            {
                return HttpNotFound();
            }
            return View(belectro);
        }

        // GET: Belectroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Belectroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marca,tipoproducto,pesootamaño,cantexistente")] Belectro belectro)
        {
            if (ModelState.IsValid)
            {
                db.belectro.Add(belectro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(belectro);
        }

        // GET: Belectroes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belectro belectro = db.belectro.Find(id);
            if (belectro == null)
            {
                return HttpNotFound();
            }
            return View(belectro);
        }

        // POST: Belectroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marca,tipoproducto,pesootamaño,cantexistente")] Belectro belectro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(belectro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(belectro);
        }

        // GET: Belectroes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belectro belectro = db.belectro.Find(id);
            if (belectro == null)
            {
                return HttpNotFound();
            }
            return View(belectro);
        }

        // POST: Belectroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Belectro belectro = db.belectro.Find(id);
            db.belectro.Remove(belectro);
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
