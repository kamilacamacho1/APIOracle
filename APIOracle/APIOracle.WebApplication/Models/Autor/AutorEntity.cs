using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIOracle.WebApplication.Models.Autor
{
    public class AutorEntity
    {
        public int Idautor { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
        public DateTime Fechanacimiento { get; set; }
        [Required(ErrorMessage = "La Ciudad es obligatorio")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "El corre es obligatorio")]
        public string Correo { get; set; }
    }
}