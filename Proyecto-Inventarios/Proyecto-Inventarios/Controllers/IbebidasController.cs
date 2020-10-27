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
    public class IbebidasController : Controller
    {
        private ConexionBd db = new ConexionBd();

        // GET: Ibebidas
        public ActionResult Index()
        {
            return View(db.ibebidas.ToList());
        }

        // GET: Ibebidas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibebidas ibebidas = db.ibebidas.Find(id);
            if (ibebidas == null)
            {
                return HttpNotFound();
            }
            return View(ibebidas);
        }

        // GET: Ibebidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ibebidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ibebidas ibebidas)
        {
            if (ModelState.IsValid)
            {
                db.ibebidas.Add(ibebidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ibebidas);
        }

        // GET: Ibebidas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibebidas ibebidas = db.ibebidas.Find(id);
            if (ibebidas == null)
            {
                return HttpNotFound();
            }
            return View(ibebidas);
        }

        // POST: Ibebidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcadebebida,tipodebebida,tipodeenvase,cantenml,cantexistente,zonasupermercado,fechadevencimiento")] Ibebidas ibebidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ibebidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ibebidas);
        }

        // GET: Ibebidas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibebidas ibebidas = db.ibebidas.Find(id);
            if (ibebidas == null)
            {
                return HttpNotFound();
            }
            return View(ibebidas);
        }

        // POST: Ibebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ibebidas ibebidas = db.ibebidas.Find(id);
            db.ibebidas.Remove(ibebidas);
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
