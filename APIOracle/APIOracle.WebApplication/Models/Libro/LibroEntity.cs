using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIOracle.WebApplication.Models.Libro
{
    public class LibroEntity
    {
        public int Idlibro { get; set; }
        public string Titulo { get; set; }
        public string Anio { get; set; }
        public string Genero { get; set; }
        public int Nopaginas { get; set; }
        public int Idautor { get; set; }
    }
}