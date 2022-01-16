using APIOracle.DataAccess.Models;
using APIOracle.DTO;
using APIOracle.Services.Libro;
using APIOracle.WebAPI.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIOracle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _servicio;

        public LibroController(ILibroService servicio)
        {
            //tener acceso dentro del controlador mediante injeccion de dependencias al servicio
           
            _servicio = servicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> Listar()
        {
            //Eliminar carga al controlador
            var retorno = await _servicio.Listar();
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDTO>> BuscarPorId(decimal id)
        {
            //Eliminar carga al controlador
            var retorno = await _servicio.BuscarPorId(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDTO>> Guardar(LibroDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());
            
            if (retorno.Objeto != null )
                return retorno.Objeto.ToDTO();
            else 
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<LibroDTO>> Actualizar(LibroDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(decimal id)
        {
            var retorno = await _servicio.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
