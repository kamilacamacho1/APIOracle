using APIOracle.DataAccess.Models;
using APIOracle.DTO;

namespace APIOracle.WebAPI.Mappings
{
    public static partial class Mapper
    {
        public static LibroDTO ToDTO(this Tbllibro model)  // Convierte de ModelContext a DTO
        {
            return new LibroDTO()
            {
                Idlibro = model.Idlibro,
                Titulo = model.Titulo,
                Genero = model.Genero,
                Anio = model.Anio,
                Nopaginas = model.Nopaginas,
                Idautor = model.Idautor
            };
        }
    }

    public static partial class Mapper
    {
        public static Tbllibro ToDatabase(this LibroDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Tbllibro()
            {
                Idlibro = dto.Idlibro,
                Titulo = dto.Titulo,
                Genero = dto.Genero,
                Anio = dto.Anio,
                Nopaginas = dto.Nopaginas,
                Idautor = dto.Idautor
            };
        }
    }
}