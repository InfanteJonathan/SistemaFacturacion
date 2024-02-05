using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Generic;
using SistemaFacturacion.SERVICE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE
{
    public class ProductoService : IService<Producto>
    {

        private readonly IGenericRepositorio<Producto> _repositorio;

        public ProductoService(IGenericRepositorio<Producto> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Producto>> Lista()
        {
            var producto = await _repositorio.Listar();
            return producto;
        }

        public async Task<Producto> Obtener(int id)
        {
            var producto = await _repositorio.Obtener(id);
            return producto;
        }

        public async Task<Producto> Crear(Producto modelo)
        {
            await _repositorio.Crear(modelo);
            await _repositorio.Save();
            return modelo;
        }

        public async Task<Producto> Actualizar(int id, Producto modelo)
        {
            var producto = await _repositorio.Obtener(id);
            if (producto != null)
            {
                producto.Codigo = modelo.Codigo;
                producto.Nombre = modelo.Nombre;
                producto.IdFamilia = modelo.IdFamilia;
                producto.Precio = modelo.Precio;
                producto.Stock = modelo.Stock;
                producto.Activo = modelo.Activo;

                _repositorio.Actualizar(producto);
                await _repositorio.Save();
                return producto;

            }
            return null;

        }

        public async Task<Producto> Eliminar(int id)
        {
            var producto = await _repositorio.Obtener(id);
            if (producto != null)
            {
                _repositorio.Eliminar(producto);
                await _repositorio.Save();
            }
            return null;
        }


    }
}
