using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Entities
{
    public class Cargo
    {
        [Key]
        [Display(Name = "Id")]
        public int Idcargo { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}