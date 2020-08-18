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
            CargoService cargoservicio = new CargoService();
            var listacargos = cargoservicio.EncontrarTodosLosCargos();
            var listausuarios = usuarioservicio.EncontrarTodosLosUsuarios();

            var result = (from emp in listausuarios
                          join carg in listacargos
                          on emp.Cargo equals carg.Idcargo
                          select new { Usuario = emp, Cargo = carg }
            );
            List<UsuarioCargo> usuariocargo = new List<UsuarioCargo>();
             
            foreach (var item in result)
            {
                var usuario = item.Usuario;
                var cargo = item.Cargo;
                UsuarioCargo uscar = new UsuarioCargo(usuario.Idusuario, usuario.Nombre, 
                    usuario.Telefono, usuario.Direccion, usuario.Email, usuario.Edad,
                    usuario.Tipodocumento, usuario.Documento, cargo.Idcargo ,cargo.Nombre);

                usuariocargo.Add(uscar);
            }

            return View(usuariocargo);
            
        }
        public ActionResult Crear()
        {
            CargoService cargoservicio = new CargoService();
            var cn = cargoservicio.Conexion();
            List<Cargo> lst = null;
            using (cn)
            {
                lst = new List<Cargo>();
                foreach (var c in cn.Cargo)
                {
                    lst.Add(new Cargo
                    {
                        Idcargo = c.Idcargo,
                        Nombre = c.Nombre                        
                    });
                }
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Idcargo.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
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


            CargoService cargoservicio = new CargoService();
            var cn = cargoservicio.Conexion();
            List<Cargo> lst = null;
            using (cn)
            {
                lst = new List<Cargo>();
                foreach (var c in cn.Cargo)
                {
                    lst.Add(new Cargo
                    {
                        Idcargo = c.Idcargo,
                        Nombre = c.Nombre
                    });
                }
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Idcargo.ToString(),
                    Selected = false                    
                };
            });

            ViewBag.items = items;
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