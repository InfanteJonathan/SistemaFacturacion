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
    public class ProductoRepository : IGenericRepositorio<Producto>
    {
        public readonly SisFactContext _context;

        public ProductoRepository(SisFactContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> Listar() => await _context.Productos.ToListAsync();


        public async Task<Producto> Obtener(int id) => await _context.Productos.FindAsync(id);


        public async Task Crear(Producto entity)
        {
            await _context.Productos.AddAsync(entity);
        }

        public void Actualizar(Producto entity)
        {
            _context.Productos.Attach(entity);
            _context.Productos.Entry(entity).State = EntityState.Modified;
        }


        public void Eliminar(Producto entity)
        {
            _context.Productos.Remove(entity);
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
