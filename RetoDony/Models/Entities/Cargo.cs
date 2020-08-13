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
        public int Idcargo { get; set; }
        public int Area { get; set; }
        public string Nombre { get; set; }
    }
}