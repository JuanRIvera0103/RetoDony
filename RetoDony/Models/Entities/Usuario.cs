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
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Tipo de Documento")]
        public string Tipodocumento { get; set; }
        [Required]
        [Display(Name = "Número Documento")]
        public string Documento { get; set; }
        [Required]
        public int Cargo { get; set; }
    }
}