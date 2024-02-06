using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.SERVICE;
using SistemaFacturacion.SERVICE.Interface;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private static int contador = 0;
        private static DateTime bloqueohasta = DateTime.MinValue;

        private SisFactContext _context;
        private readonly IService<Usuario> _service;
        private readonly UsuarioService _uService;

        public UsuarioController(IService<Usuario> service, UsuarioService uservice, SisFactContext context)
        {
            _service = service;
            _uService = uservice;
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var user = await _service.Lista();
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("validar/{nom}/{pass}")]
        public async Task<ActionResult> ValidarLogin(string nom, string pass)
        {
            if (DateTime.Now < bloqueohasta)
            {
                return new UnauthorizedResult();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nom);

            if (usuario == null || usuario.Contrasenia != pass)
            {
                contador++;

                if (contador >= 3)
                {
                    bloqueohasta = DateTime.Now.AddSeconds(5);
                    contador = 0;
                }

                return new UnauthorizedResult();
            }

            contador = 0;
            return new OkResult();
        }


    }
}
