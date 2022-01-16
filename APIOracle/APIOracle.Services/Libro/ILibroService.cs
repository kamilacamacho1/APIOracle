using APIOracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.Services.Libro
{
    public interface ILibroService
    {
        //Se trabaja metodos asincronos y utilizar la respuesta estandar
        Task<RespuestaService<List<Tbllibro>>> Listar();

        Task<RespuestaService<Tbllibro>> BuscarPorId(decimal id);

        Task<RespuestaService<Tbllibro>> Guardar(Tbllibro c);

        Task<RespuestaService<Tbllibro>> Actualizar(Tbllibro c);

        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
