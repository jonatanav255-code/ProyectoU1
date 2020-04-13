using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

using MailKit.Net.Smtp;
using MimeKit;
using PortalRegistroIncidencias.Models;

namespace PortalRegistroIncidencias.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private prueba1Entities db = new  prueba1Entities ();

        public ActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Autorize(PortalRegistroIncidencias.Models.usuario UserModel)
        {

            var userdetails = db.usuario.Where(x => x.correo_electronico == UserModel.correo_electronico && x.contrasena == UserModel.contrasena).FirstOrDefault();


            if (userdetails == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["userID"] = userdetails.Id_usuario;


                //return RedirectToAction("");
                return View("~/Views/Shared/Error.cshtml");


            }
        }

    }
}
 
    
        
    
