using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tensorflex.Models;

namespace Tensorflex.Controllers
{
    public class AlbaránController : Controller
    {
        private TensorflexEntities db = new TensorflexEntities();

        // GET: Albarán
        public ActionResult Index()
        {
            var albarán = db.Albarán.Include(a => a.Cliente);
            return View(albarán.ToList());
        }

        // GET: Albarán/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albarán albarán = db.Albarán.Find(id);
            if (albarán == null)
            {
                return HttpNotFound();
            }
            return View(albarán);
        }

        // GET: Albarán/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes.OrderBy(a=>a.RazonSocial), "id", "RazonSocial");
            return View();
        }

        // POST: Albarán/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,Fecha")] Albarán albarán)
        {
            if (ModelState.IsValid)
            {
                db.Albarán.Add(albarán);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes.OrderBy(a => a.RazonSocial), "id", "RazonSocial", albarán.ClienteId);
            return View(albarán);
        }

        // GET: Albarán/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albarán albarán = db.Albarán.Find(id);
            if (albarán == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.OrderBy(a => a.RazonSocial), "id", "RazonSocial", albarán.ClienteId);
            return View(albarán);
        }

        // POST: Albarán/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,Fecha")] Albarán albarán)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albarán).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.OrderBy(a => a.RazonSocial), "id", "RazonSocial", albarán.ClienteId);
            return View(albarán);
        }

        // GET: Albarán/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albarán albarán = db.Albarán.Find(id);
            if (albarán == null)
            {
                return HttpNotFound();
            }
            return View(albarán);
        }

        // POST: Albarán/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albarán albarán = db.Albarán.Find(id);
            db.Albarán.Remove(albarán);
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
