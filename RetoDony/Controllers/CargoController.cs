using RetoDony.Models.Business;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace RetoDony.Controllers
{
    public class CargoController : Controller
    {
        private readonly CargoService cargoservicio = new CargoService();
        public ActionResult MostrarCargos()
        {
            AreaService areaservicio = new AreaService();
            var listacargos = cargoservicio.EncontrarTodosLosCargos();
            var listaareas = areaservicio.EncontrarTodasLasAreas();

            var result = (from carg in listacargos
                          join area in listaareas
                          on carg.Area equals area.Idarea
                          select new { Cargo = carg, Area = area }
            );
            List<CargoArea> cargoarea = new List<CargoArea>();

            foreach (var item in result)
            {                
                var cargo = item.Cargo;
                var area = item.Area;
                CargoArea cargoa = new CargoArea(cargo.Idcargo, area.Idarea, area.Nombrearea, cargo.Nombre);

                cargoarea.Add(cargoa);
            }

            return View(cargoarea);
        }
        public ActionResult Crear()
        {            
            AreaService areaservicio = new AreaService();
            var cn = areaservicio.Conexion();
            List<Area> lst = null;
            using (cn)
            {
                lst = new List<Area>();
                foreach (var d in cn.Area)
                {
                    lst.Add(new Area
                       {
                           Idarea = d.Idarea,
                           Nombrearea = d.Nombrearea
                       });
                }
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombrearea.ToString(),
                    Value = d.Idarea.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items; 
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

            AreaService areaservicio = new AreaService();
            var cn = areaservicio.Conexion();
            List<Area> lst = null;
            using (cn)
            {
                lst = new List<Area>();
                foreach (var d in cn.Area)
                {
                    lst.Add(new Area
                    {
                        Idarea = d.Idarea,
                        Nombrearea = d.Nombrearea
                    });
                }
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombrearea.ToString(),
                    Value = d.Idarea.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

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