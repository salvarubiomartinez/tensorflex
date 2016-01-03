using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Tensorflex.Models;
using PagedList;

namespace Tensorflex.Controllers
{
    public class ArticuloesController : Controller
    {
        private TensorflexEntities db = new TensorflexEntities();

        // GET: Articuloes
        public ActionResult Index(string searchString, string currentFilter,int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;



            if (!string.IsNullOrEmpty(searchString))
            
            {
                var respon = db.Articulos.Where(s => s.DescripcionArticulo.ToUpper().Contains(searchString.ToUpper())).OrderBy(s=>s.DescripcionArticulo);

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(respon.ToPagedList(pageNumber,pageSize));
            }
            else
            {
                var respon = db.Articulos.OrderBy(s => s.DescripcionArticulo).ToList();

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(respon.ToPagedList(pageNumber, pageSize));
            }

            
        }

        // GET: Articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articuloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articuloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEmpresa,CodigoArticulo,DescripcionArticulo,Descripcion2Articulo,CodigoAlternativo,CodigoAlternativo2,FechaAlta,CodigoFamilia,CodigoSubfamilia,StockMinimo,StockMaximo,PuntoPedido,PrecioCompra,PrecioVenta,C_Margen,id")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEmpresa,CodigoArticulo,DescripcionArticulo,Descripcion2Articulo,CodigoAlternativo,CodigoAlternativo2,FechaAlta,CodigoFamilia,CodigoSubfamilia,StockMinimo,StockMaximo,PuntoPedido,PrecioCompra,PrecioVenta,C_Margen,id")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulos.Find(id);
            db.Articulos.Remove(articulo);
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
