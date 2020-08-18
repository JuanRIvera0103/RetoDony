using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Entities
{
    public class CargoArea
    {
        [Display(Name = "Id")]
        public int Idcargo { get; set; }
        public int IdArea { get; set; }
        [Display (Name = "Area")]
        public string NombreArea { get; set; }
        public string Nombre { get; set; }

        public CargoArea(int idcargo, int idarea, string nombrearea, string nombre)
        {
            Idcargo = idcargo;
            IdArea = idarea;
            NombreArea = nombrearea;
            Nombre = nombre;
        }
    }
}