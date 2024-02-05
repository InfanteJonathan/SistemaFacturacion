using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY.Interface
{
    public interface IFacturaRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task Crear(TEntity entity);
        void Eliminar (TEntity entity);
        Task Save();
    }
}
