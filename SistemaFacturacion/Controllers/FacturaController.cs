using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.SERVICE.Interface;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService<Factura> _facturaService;
        private readonly SisFactContext _context;

        public FacturaController(IFacturaService<Factura> facturaService, SisFactContext context)
        {
            _facturaService = facturaService;
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var factura = await _facturaService.Lista();
                return Ok(factura);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("obtener/{id}")]
        public async Task<ActionResult<Factura>> obtener(int id)
        {
            try
            {
                var factura = await _context.Facturas.FirstOrDefaultAsync(i => i.IdFactura == id);

                if (factura == null) return NotFound();
                return Ok(factura);
            }
            catch
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }


        [HttpPost("agregar")]
        public async Task<ActionResult> Agregar(Factura model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var factura = await _facturaService.Crear(model);
                    return Ok(factura);
                }
                else { return BadRequest(ModelState); }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var factura = await _facturaService.Eliminar(id);
                if (factura == null) return NoContent();
                return Ok(factura);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        [HttpGet("ultimaFactura")]
        public async Task<ActionResult<int>> GetUltimaFactura()
        {
            try
            {
                var ultimaFactura = await _context.Facturas.OrderByDescending(f =>
                f.IdFactura).FirstOrDefaultAsync();

                if (ultimaFactura == null) return NotFound();
                return Ok(ultimaFactura.IdFactura);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        } 




    }
}
