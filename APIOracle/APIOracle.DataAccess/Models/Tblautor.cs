using System;
using System.Collections.Generic;

namespace APIOracle.DataAccess.Models
{
    public partial class Tblautor
    {
        public Tblautor()
        {
            Tbllibros = new HashSet<Tbllibro>();
        }

        public decimal Idautor { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string? Ciudad { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Tbllibro> Tbllibros { get; set; }
    }
}
