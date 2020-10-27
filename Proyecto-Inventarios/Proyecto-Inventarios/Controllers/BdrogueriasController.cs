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
    public class BdrogueriasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Bdroguerias
        public ActionResult Index()
        {
            return View(db.bdrogueria.ToList());
        }

        // GET: Bdroguerias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdrogueria bdrogueria = db.bdrogueria.Find(id);
            if (bdrogueria == null)
            {
                return HttpNotFound();
            }
            return View(bdrogueria);
        }

        // GET: Bdroguerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bdroguerias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcalaboratorio,nombredroga,tipodeenvase,pesoengramos,cantexistente,fechadevencimiento")] Bdrogueria bdrogueria)
        {
            if (ModelState.IsValid)
            {
                db.bdrogueria.Add(bdrogueria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bdrogueria);
        }

        // GET: Bdroguerias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdrogueria bdrogueria = db.bdrogueria.Find(id);
            if (bdrogueria == null)
            {
                return HttpNotFound();
            }
            return View(bdrogueria);
        }

        // POST: Bdroguerias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcalaboratorio,nombredroga,tipodeenvase,pesoengramos,cantexistente,fechadevencimiento")] Bdrogueria bdrogueria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdrogueria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bdrogueria);
        }

        // GET: Bdroguerias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdrogueria bdrogueria = db.bdrogueria.Find(id);
            if (bdrogueria == null)
            {
                return HttpNotFound();
            }
            return View(bdrogueria);
        }

        // POST: Bdroguerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bdrogueria bdrogueria = db.bdrogueria.Find(id);
            db.bdrogueria.Remove(bdrogueria);
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
