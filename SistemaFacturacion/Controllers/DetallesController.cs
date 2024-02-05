using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.SERVICE.Interface;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly IDetalleService<DetalleFactura> _service;
        private readonly SisFactContext _context;

        public DetallesController(IDetalleService<DetalleFactura> service, SisFactContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("listarporidfactura/{id}")]
        public async Task<ActionResult> ListarPorIdFactura(int id)
        {
            var idfactura = await _context.DetalleFacturas
                    .Where(d => d.IdFactura == id)
                    .ToListAsync();

            return Ok(idfactura);
        }


        [HttpGet("lista")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var detalle = await _service.Listar();
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Agregar(DetalleFactura agregar)
        {
            try
            {
                var detalle = await _service.Agregar(agregar);
                return Ok(detalle);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete("eliminar/{item}")]
        public async Task<ActionResult> Eliminar(string item)
        {
            try
            {
                var idetalle =  _context.DetalleFacturas.Where(i=> i.IdItem.Equals(item)).FirstOrDefault();
                if (idetalle != null)
                {
                    //Guardamos el idFactura y el subtotal del detalle antes de eliminarlo
                    var idfactura = idetalle.IdFactura;

                    //Encuentra el producto correspondiente y actualiza el stock
                    var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == idetalle.CodigoProducto);
                    if (producto != null)
                    {
                        producto.Stock += idetalle.Cantidad;
                        _context.Entry(producto).State = EntityState.Modified;
                    }

                    _context.DetalleFacturas.Remove(idetalle);
                    await _context.SaveChangesAsync();

                    //Calculando el nuevo subtotal para la factura
                    var subtotalfactura = _context.DetalleFacturas
                        .Where(df=> df.IdFactura == idfactura)
                        .Sum(df=> df.Subtotal);

                    //buscar la factura correspondiente y actualizar el subtotal
                    var factura = await _context.Facturas.FindAsync(idfactura);
                    factura.Subtotal = subtotalfactura;

                    await _context.SaveChangesAsync();

                    return Ok(idetalle);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }


    }
}
