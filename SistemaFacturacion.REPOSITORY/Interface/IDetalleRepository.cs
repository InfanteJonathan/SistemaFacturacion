using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY.Interface
{
    public interface IDetalleRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task Agregar(TEntity entity);
        Task Save();
    }
}
