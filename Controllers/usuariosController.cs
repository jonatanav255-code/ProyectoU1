using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using PortalRegistroIncidencias.Models;

namespace PortalRegistroIncidencias.Controllers
{
    public class usuariosController : Controller
    {
        private ModelincidenciaContainer db = new ModelincidenciaContainer();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.habilitado);
            return View(usuario.ToList());
        }
        public  ActionResult lugares() {
            /*

            string apiUrl = "http://localhost:58764/api/values";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }
            }*/

                return View();
            /*
            IEnumerable<provincia> customer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ubicaciones.paginasweb.cr/provincias.json");
                var respondeTask = client.GetAsync("customer");
                respondeTask.Wait();

                var result = respondeTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<provincia>>();
                    readJob.Wait();
                    customer = readJob.Result;
                }
                else
                {
                    customer = Enumerable.Empty<provincia>();
                    ModelState.AddModelError(string.Empty, "error ocurred. Please Contact");
                }
            }
            */

          
        }
        // GET: usuarios/Details/5
        public ActionResult Details(short? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
           // ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar");
            return View("~/Views/usuarios/Create.cshtml");
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_usuario,habilitado_id,nombre,primer_apellido,segundo_apellido,correo_electronico,contrasena,direccion,codigo_activacion,telefono,Cedula")] usuario usuario)
        {
            usuario.habilitado_id = 2;
            usuario.Cedula = "pruebas";

            Random re = new Random();
            usuario.codigo_activacion = re.Next().ToString();
            
            
            
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("prueba", "jonatanav2555@gmail.com"));
                message.To.Add(new MailboxAddress("prueba", "jonatanav255@hotmail.com"));
                message.Subject = "Test de correo electronico";
                message.Body = new TextPart("plain")
                {
                    Text = usuario.codigo_activacion
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    client.Authenticate("jonatanav2555@gmail.com", "moneda@123");


                    client.Send(message);
                    client.Disconnect(true);

                }
                return RedirectToAction("Index");
                
            }

           // ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar", usuario.habilitado_id);
            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar", usuario.habilitado_id);
            return View(usuario);
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_usuario,habilitado_id,nombre,primer_apellido,segundo_apellido,correo_electronico,contrasena,direccion,codigo_activacion")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar", usuario.habilitado_id);
            return View(usuario);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
