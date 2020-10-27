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
    public class IenlatadosController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ienlatados
        public ActionResult Index()
        {
            return View(db.ienlatados.ToList());
        }

        // GET: Ienlatados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ienlatados ienlatados = db.ienlatados.Find(id);
            if (ienlatados == null)
            {
                return HttpNotFound();
            }
            return View(ienlatados);
        }

        // GET: Ienlatados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ienlatados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ienlatados ienlatados)
        {
            if (ModelState.IsValid)
            {
                db.ienlatados.Add(ienlatados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ienlatados);
        }

        // GET: Ienlatados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ienlatados ienlatados = db.ienlatados.Find(id);
            if (ienlatados == null)
            {
                return HttpNotFound();
            }
            return View(ienlatados);
        }

        // POST: Ienlatados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ienlatados ienlatados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ienlatados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ienlatados);
        }

        // GET: Ienlatados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ienlatados ienlatados = db.ienlatados.Find(id);
            if (ienlatados == null)
            {
                return HttpNotFound();
            }
            return View(ienlatados);
        }

        // POST: Ienlatados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ienlatados ienlatados = db.ienlatados.Find(id);
            db.ienlatados.Remove(ienlatados);
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
