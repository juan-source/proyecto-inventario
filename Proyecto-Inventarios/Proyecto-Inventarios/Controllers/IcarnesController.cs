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
    public class IcarnesController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Icarnes
        public ActionResult Index()
        {
            return View(db.icarne.ToList());
        }

        // GET: Icarnes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icarne icarne = db.icarne.Find(id);
            if (icarne == null)
            {
                return HttpNotFound();
            }
            return View(icarne);
        }

        // GET: Icarnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Icarnes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "especieanimal,tipodecarne,cantenlb")] Icarne icarne)
        {
            if (ModelState.IsValid)
            {
                db.icarne.Add(icarne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icarne);
        }

        // GET: Icarnes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icarne icarne = db.icarne.Find(id);
            if (icarne == null)
            {
                return HttpNotFound();
            }
            return View(icarne);
        }

        // POST: Icarnes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "especieanimal,tipodecarne,cantenlb")] Icarne icarne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icarne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icarne);
        }

        // GET: Icarnes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icarne icarne = db.icarne.Find(id);
            if (icarne == null)
            {
                return HttpNotFound();
            }
            return View(icarne);
        }

        // POST: Icarnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Icarne icarne = db.icarne.Find(id);
            db.icarne.Remove(icarne);
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
