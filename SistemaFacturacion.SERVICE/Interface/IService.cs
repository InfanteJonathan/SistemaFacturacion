using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.SERVICE.Interface
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> Lista();
        Task<T> Obtener(int id);
        Task<T> Crear(T modelo);
        Task<T> Actualizar(int id, T modelo);
        Task<T> Eliminar(int id);
    }
}
