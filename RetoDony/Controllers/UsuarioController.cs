using RetoDony.Models.Business;
using RetoDony.Models.DAL;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetoDony.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService usuarioservicio = new UsuarioService();
        // GET: Usuario
        public ActionResult MostrarUsuario()
        {            
            return View(usuarioservicio.EncontrarTodosLosUsuarios());
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario != null)
                {
                    usuarioservicio.GuardarUsuario(usuario);
                    return RedirectToAction("MostrarUsuario");
                }                
            }
            return View();
        }
        
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            Usuario usuario = usuarioservicio.EncontrarUsuario(id.Value);     
            if(usuario == null)
            {
                return View();
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioservicio.EditarUsuario(usuario);
                return RedirectToAction("MostrarUsuario");
            }

            return View(usuario);
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);                
            }

            var usuario = usuarioservicio.EncontrarUsuario(id.Value);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var usuario = usuarioservicio.EncontrarUsuario(id.Value);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            usuarioservicio.EliminarUsuario(id);
            return RedirectToAction("MostrarUsuario");
        }
    }
}