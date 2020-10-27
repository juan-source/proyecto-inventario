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
    public class IpanaderiasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ipanaderias
        public ActionResult Index()
        {
            return View(db.ipanaderia.ToList());
        }

        // GET: Ipanaderias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipanaderia ipanaderia = db.ipanaderia.Find(id);
            if (ipanaderia == null)
            {
                return HttpNotFound();
            }
            return View(ipanaderia);
        }

        // GET: Ipanaderias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ipanaderias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoproducto,cantexistente")] Ipanaderia ipanaderia)
        {
            if (ModelState.IsValid)
            {
                db.ipanaderia.Add(ipanaderia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ipanaderia);
        }

        // GET: Ipanaderias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipanaderia ipanaderia = db.ipanaderia.Find(id);
            if (ipanaderia == null)
            {
                return HttpNotFound();
            }
            return View(ipanaderia);
        }

        // POST: Ipanaderias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipoproducto,cantexistente")] Ipanaderia ipanaderia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipanaderia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ipanaderia);
        }

        // GET: Ipanaderias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipanaderia ipanaderia = db.ipanaderia.Find(id);
            if (ipanaderia == null)
            {
                return HttpNotFound();
            }
            return View(ipanaderia);
        }

        // POST: Ipanaderias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ipanaderia ipanaderia = db.ipanaderia.Find(id);
            db.ipanaderia.Remove(ipanaderia);
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
