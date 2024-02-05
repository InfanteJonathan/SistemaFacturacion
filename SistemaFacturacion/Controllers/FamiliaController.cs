using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.SERVICE.Interface;


namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {

        private readonly IService<FamiliaProducto> _service;
        private readonly SisFactContext _context;

        public FamiliaController(SisFactContext context, IService<FamiliaProducto> service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<FamiliaProducto>> GetAll()
        {
            try
            {
                var familia = await _service.Lista();
                return familia;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("obtener/{id}")]
        public async Task<ActionResult> obtener(int id)
        {
            try
            {
                var familia = await _service.Obtener(id);
                if (familia == null) NotFound();
                return Ok(familia);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("crear")]
        public async Task<ActionResult> crear([FromBody] FamiliaProducto model)
        {
            if (ModelState.IsValid)
            {
                var prod = await _service.Crear(model);
                return Ok(prod);
            }
            return NotFound();
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] FamiliaProducto model)
        {
            try
            {
                var prod = await _service.Actualizar(id, model);
                return Ok(prod);
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
                var prod = await _service.Eliminar(id);
                if (prod == null) NotFound();
                return Ok(prod);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
