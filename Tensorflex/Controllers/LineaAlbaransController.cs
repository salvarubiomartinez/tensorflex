using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tensorflex.Models;

namespace Tensorflex.Controllers
{
    public class LineaAlbaransController : Controller
    {
        private TensorflexEntities db = new TensorflexEntities();

        // GET: LineaAlbarans
        public ActionResult Index()
        {
            var lineaAlbarans = db.LineaAlbarans.Include(l => l.Albarán).Include(l => l.Articulo);
            return View(lineaAlbarans.ToList());
        }

        // GET: LineaAlbarans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaAlbaran lineaAlbaran = db.LineaAlbarans.Find(id);
            if (lineaAlbaran == null)
            {
                return HttpNotFound();
            }
            return View(lineaAlbaran);
        }

        // GET: LineaAlbarans/Create
        public ActionResult Create()
        {
            ViewBag.AlbaranId = new SelectList(db.Albarán, "Id", "Id");
            ViewBag.ArticuloId = new SelectList(db.Articulos.OrderBy(a=>a.DescripcionArticulo), "id", "DescripcionArticulo");
            return View();
        }

        // POST: LineaAlbarans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlbaranId,ArticuloId,Cantidad,Precio")] LineaAlbaran lineaAlbaran)
        {
            if (ModelState.IsValid)
            {
                db.LineaAlbarans.Add(lineaAlbaran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbaranId = new SelectList(db.Albarán, "Id", "Id", lineaAlbaran.AlbaranId);
            ViewBag.ArticuloId = new SelectList(db.Articulos.OrderBy(a => a.DescripcionArticulo), "id", "DescripcionArticulo", lineaAlbaran.ArticuloId);
            return View(lineaAlbaran);
        }

        // GET: LineaAlbarans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaAlbaran lineaAlbaran = db.LineaAlbarans.Find(id);
            if (lineaAlbaran == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbaranId = new SelectList(db.Albarán, "Id", "Id", lineaAlbaran.AlbaranId);
            ViewBag.ArticuloId = new SelectList(db.Articulos.OrderBy(a => a.DescripcionArticulo), "id", "DescripcionArticulo", lineaAlbaran.ArticuloId);
            return View(lineaAlbaran);
        }

        // POST: LineaAlbarans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlbaranId,ArticuloId,Cantidad,Precio")] LineaAlbaran lineaAlbaran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaAlbaran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbaranId = new SelectList(db.Albarán, "Id", "Id", lineaAlbaran.AlbaranId);
            ViewBag.ArticuloId = new SelectList(db.Articulos.OrderBy(a => a.DescripcionArticulo), "id", "DescripcionArticulo", lineaAlbaran.ArticuloId);
            return View(lineaAlbaran);
        }

        // GET: LineaAlbarans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaAlbaran lineaAlbaran = db.LineaAlbarans.Find(id);
            if (lineaAlbaran == null)
            {
                return HttpNotFound();
            }
            return View(lineaAlbaran);
        }

        // POST: LineaAlbarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaAlbaran lineaAlbaran = db.LineaAlbarans.Find(id);
            db.LineaAlbarans.Remove(lineaAlbaran);
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
