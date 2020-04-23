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
               
            //bool correoInvalido = db.usuario.Any(x => x.correo_electronico == UserModel.correo_electronico);
            bool Sincodigo = db.usuario.Any(x => x.habilitado_id == UserModel.habilitado_id);




            if (Sincodigo)
            {
                // ViewBag.errorMessage = "You must have a confirmed email to log on. "
                //            + "The confirmation token has been resent to your email account.";
                return View("Error");

            }
            else
            {
               


                FormsAuthentication.SetAuthCookie(UserModel.correo_electronico, true);

                Session["userID"] = userdetails.Id_usuario;
                Session["codigoActivacion"] = userdetails.codigo_activacion;
                Session["habilitado"] = userdetails.habilitado_id;
                Session["correo"] = userdetails.correo_electronico;

                //return RedirectToAction("");


                return View("Confirmar");

            }
        }

        //   if (Session["UserID"] == null) {}


        [Authorize]
        public ActionResult logout()
        {
           
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}


   





