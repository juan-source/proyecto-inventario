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
    public class BproductosAlimentsController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: BproductosAliments
        public ActionResult Index()
        {
            return View(db.bproductosAliment.ToList());
        }

        // GET: BproductosAliments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosAliment bproductosAliment = db.bproductosAliment.Find(id);
            if (bproductosAliment == null)
            {
                return HttpNotFound();
            }
            return View(bproductosAliment);
        }

        // GET: BproductosAliments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BproductosAliments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado,fechadevencimiento")] BproductosAliment bproductosAliment)
        {
            if (ModelState.IsValid)
            {
                db.bproductosAliment.Add(bproductosAliment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bproductosAliment);
        }

        // GET: BproductosAliments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosAliment bproductosAliment = db.bproductosAliment.Find(id);
            if (bproductosAliment == null)
            {
                return HttpNotFound();
            }
            return View(bproductosAliment);
        }

        // POST: BproductosAliments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadeproducto,tipodeproducto,tipodeenvaseopaquete,cantenpesooml,cantexistente,zonasupermercado,fechadevencimiento")] BproductosAliment bproductosAliment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bproductosAliment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bproductosAliment);
        }

        // GET: BproductosAliments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BproductosAliment bproductosAliment = db.bproductosAliment.Find(id);
            if (bproductosAliment == null)
            {
                return HttpNotFound();
            }
            return View(bproductosAliment);
        }

        // POST: BproductosAliments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BproductosAliment bproductosAliment = db.bproductosAliment.Find(id);
            db.bproductosAliment.Remove(bproductosAliment);
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
