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
    public class BVerduleriasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: BVerdulerias
        public ActionResult Index()
        {
            return View(db.bverduleria.ToList());
        }

        // GET: BVerdulerias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BVerduleria bVerduleria = db.bverduleria.Find(id);
            if (bVerduleria == null)
            {
                return HttpNotFound();
            }
            return View(bVerduleria);
        }

        // GET: BVerdulerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BVerdulerias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipodeproducto,cantenbultosocanastas")] BVerduleria bVerduleria)
        {
            if (ModelState.IsValid)
            {
                db.bverduleria.Add(bVerduleria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bVerduleria);
        }

        // GET: BVerdulerias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BVerduleria bVerduleria = db.bverduleria.Find(id);
            if (bVerduleria == null)
            {
                return HttpNotFound();
            }
            return View(bVerduleria);
        }

        // POST: BVerdulerias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipodeproducto,cantenbultosocanastas")] BVerduleria bVerduleria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bVerduleria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bVerduleria);
        }

        // GET: BVerdulerias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BVerduleria bVerduleria = db.bverduleria.Find(id);
            if (bVerduleria == null)
            {
                return HttpNotFound();
            }
            return View(bVerduleria);
        }

        // POST: BVerdulerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BVerduleria bVerduleria = db.bverduleria.Find(id);
            db.bverduleria.Remove(bVerduleria);
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
