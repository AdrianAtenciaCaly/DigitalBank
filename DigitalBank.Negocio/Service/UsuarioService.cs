using DigitalBank.Negocio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalBank.Modelos;
using DigitalBank.Datos.Respositories;
using DigitalBank.Datos.DataContext;
namespace DigitalBank.Negocio.ServiceWFC
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repository;
        public UsuarioService(IGenericRepository<Usuario> genericRepository)
        {
                _repository= genericRepository;
        }
        public async Task<bool> Adicionar(Usuario usuario)
        {
            return await _repository.Adicionar(usuario);
        }

        public async Task<IQueryable> Consultar(int id)
        {
            return await  _repository.Consultar(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public Task<bool> Log(string accion)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Modificar(Usuario usuario)
        {
            return await _repository.Modificar(usuario);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }
    }
}
