using APIOracle.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOracle.Services.Autor
{
    //implementación de la interfaz
    public class AutorService : IAutorService
    {
        private ModelContext _context;

        public AutorService(ModelContext context)
        {
            _context = context;
        }
        public async Task<RespuestaService<Tblautor>> Actualizar(Tblautor a)
        {
            var res = new RespuestaService<Tblautor>();
            var autor = await _context.Tblautors.FirstOrDefaultAsync(x => x.Idautor == a.Idautor);

            if (autor == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                autor.Nombre = a.Nombre;
                autor.Fechanacimiento = a.Fechanacimiento;
                autor.Ciudad = a.Ciudad;
                autor.Correo = a.Correo;

                try
                {
                    _context.Tblautors.Update(autor);
                    await _context.SaveChangesAsync();

                    res.Objeto = autor;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<Tblautor>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Tblautor>();
            var Autor = await _context.Tblautors.FirstOrDefaultAsync(x => x.Idautor == id);

            if (Autor == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = Autor;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var Autor = await _context.Tblautors.FirstOrDefaultAsync(x => x.Idautor == id);

            if (Autor == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Tblautors.Remove(Autor);
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

        public async Task<RespuestaService<Tblautor>> Guardar(Tblautor c)
        {
            var res = new RespuestaService<Tblautor>();

            try
            {
                await _context.Tblautors.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Idautor = await _context.Tblautors.MaxAsync(u => u.Idautor);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<Tblautor>>> Listar()
        {
            var res = new RespuestaService<List<Tblautor>>();
            var lista = await _context.Tblautors.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
    }
}
