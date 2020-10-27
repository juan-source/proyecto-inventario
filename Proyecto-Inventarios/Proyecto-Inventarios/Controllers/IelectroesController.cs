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
    public class IelectroesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ielectroes
        public ActionResult Index()
        {
            return View(db.ielectro.ToList());
        }

        // GET: Ielectroes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ielectro ielectro = db.ielectro.Find(id);
            if (ielectro == null)
            {
                return HttpNotFound();
            }
            return View(ielectro);
        }

        // GET: Ielectroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ielectroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marca,tipoproducto,pesootamaño,cantexistente")] Ielectro ielectro)
        {
            if (ModelState.IsValid)
            {
                db.ielectro.Add(ielectro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ielectro);
        }

        // GET: Ielectroes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ielectro ielectro = db.ielectro.Find(id);
            if (ielectro == null)
            {
                return HttpNotFound();
            }
            return View(ielectro);
        }

        // POST: Ielectroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marca,tipoproducto,pesootamaño,cantexistente")] Ielectro ielectro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ielectro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ielectro);
        }

        // GET: Ielectroes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ielectro ielectro = db.ielectro.Find(id);
            if (ielectro == null)
            {
                return HttpNotFound();
            }
            return View(ielectro);
        }

        // POST: Ielectroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ielectro ielectro = db.ielectro.Find(id);
            db.ielectro.Remove(ielectro);
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
