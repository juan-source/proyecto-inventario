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
    public class IpalimenticiosController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ipalimenticios
        public ActionResult Index()
        {
            return View(db.ipalimenticios.ToList());
        }

        // GET: Ipalimenticios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipalimenticios ipalimenticios = db.ipalimenticios.Find(id);
            if (ipalimenticios == null)
            {
                return HttpNotFound();
            }
            return View(ipalimenticios);
        }

        // GET: Ipalimenticios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ipalimenticios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado,fechadevencimiento")] Ipalimenticios ipalimenticios)
        {
            if (ModelState.IsValid)
            {
                db.ipalimenticios.Add(ipalimenticios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ipalimenticios);
        }

        // GET: Ipalimenticios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipalimenticios ipalimenticios = db.ipalimenticios.Find(id);
            if (ipalimenticios == null)
            {
                return HttpNotFound();
            }
            return View(ipalimenticios);
        }

        // POST: Ipalimenticios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado,fechadevencimiento")] Ipalimenticios ipalimenticios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipalimenticios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ipalimenticios);
        }

        // GET: Ipalimenticios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ipalimenticios ipalimenticios = db.ipalimenticios.Find(id);
            if (ipalimenticios == null)
            {
                return HttpNotFound();
            }
            return View(ipalimenticios);
        }

        // POST: Ipalimenticios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ipalimenticios ipalimenticios = db.ipalimenticios.Find(id);
            db.ipalimenticios.Remove(ipalimenticios);
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
