using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY
{
    public class UsuarioRepository : IGenericRepositorio<Usuario>
    {
        private readonly SisFactContext _context;

        public UsuarioRepository(SisFactContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Usuario>> Listar() => await _context.Usuarios.ToListAsync();


        public async Task<Usuario> Obtener(int id) => await _context.Usuarios.FindAsync(id);


        public async Task Crear(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
        }

        public void Actualizar(Usuario entity)
        {
            _context.Usuarios.Attach(entity);
            _context.Usuarios.Entry(entity).State = EntityState.Modified;
        }

        public void Eliminar(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
