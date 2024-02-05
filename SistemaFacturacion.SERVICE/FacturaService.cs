using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Interface;
using SistemaFacturacion.SERVICE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE
{
    public class FacturaService : IFacturaService<Factura>
    {
        private readonly IFacturaRepository<Factura> _facturaRepository;
        private readonly SisFactContext _context;

        public FacturaService(IFacturaRepository<Factura> facturaRepository, SisFactContext context)
        {
            _facturaRepository = facturaRepository;
            _context = context;
        }

        public async Task<IEnumerable<Factura>> Lista()
        {
            var factura = await _facturaRepository.GetAll();
            return factura;
        }

        public async Task<Factura> Crear(Factura modelo)
        {
            await _facturaRepository.Crear(modelo);
            await _facturaRepository.Save();
            return modelo;
        }

        public async Task<Factura> Eliminar(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _facturaRepository.Eliminar(factura);
                await _facturaRepository.Save();

            }
            return null;
        }


    }
}
