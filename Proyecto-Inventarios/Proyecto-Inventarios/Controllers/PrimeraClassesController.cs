using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Inventarios.Data;
using Proyecto_Inventarios.Models;

namespace Proyecto_Inventarios.Controllers
{
    public class PrimeraClassesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: PrimeraClasses
        public ActionResult Index()
        {
            return View(db.primeras.ToList());
        }

        // GET: PrimeraClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeraClass primeraClass = db.primeras.Find(id);
            if (primeraClass == null)
            {
                return HttpNotFound();
            }
            return View(primeraClass);
        }

        // GET: PrimeraClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrimeraClasses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idprimera,nombre,email,salario")] PrimeraClass primeraClass)
        {
            if (ModelState.IsValid)
            {
                db.primeras.Add(primeraClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(primeraClass);
        }

        // GET: PrimeraClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeraClass primeraClass = db.primeras.Find(id);
            if (primeraClass == null)
            {
                return HttpNotFound();
            }
            return View(primeraClass);
        }

        // POST: PrimeraClasses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idprimera,nombre,email,salario")] PrimeraClass primeraClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primeraClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(primeraClass);
        }

        // GET: PrimeraClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimeraClass primeraClass = db.primeras.Find(id);
            if (primeraClass == null)
            {
                return HttpNotFound();
            }
            return View(primeraClass);
        }

        // POST: PrimeraClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrimeraClass primeraClass = db.primeras.Find(id);
            db.primeras.Remove(primeraClass);
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
