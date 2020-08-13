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
        public int Idarea { get; set; }
        public string Nombrearea { get; set; }
    }
}