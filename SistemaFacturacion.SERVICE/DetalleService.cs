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
    public class DetalleService : IDetalleService<DetalleFactura>
    {
        private readonly IDetalleRepository<DetalleFactura> _detalleReporitorio;

        public DetalleService(IDetalleRepository<DetalleFactura> detalleRepositorio)
        {
            _detalleReporitorio = detalleRepositorio;
        }

        public async Task<IEnumerable<DetalleFactura>> Listar()
        {
            var detalle = await _detalleReporitorio.GetAll();
            return detalle;
        }

        public async Task<DetalleFactura> Agregar(DetalleFactura entity)
        {
            await _detalleReporitorio.Agregar(entity);
            await _detalleReporitorio.Save();
            return entity;
        }


    }
}
