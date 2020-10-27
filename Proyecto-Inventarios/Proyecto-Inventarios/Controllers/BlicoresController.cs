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
    public class BlicoresController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Blicores
        public ActionResult Index()
        {
            return View(db.blicores.ToList());
        }

        // GET: Blicores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blicores blicores = db.blicores.Find(id);
            if (blicores == null)
            {
                return HttpNotFound();
            }
            return View(blicores);
        }

        // GET: Blicores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blicores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Blicores blicores)
        {
            if (ModelState.IsValid)
            {
                db.blicores.Add(blicores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blicores);
        }

        // GET: Blicores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blicores blicores = db.blicores.Find(id);
            if (blicores == null)
            {
                return HttpNotFound();
            }
            return View(blicores);
        }

        // POST: Blicores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Blicores blicores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blicores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blicores);
        }

        // GET: Blicores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blicores blicores = db.blicores.Find(id);
            if (blicores == null)
            {
                return HttpNotFound();
            }
            return View(blicores);
        }

        // POST: Blicores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Blicores blicores = db.blicores.Find(id);
            db.blicores.Remove(blicores);
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
