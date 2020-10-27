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
    public class IaseosController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Iaseos
        public ActionResult Index()
        {
            return View(db.iAseo.ToList());
        }

        // GET: Iaseos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iaseo iaseo = db.iAseo.Find(id);
            if (iaseo == null)
            {
                return HttpNotFound();
            }
            return View(iaseo);
        }

        // GET: Iaseos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iaseos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado")] Iaseo iaseo)
        {
            if (ModelState.IsValid)
            {
                db.iAseo.Add(iaseo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iaseo);
        }

        // GET: Iaseos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iaseo iaseo = db.iAseo.Find(id);
            if (iaseo == null)
            {
                return HttpNotFound();
            }
            return View(iaseo);
        }

        // POST: Iaseos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado")] Iaseo iaseo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iaseo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iaseo);
        }

        // GET: Iaseos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iaseo iaseo = db.iAseo.Find(id);
            if (iaseo == null)
            {
                return HttpNotFound();
            }
            return View(iaseo);
        }

        // POST: Iaseos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Iaseo iaseo = db.iAseo.Find(id);
            db.iAseo.Remove(iaseo);
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
