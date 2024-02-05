using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE.Interface
{
    public interface IDetalleService<T>
    {
        Task<IEnumerable<T>> Listar();
        Task<T> Agregar(T entity);

    }
}
