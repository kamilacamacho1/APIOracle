using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIOracle.WebApplication.Models.Autor
{
    public class AutorEntity
    {
        public int Idautor { get; set; }
        public string Nombre { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
    }
}