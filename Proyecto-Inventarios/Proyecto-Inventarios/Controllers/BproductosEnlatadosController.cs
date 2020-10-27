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
    public class BproductosEnlatadosController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: BproductosEnlatados
        public ActionResult Index()
        {
            return View(db.bproductosEnlatados.ToList());
        }

        // GET: BproductosEnlatados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosEnlatados bproductosEnlatados = db.bproductosEnlatados.Find(id);
            if (bproductosEnlatados == null)
            {
                return HttpNotFound();
            }
            return View(bproductosEnlatados);
        }

        // GET: BproductosEnlatados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BproductosEnlatados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] BproductosEnlatados bproductosEnlatados)
        {
            if (ModelState.IsValid)
            {
                db.bproductosEnlatados.Add(bproductosEnlatados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bproductosEnlatados);
        }

        // GET: BproductosEnlatados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosEnlatados bproductosEnlatados = db.bproductosEnlatados.Find(id);
            if (bproductosEnlatados == null)
            {
                return HttpNotFound();
            }
            return View(bproductosEnlatados);
        }

        // POST: BproductosEnlatados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] BproductosEnlatados bproductosEnlatados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bproductosEnlatados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bproductosEnlatados);
        }

        // GET: BproductosEnlatados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosEnlatados bproductosEnlatados = db.bproductosEnlatados.Find(id);
            if (bproductosEnlatados == null)
            {
                return HttpNotFound();
            }
            return View(bproductosEnlatados);
        }

        // POST: BproductosEnlatados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BproductosEnlatados bproductosEnlatados = db.bproductosEnlatados.Find(id);
            db.bproductosEnlatados.Remove(bproductosEnlatados);
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
