using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.DTO
{
    public class AutorDTO
    {
        public decimal Idautor { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo { get; set; }

    }
}
