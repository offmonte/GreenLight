using System.Collections.Generic;
using System.Threading.Tasks;
using GreenLight.Models;

namespace GreenLight.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
    }
}
