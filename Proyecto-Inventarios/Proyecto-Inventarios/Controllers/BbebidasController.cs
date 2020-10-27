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
    public class BbebidasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Bbebidas
        public ActionResult Index()
        {
            return View(db.bebidas.ToList());
        }

        // GET: Bbebidas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bbebida bbebida = db.bebidas.Find(id);
            if (bbebida == null)
            {
                return HttpNotFound();
            }
            return View(bbebida);
        }

        // GET: Bbebidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bbebidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Bbebida bbebida)
        {
            if (ModelState.IsValid)
            {
                db.bebidas.Add(bbebida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bbebida);
        }

        // GET: Bbebidas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bbebida bbebida = db.bebidas.Find(id);
            if (bbebida == null)
            {
                return HttpNotFound();
            }
            return View(bbebida);
        }

        // POST: Bbebidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Bbebida bbebida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bbebida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bbebida);
        }

        // GET: Bbebidas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bbebida bbebida = db.bebidas.Find(id);
            if (bbebida == null)
            {
                return HttpNotFound();
            }
            return View(bbebida);
        }

        // POST: Bbebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bbebida bbebida = db.bebidas.Find(id);
            db.bebidas.Remove(bbebida);
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
