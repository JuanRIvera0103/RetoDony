using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Entities
{
    public class Area
    {
        [Key]
        [Display(Name = "Id")]
        public int Idarea { get; set; }
        [Required]
        [Display(Name = "Nombre Area")]
        public string Nombrearea { get; set; }
    }
}