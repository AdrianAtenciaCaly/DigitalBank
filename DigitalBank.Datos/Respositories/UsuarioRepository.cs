using DigitalBank.Datos.DataContext;
using DigitalBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Datos.Respositories
{
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        private readonly DigitalBankContext _digitalBankContext;
        public UsuarioRepository(DigitalBankContext digitalBankContext)
        {
            _digitalBankContext = digitalBankContext;
        }
        public async Task<bool> Adicionar(Usuario entity)
        {
            _digitalBankContext.Usuarios.Add(entity);
            await _digitalBankContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable> Consultar(int id)
        {
         return (IQueryable)await _digitalBankContext.Usuarios.FindAsync(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            Usuario usuario = _digitalBankContext.Usuarios.First(x => x.Id == id);
            _digitalBankContext.Usuarios.Remove(usuario);
            await _digitalBankContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Modificar(Usuario entity)
        {
            _digitalBankContext.Usuarios.Update(entity);
            await _digitalBankContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            IQueryable<Usuario> queryUsuario =  _digitalBankContext.Usuarios;
            return   queryUsuario;
        }
    }
}
