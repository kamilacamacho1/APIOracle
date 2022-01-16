using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.DTO
{
    public class LibroDTO
    {
        public decimal Idlibro { get; set; }
        public string? Titulo { get; set; }
        public string? Anio { get; set; }
        public string? Genero { get; set; }
        public decimal? Nopaginas { get; set; }
        public decimal? Idautor { get; set; }

    }
}
