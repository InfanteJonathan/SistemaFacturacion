using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.SERVICE.Interface;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IService<Producto> _service;

        public ProductoController(IService<Producto> service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var producto = await _service.Lista();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("obtener/{id}")]
        public async Task<ActionResult> Obtener(int id)
        {
            try
            {
                var producto = await _service.Obtener(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Agregar([FromBody] Producto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var producto = await _service.Crear(model);
                    return Ok(producto);
                }
                else
                {
                    return BadRequest(ModelState);
                }
                

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] Producto model)
        {
            try
            {
                var producto = await _service.Actualizar(id, model);
                return Ok(producto);
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
                var producto = await _service.Eliminar(id);
                if (producto == null) NotFound();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
