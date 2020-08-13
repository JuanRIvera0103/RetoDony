using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int Idusuario { get; set; }
        public string Nombre { get; set; }        
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Cargo { get; set; }
    }
}