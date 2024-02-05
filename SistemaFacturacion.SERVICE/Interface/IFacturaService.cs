using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE.Interface
{
    public interface IFacturaService<T>
    {
        Task<IEnumerable<T>> Lista();
        Task<T> Crear(T modelo);
        Task<T> Eliminar(int id);
    }
}
