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
    public class IdrogueriasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Idroguerias
        public ActionResult Index()
        {
            return View(db.idrogueria.ToList());
        }

        // GET: Idroguerias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idrogueria idrogueria = db.idrogueria.Find(id);
            if (idrogueria == null)
            {
                return HttpNotFound();
            }
            return View(idrogueria);
        }

        // GET: Idroguerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idroguerias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcalaboratorio,nombredroga,tipodeenvase,pesoengramos,cantexistente,fechadevencimiento")] Idrogueria idrogueria)
        {
            if (ModelState.IsValid)
            {
                db.idrogueria.Add(idrogueria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idrogueria);
        }

        // GET: Idroguerias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idrogueria idrogueria = db.idrogueria.Find(id);
            if (idrogueria == null)
            {
                return HttpNotFound();
            }
            return View(idrogueria);
        }

        // POST: Idroguerias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcalaboratorio,nombredroga,tipodeenvase,pesoengramos,cantexistente,fechadevencimiento")] Idrogueria idrogueria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idrogueria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idrogueria);
        }

        // GET: Idroguerias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idrogueria idrogueria = db.idrogueria.Find(id);
            if (idrogueria == null)
            {
                return HttpNotFound();
            }
            return View(idrogueria);
        }

        // POST: Idroguerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Idrogueria idrogueria = db.idrogueria.Find(id);
            db.idrogueria.Remove(idrogueria);
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
