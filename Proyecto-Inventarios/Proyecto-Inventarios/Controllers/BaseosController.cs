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
    public class BaseosController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Baseos
        public ActionResult Index()
        {
            return View(db.baseo.ToList());
        }

        // GET: Baseos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baseo baseo = db.baseo.Find(id);
            if (baseo == null)
            {
                return HttpNotFound();
            }
            return View(baseo);
        }

        // GET: Baseos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baseos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado")] Baseo baseo)
        {
            if (ModelState.IsValid)
            {
                db.baseo.Add(baseo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseo);
        }

        // GET: Baseos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baseo baseo = db.baseo.Find(id);
            if (baseo == null)
            {
                return HttpNotFound();
            }
            return View(baseo);
        }

        // POST: Baseos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado")] Baseo baseo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseo);
        }

        // GET: Baseos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baseo baseo = db.baseo.Find(id);
            if (baseo == null)
            {
                return HttpNotFound();
            }
            return View(baseo);
        }

        // POST: Baseos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Baseo baseo = db.baseo.Find(id);
            db.baseo.Remove(baseo);
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
