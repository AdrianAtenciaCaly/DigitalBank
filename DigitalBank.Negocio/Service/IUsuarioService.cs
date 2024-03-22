using DigitalBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Negocio.Service
{
    public  interface IUsuarioService

    {
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Modificar(Usuario usuario);
        Task<IQueryable> Consultar(int id);
        Task<bool> Eliminar(int id);
        Task<IQueryable<Usuario>> ObtenerTodos();
        Task<bool> Log(string accion);
    }
}
