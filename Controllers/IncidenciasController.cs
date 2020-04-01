using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalRegistroIncidencias.Models;
using System.Data.Entity;

namespace PortalRegistroIncidencias.Controllers
{
    public class IncidenciasController : Controller
    {
        private ModelincidenciaContainer db = new ModelincidenciaContainer();
        // GET: Incidencias
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id_Incidencia,Latitud,Longitud,Detalle,Tipo_Incidencia_Id,Empresa_Id,Estado_Incidencia_Id,Fotografia_Id,Provincia_Id,Canton_Id,Distrito_Id,Usuario_Id")] Incidencias incidencias)
        {
            if(ModelState.IsValid)
            {
                //db.incidencia.Add(incidencias);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidencias);
        }


    }
}