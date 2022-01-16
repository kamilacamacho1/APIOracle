using APIOracle.DataAccess.Models;
using APIOracle.DTO;

namespace APIOracle.WebAPI.Mappings
{
    public static partial class MapperAutor
    {
        public static AutorDTO ToDTO(this Tblautor model)  // Convierte de ModelContext a DTO
        {
            return new AutorDTO()
            {
                Idautor = model.Idautor,
                Nombre = model.Nombre,
                Ciudad = model.Ciudad,
                Correo = model.Correo,
                Fechanacimiento = model.Fechanacimiento
            };
        }
    }

    public static partial class MapperAutor
    {
        public static Tblautor ToDatabase(this AutorDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Tblautor()
            {
                Idautor = dto.Idautor,
                Nombre = dto.Nombre,
                Ciudad = dto.Ciudad,
                Correo = dto.Correo,
                Fechanacimiento = dto.Fechanacimiento
            };
        }
    }
}