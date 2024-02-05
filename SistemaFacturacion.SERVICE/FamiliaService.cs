
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Generic;
using SistemaFacturacion.SERVICE.Interface;

using SistemaFacturacion.SERVICE.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE
{

    public class FamiliaService : IService<FamiliaProducto>
    {
        private readonly IGenericRepositorio<FamiliaProducto> _repository;

        public FamiliaService(IGenericRepositorio<FamiliaProducto> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FamiliaProducto>> Lista()
        {
            var prod = await _repository.Listar();
            return prod;
        }

        public async Task<FamiliaProducto> Obtener(int id)
        {
            var idfamilia = await _repository.Obtener(id);
            return idfamilia;
        }

        public async Task<FamiliaProducto> Crear(FamiliaProducto modelo)
        {
            await _repository.Crear(modelo);
            await _repository.Save();
            return modelo;
        }

        public async Task<FamiliaProducto> Actualizar(int id, FamiliaProducto modelo)
        {
            var idprod = await _repository.Obtener(id);
            if (idprod != null)
            {
                idprod.Codigo = modelo.Codigo;
                idprod.Nombre = modelo.Nombre;
                idprod.Activo = modelo.Activo;

                _repository.Actualizar(idprod);
                await _repository.Save();
                return idprod;
            }
            return null;
        }



        public async Task<FamiliaProducto> Eliminar(int id)
        {
            var idprod = await _repository.Obtener(id);
            if (idprod != null)
            {
                _repository.Eliminar(idprod);
                await _repository.Save();
            }
            return null;
        }

    }


}
