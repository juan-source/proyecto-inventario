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
    public class IverduleriasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Iverdulerias
        public ActionResult Index()
        {
            return View(db.iverduleria.ToList());
        }

        // GET: Iverdulerias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iverduleria iverduleria = db.iverduleria.Find(id);
            if (iverduleria == null)
            {
                return HttpNotFound();
            }
            return View(iverduleria);
        }

        // GET: Iverdulerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iverdulerias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipodeproducto,cantenbultosocanastas")] Iverduleria iverduleria)
        {
            if (ModelState.IsValid)
            {
                db.iverduleria.Add(iverduleria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iverduleria);
        }

        // GET: Iverdulerias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iverduleria iverduleria = db.iverduleria.Find(id);
            if (iverduleria == null)
            {
                return HttpNotFound();
            }
            return View(iverduleria);
        }

        // POST: Iverdulerias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipodeproducto,cantenbultosocanastas")] Iverduleria iverduleria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iverduleria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iverduleria);
        }

        // GET: Iverdulerias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iverduleria iverduleria = db.iverduleria.Find(id);
            if (iverduleria == null)
            {
                return HttpNotFound();
            }
            return View(iverduleria);
        }

        // POST: Iverdulerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Iverduleria iverduleria = db.iverduleria.Find(id);
            db.iverduleria.Remove(iverduleria);
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
