using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Generic;
using SistemaFacturacion.SERVICE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE
{
    public class UsuarioService : IService<Usuario>
    {


        private readonly IGenericRepositorio<Usuario> _repository;
        private readonly SisFactContext _context;

        public UsuarioService(IGenericRepositorio<Usuario> repository, SisFactContext context)
        {
            _repository = repository;
            _context = context;
        }

     

        public async Task<IEnumerable<Usuario>> Lista()
        {
            var user = await _repository.Listar();
            return user;
        }

        public async Task<Usuario> Obtener(int id)
        {
            var user = await _repository.Obtener(id);
            return user;
        }
        public async Task<Usuario> Crear(Usuario modelo)
        {
            await _repository.Crear(modelo);
            await _repository.Save();
            return modelo;
        }

        public async Task<Usuario> Actualizar(int id, Usuario modelo)
        {
            var user = await _repository.Obtener(id);
            if (user != null)
            {
                user.Nombre = modelo.Nombre;
                user.Contrasenia = modelo.Contrasenia;

                await _repository.Crear(user);
                await _repository.Save();
                return user;

            }

            return null;
        }


        public async Task<Usuario> Eliminar(int id)
        {
            var user = await _repository.Obtener(id);

            if (user != null)
            {
                _repository.Eliminar(user);
                await _repository.Save();
            }
            return null;

        }


    }
}
