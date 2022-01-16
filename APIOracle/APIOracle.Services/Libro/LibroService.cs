using APIOracle.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.Services.Libro
{
    //implementación de la interfaz
    public class LibroService : ILibroService
    {
        private ModelContext _context;

        public LibroService(ModelContext context)
        {
            _context = context;
        }
        
        public async Task<RespuestaService<Tbllibro>> Actualizar(Tbllibro l)
        {
            var res = new RespuestaService<Tbllibro>();
            var Libro = await _context.Tbllibros.FirstOrDefaultAsync(x => x.Idlibro == l.Idlibro);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                Libro.Titulo = l.Titulo;
                Libro.Anio = l.Anio;
                Libro.Genero = l.Genero;
                Libro.Nopaginas = l.Nopaginas;

                try
                {
                    _context.Tbllibros.Update(Libro);
                    await _context.SaveChangesAsync();

                    res.Objeto = Libro;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<Tbllibro>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Tbllibro>();
            var Libro = await _context.Tbllibros.FirstOrDefaultAsync(x => x.Idlibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = Libro;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var Libro = await _context.Tbllibros.FirstOrDefaultAsync(x => x.Idlibro == id);

            if (Libro == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Tbllibros.Remove(Libro);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<Tbllibro>> Guardar(Tbllibro c)
        {
            var res = new RespuestaService<Tbllibro>();

            int noLibros = await _context.Tbllibros.CountAsync();            
            
            try
            {
                if (noLibros >= 5)
                {
                    res.AgregarInternalServerError("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }
                else
                {
                    await _context.Tbllibros.AddAsync(c);
                    await _context.SaveChangesAsync();
                    c.Idlibro = await _context.Tbllibros.MaxAsync(u => u.Idlibro);

                    res.Objeto = c;
                }
                
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Tbllibro>>> Listar()
        {
            var res = new RespuestaService<List<Tbllibro>>();
            var lista = await _context.Tbllibros.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
