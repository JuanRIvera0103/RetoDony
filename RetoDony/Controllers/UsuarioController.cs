using RetoDony.Models.DAL;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetoDony.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Usuario
        public ActionResult MostrarUsuario()
        {
            List<Usuario> listaUsuario = _context.Usuario.ToList();
            return View(listaUsuario);
        }
    }
}