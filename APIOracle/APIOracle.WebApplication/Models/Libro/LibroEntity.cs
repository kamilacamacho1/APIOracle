using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIOracle.WebApplication.Models.Libro
{
    public class LibroEntity
    {
        public int Idlibro { get; set; }
        [Required(ErrorMessage = "El corre es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El corre es obligatorio")]
        public string Anio { get; set; }
        [Required(ErrorMessage = "El corre es obligatorio")]
        public string Genero { get; set; }
        public int Nopaginas { get; set; }
        public int Idautor { get; set; }
    }
}