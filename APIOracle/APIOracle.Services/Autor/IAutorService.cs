using APIOracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.Services.Autor
{
    public interface IAutorService
    {
        //Se trabaja metodos asincronos y utilizar la respuesta estandar
        Task<RespuestaService<List<Tblautor>>> Listar();

        Task<RespuestaService<Tblautor>> BuscarPorId(decimal id);

        Task<RespuestaService<Tblautor>> Guardar(Tblautor c);

        Task<RespuestaService<Tblautor>> Actualizar(Tblautor c);

        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
