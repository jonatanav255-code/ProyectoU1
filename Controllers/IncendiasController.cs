using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PortalRegistroIncidencias.Models;



namespace PortalRegistroIncidencias.Controllers
{
    
    public class IncendiasController : Controller
    {
        private prueba1Entities db = new prueba1Entities();

        // GET: Incendias
        
        public ActionResult Index()
        {
            var Username = System.Web.HttpContext.Current.User.Identity.Name;
            
            var incendias = db.Incendias.Include(i => i.Empresa).Include(i => i.Estado_Incidencia_Id).Include(i => i.Tipo_Incidencia).Include(i => i.usuario);
            //return View(incendias.ToList());

            return View(incendias.ToList());
        }

        // GET: Incendias/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incendias = db.Incendias.Find(id);
            if (incendias == null)
            {
                return HttpNotFound();
            }
            return View(incendias);
        }

        // GET: Incendias/Create
        
        public ActionResult Create()
        {
            ViewBag.Empresa_Id = new SelectList(db.Empresa, "Id_Empresa", "Nombre_Empresa");
            ViewBag.Estado_Incidencias_Id = new SelectList(db.Estado_Incidencias, "Id_Estado_Incidencia", "Estado");
            //ViewBag.Fotografia_Id = new SelectList(, "Id_Fotografia", "Foto");
            ViewBag.Tipo_Incidencia_Id = new SelectList(db.Tipo_Incidencia, "Id_Tipo_Incidencia", "Nombre_Problematica");
            // ViewBag.usuario_id = System.Web.HttpContext.Current.User.Identity.Name;//new SelectList(db.usuario, "Id_usuario", "nombre");
            return View("~/Views/incendias/Create.cshtml");
          
        }
      

       // POST: Incendias/Create
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Incidencia,Latitud,Longitud,Dirrecion,Detalle,Tipo_Incidencia_Id,Empresa_Id,Fotografia1,Estado_Incidencias_Id,usuario_id")] Incidencias incendias)
        {
            incendias.Fotografia1 = new byte[] { 0x10, 0x11, 0x12 };
            incendias.usuario_id = 1;
            /*HttpFileCollectionBase FileBase = Request.Files;

            WebImage image = new WebImage(FileBase.InputStream);

            incendias.Fotografia1 = image.GetBytes();
            */
            if (ModelState.IsValid)
            {
                db.Incendias.Add(incendias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa_Id = new SelectList(db.Empresa, "Id_Empresa", "Nombre_Empresa", incendias.Empresa_Id);
            ViewBag.Estado_Incidencias_Id = new SelectList(db.Estado_Incidencias, "Id_Estado_Incidencia", "Estado", incendias.Estado_Incidencias_Id);
            //ViewBag.Fotografia_Id = new SelectList(db.Fotografia, "Id_Fotografia", "Foto", incendias.Fotografia1);
            ViewBag.Tipo_Incidencia_Id = new SelectList(db.Tipo_Incidencia, "Id_Tipo_Incidencia", "Nombre_Problematica", incendias.Tipo_Incidencia_Id);
            //ViewBag.usuario_id = new SelectList(db.usuario, "Id_usuario", "nombre", incendias.usuario_id);

            return View(incendias);
        }

        // GET: Incendias/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incendias = db.Incendias.Find(id);
            if (incendias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa_Id = new SelectList(db.Empresa, "Id_Empresa", "Nombre_Empresa", incendias.Empresa_Id);
            ViewBag.Estado_Incidencias_Id = new SelectList(db.Estado_Incidencias, "Id_Estado_Incidencia", "Estado", incendias.Estado_Incidencias_Id);
            //ViewBag.Fotografia_Id = new SelectList(db.Fotografia, "Id_Fotografia", "Foto", incendias.Fotografia1);
            ViewBag.Tipo_Incidencia_Id = new SelectList(db.Tipo_Incidencia, "Id_Tipo_Incidencia", "Nombre_Problematica", incendias.Tipo_Incidencia_Id);
            ViewBag.usuario_id = new SelectList(db.usuario, "Id_usuario", "nombre", incendias.usuario_id);
            return View(incendias);
        }

        // POST: Incendias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Incidencia,Latitud,Longitud,Dirrecion,Detalle,Tipo_Incidencia_Id,Empresa_Id,Fotografia_Id,Estado_Incidencias_Id,usuario_id")] Incidencias incendias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incendias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empresa_Id = new SelectList(db.Empresa, "Id_Empresa", "Nombre_Empresa", incendias.Empresa_Id);
            ViewBag.Estado_Incidencias_Id = new SelectList(db.Estado_Incidencias, "Id_Estado_Incidencia", "Estado", incendias.Estado_Incidencias_Id);
            //ViewBag.Fotografia_Id = new SelectList(db.Fotografia, "Id_Fotografia", "Foto", incendias.Fotografia1);
            ViewBag.Tipo_Incidencia_Id = new SelectList(db.Tipo_Incidencia, "Id_Tipo_Incidencia", "Nombre_Problematica", incendias.Tipo_Incidencia_Id);
            ViewBag.usuario_id = new SelectList(db.usuario, "Id_usuario", "nombre", incendias.usuario_id);
            return View(incendias);
        }

        // GET: Incendias/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencias incendias = db.Incendias.Find(id);
            if (incendias == null)
            {
                return HttpNotFound();
            }
            return View(incendias);
        }

        // POST: Incendias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Incidencias incendias = db.Incendias.Find(id);
            db.Incendias.Remove(incendias);
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