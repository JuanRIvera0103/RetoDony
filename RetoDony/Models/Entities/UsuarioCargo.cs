using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Entities
{
    public class UsuarioCargo
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }        
        public string Email { get; set; }
        public int Edad { get; set; }
        [Display(Name = "Tipo de Documento")]
        public string Tipodocumento { get; set; }
        [Display(Name = "Número Documento")]
        public string Documento { get; set; }

        public int Idcargo { get; set; }

        [Display(Name = "Cargo" )]
        public string NombreCargo { get; set; }

        public UsuarioCargo(int idusuario, string nombre, string telefono, string direccion, string email, int edad, string tipodocumento, string documento, int idcargo, string nombrecargo)
        {
            Idusuario = idusuario;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            Edad = edad;
            Tipodocumento = tipodocumento;
            Documento = documento;
            Idcargo = idcargo;
            NombreCargo = nombrecargo;
        }
    }
}