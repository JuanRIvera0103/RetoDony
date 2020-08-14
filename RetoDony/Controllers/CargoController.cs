using RetoDony.Models.Business;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetoDony.Controllers
{
    public class CargoController : Controller
    {
        private readonly CargoService cargoservicio = new CargoService();
        public ActionResult MostrarCargos()
        {
            return View(cargoservicio.EncontrarTodosLosCargos());
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (cargo != null)
                {
                    cargoservicio.GuardarCargo(cargo);
                    return RedirectToAction("MostrarCargos");
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

            Cargo cargo = cargoservicio.EncontrarCargo(id.Value);
            if (cargo == null)
            {
                return View();
            }

            return View(cargo);
        }

        [HttpPost]
        public ActionResult Editar(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargoservicio.EditarCargo(cargo);
                return RedirectToAction("MostrarCargos");
            }

            return View(cargo);
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Cargo cargo = cargoservicio.EncontrarCargo(id.Value);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Cargo cargo = cargoservicio.EncontrarCargo(id.Value);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            cargoservicio.EliminarCargo(id);
            return RedirectToAction("MostrarCargos");
        }
    }
}