using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY.Generic
{
    public interface IGenericRepositorio<TEntity>
    {
        Task<TEntity> Obtener(int id);
        Task<IEnumerable<TEntity>> Listar();
        Task Crear (TEntity entity);
        void Actualizar(TEntity entity);
        void Eliminar(TEntity entity);
        Task Save();
    }
}
