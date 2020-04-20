﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNetCore.Identity;
using PortalRegistroIncidencias.Models;

namespace PortalRegistroIncidencias.Controllers
{
    public class usuarioController : Controller
    {
                

            private prueba1Entities db = new prueba1Entities();


            // GET: usuario
            public ActionResult Index()
            {
                var usuario = db.usuario.Include(u => u.habilitado).Include(u => u.provincia).Include(u => u.canton).Include(u => u.distrito);
                return View(usuario.ToList());
            }

            // GET: usuario/Details/5
            public ActionResult Details(short? id)
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

            // GET: usuario/Create
            public ActionResult Create()
            {
                ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar");
                ViewBag.provinciaId = new SelectList(db.provincia, "Id", "nombre_provincia");
                ViewBag.canton_id = new SelectList(db.canton, "Id", "nombre_canton");
                ViewBag.distrito_Id = new SelectList(db.distrito, "Id", "nombre_distrito");
                return View();
            }

            // POST: usuario/Create
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id_usuario,habilitado_id,nombre,primer_apellido,segundo_apellido,correo_electronico,contrasena,direccion,codigo_activacion,telefono,cedula,provinciaId,canton_id,distrito_Id")] usuario usuario)
            {
                usuario.habilitado_id = 2;
                usuario.codigo_activacion = "hola";
                if (ModelState.IsValid)
                {
                    db.usuario.Add(usuario);
                        db.SaveChanges();
                        return View("Error");
                    }
                                
                
                ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar", usuario.habilitado_id);
                ViewBag.provinciaId = new SelectList(db.provincia, "Id", "nombre_provincia", usuario.provinciaId);
                ViewBag.canton_id = new SelectList(db.canton, "Id", "nombre_canton", usuario.canton_id);
                ViewBag.distrito_Id = new SelectList(db.distrito, "Id", "nombre_distrito", usuario.distrito_Id);
                return View(usuario);
            }

            // GET: usuario/Edit/5
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
                ViewBag.provinciaId = new SelectList(db.provincia, "Id", "nombre_provincia", usuario.provinciaId);
                ViewBag.canton_id = new SelectList(db.canton, "Id", "nombre_canton", usuario.canton_id);
                ViewBag.distrito_Id = new SelectList(db.distrito, "Id", "nombre_distrito", usuario.distrito_Id);
                return View(usuario);
            }

            // POST: usuario/Edit/5
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id_usuario,habilitado_id,nombre,primer_apellido,segundo_apellido,correo_electronico,contrasena,direccion,codigo_activacion,telefono,cedula,provinciaId,canton_id,distrito_Id")] usuario usuario)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.habilitado_id = new SelectList(db.habilitado, "Id_habilitado", "habilitar", usuario.habilitado_id);
                ViewBag.provinciaId = new SelectList(db.provincia, "Id", "nombre_provincia", usuario.provinciaId);
                ViewBag.canton_id = new SelectList(db.canton, "Id", "nombre_canton", usuario.canton_id);
                ViewBag.distrito_Id = new SelectList(db.distrito, "Id", "nombre_distrito", usuario.distrito_Id);
                return View(usuario);
            }

            // GET: usuario/Delete/5
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

            // POST: usuario/Delete/5
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

