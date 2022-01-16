using System;
using System.Collections.Generic;

namespace APIOracle.DataAccess.Models
{
    public partial class Tbllibro
    {
        public decimal Idlibro { get; set; }
        public string? Titulo { get; set; }
        public string? Anio { get; set; }
        public string? Genero { get; set; }
        public decimal? Nopaginas { get; set; }
        public decimal? Idautor { get; set; }

        public virtual Tblautor? IdautorNavigation { get; set; }
    }
}
