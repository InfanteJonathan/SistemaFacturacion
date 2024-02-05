using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DATA.Models;
using SistemaFacturacion.REPOSITORY.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.REPOSITORY
{
    public class FamiliaRepository : IGenericRepositorio<FamiliaProducto>
    {
        private readonly SisFactContext _dbcontext;

        public FamiliaRepository(SisFactContext context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<FamiliaProducto>> Listar() => await _dbcontext.FamiliaProductos.ToListAsync();


        public async Task<FamiliaProducto> Obtener(int id)
            => await _dbcontext.FamiliaProductos.FindAsync(id);

        public async Task Crear(FamiliaProducto entity)
            => await _dbcontext.FamiliaProductos.AddAsync(entity);


        public void Actualizar(FamiliaProducto entity)
        {
            _dbcontext.FamiliaProductos.Attach(entity);
            _dbcontext.FamiliaProductos.Entry(entity).State = EntityState.Modified;
        }


        public void Eliminar(FamiliaProducto entity)
            => _dbcontext.FamiliaProductos.Remove(entity);


        public async Task Save()
            => await _dbcontext.SaveChangesAsync();
    }
}
