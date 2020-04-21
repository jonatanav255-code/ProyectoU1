using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MailKit.Net.Smtp;
using MimeKit;
using PortalRegistroIncidencias.Models;

namespace PortalRegistroIncidencias.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private prueba1Entities db = new prueba1Entities();

        public ActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Autorize(usuario UserModel)
        {

            var userdetails = db.usuario.Where(x => x.correo_electronico == UserModel.correo_electronico && x.contrasena == UserModel.contrasena).FirstOrDefault();


            if (userdetails == null)
            {
               
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["userID"] = userdetails.Id_usuario;
                FormsAuthentication.SetAuthCookie(UserModel.correo_electronico, true);

                //return RedirectToAction("");

                return View("Confirmar");


            }
        }
        [Authorize]
        public ActionResult logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
      
        [HttpGet]
        public ActionResult ConfirmarCodigo(usuario UserModel)
        {

            var userdetails = db.usuario.Where(x => x.codigo_activacion == UserModel.codigo_activacion).FirstOrDefault();


            if (userdetails == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["userID"] = userdetails.Id_usuario;


                //return RedirectToAction("");

                return View("Confirmar");
            }
        }
    }
}





