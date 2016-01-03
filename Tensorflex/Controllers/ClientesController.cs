using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tensorflex.Models;
using PagedList;

namespace Tensorflex.Controllers
{
    public class ClientesController : Controller
    {
        private TensorflexEntities db = new TensorflexEntities();

        // GET: Clientes
        public ActionResult Index(string searchString, string currentFilter, int? page)
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
                var respon = db.Clientes.Where(s => s.RazonSocial.ToUpper().Contains(searchString.ToUpper())).OrderBy(s => s.RazonSocial);

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(respon.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var respon = db.Clientes.OrderBy(s => s.RazonSocial).ToList();

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(respon.ToPagedList(pageNumber, pageSize));
            }


        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEmpresa,IdDelegacion,CodigoCliente,SiglaNacion,CifDni,CifEuropeo,FechaAlta,CodigoProveedor,CodigoContable,RazonSocial,RazonSocial2,Nombre,Domicilio,Domicilio2,Nombre1,FormadePago,CodigoBanco,CodigoAgencia,DC,CCC,IBAN,CodigoZona,CodigoRuta_,CodigoTransportista,TipoPortes,ObservacionesCliente,Comentarios,CodigoSigla,ViaPublica,Numero1,Numero2,Escalera,Piso,Puerta,Letra,CodigoPostal,CodigoMunicipio,Municipio,ColaMunicipio,CodigoProvincia,Provincia,CodigoNacion,Nacion,Telefono,Telefono2,Telefono3,Fax,Email1,HorarioDomicilioLc,id")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEmpresa,IdDelegacion,CodigoCliente,SiglaNacion,CifDni,CifEuropeo,FechaAlta,CodigoProveedor,CodigoContable,RazonSocial,RazonSocial2,Nombre,Domicilio,Domicilio2,Nombre1,FormadePago,CodigoBanco,CodigoAgencia,DC,CCC,IBAN,CodigoZona,CodigoRuta_,CodigoTransportista,TipoPortes,ObservacionesCliente,Comentarios,CodigoSigla,ViaPublica,Numero1,Numero2,Escalera,Piso,Puerta,Letra,CodigoPostal,CodigoMunicipio,Municipio,ColaMunicipio,CodigoProvincia,Provincia,CodigoNacion,Nacion,Telefono,Telefono2,Telefono3,Fax,Email1,HorarioDomicilioLc,id")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
