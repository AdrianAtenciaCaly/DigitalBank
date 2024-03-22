using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Datos.Respositories
{
    public interface IGenericRepository <TEntityModel> where TEntityModel : class
    {
        Task <bool> Adicionar (TEntityModel entity);
        Task<bool> Modificar(TEntityModel entity);
        Task<IQueryable> Consultar(int id);
        Task<bool> Eliminar(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();

    }
}
