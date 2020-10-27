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
    public class IlicoresController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ilicores
        public ActionResult Index()
        {
            return View(db.ilicores.ToList());
        }

        // GET: Ilicores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilicores ilicores = db.ilicores.Find(id);
            if (ilicores == null)
            {
                return HttpNotFound();
            }
            return View(ilicores);
        }

        // GET: Ilicores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ilicores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ilicores ilicores)
        {
            if (ModelState.IsValid)
            {
                db.ilicores.Add(ilicores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilicores);
        }

        // GET: Ilicores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilicores ilicores = db.ilicores.Find(id);
            if (ilicores == null)
            {
                return HttpNotFound();
            }
            return View(ilicores);
        }

        // POST: Ilicores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ilicores ilicores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilicores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilicores);
        }

        // GET: Ilicores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilicores ilicores = db.ilicores.Find(id);
            if (ilicores == null)
            {
                return HttpNotFound();
            }
            return View(ilicores);
        }

        // POST: Ilicores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ilicores ilicores = db.ilicores.Find(id);
            db.ilicores.Remove(ilicores);
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
