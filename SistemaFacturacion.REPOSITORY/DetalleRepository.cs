using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY
{
    public class DetalleRepository : IDetalleRepository<DetalleFactura>
    {
        private readonly SisFactContext _context;

        public DetalleRepository(SisFactContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<DetalleFactura>> GetAll()
        {
            return await _context.DetalleFacturas.ToListAsync();
        }

        public async Task Agregar(DetalleFactura entity)
        {
            //Encuentra el producto correspondiente y actualiza el stock
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == entity.CodigoProducto);

            if (producto == null)
            {
                throw new Exception("Producto no encontrado");
            }

            producto.Stock -= entity.Cantidad;
            _context.Entry(producto).State = EntityState.Modified;

            await _context.DetalleFacturas.AddAsync(entity);
            await _context.SaveChangesAsync();

            //calculamos el nuevo subtotal para la factura
            var subtotalfactura = _context.DetalleFacturas
                .Where(df => df.IdFactura == entity.IdFactura)
                .Sum(df => df.Subtotal);

            //encuentra la factura correspondiente y actualiza el subtotal

            var factura = await _context.Facturas.FindAsync(entity.IdFactura);
            factura.Subtotal = subtotalfactura;

            _context.Entry(factura).Reload();

            factura.Subtotal = subtotalfactura;

            await _context.SaveChangesAsync();


        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
