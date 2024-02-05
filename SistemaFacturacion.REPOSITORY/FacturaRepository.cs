using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY
{
    public class FacturaRepository : IFacturaRepository<Factura>
    {
        private readonly SisFactContext _context;

        public FacturaRepository(SisFactContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAll()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task Crear(Factura entity)

            => await _context.Facturas.AddAsync(entity);


        public void Eliminar(Factura entity)
            => _context.Facturas.Remove(entity);


        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
