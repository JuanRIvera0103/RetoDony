using RetoDony.Models.Business;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetoDony.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        private readonly AreaService areaservicio = new AreaService();
        public ActionResult MostrarAreas()
        {
            return View(areaservicio.EncontrarTodasLasAreas());
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Area area)
        {
            if (ModelState.IsValid)
            {
                if (area != null)
                {
                    areaservicio.GuardarArea(area);
                    return RedirectToAction("MostrarAreas");
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

            Area area = areaservicio.EncontrarArea(id.Value);
            if (area == null)
            {
                return View();
            }

            return View(area);
        }

        [HttpPost]
        public ActionResult Editar(Area area)
        {
            if (ModelState.IsValid)
            {
                areaservicio.EditarArea(area);
                return RedirectToAction("MostrarAreas");
            }

            return View(area);
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var area = areaservicio.EncontrarArea(id.Value);

            if (area == null)
            {
                return HttpNotFound();
            }

            return View(area);

        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var area = areaservicio.EncontrarArea(id.Value);

            if (area == null)
            {
                return HttpNotFound();
            }

            return View(area);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            areaservicio.EliminarArea(id);
            return RedirectToAction("MostrarAreas");
        }
    }
}