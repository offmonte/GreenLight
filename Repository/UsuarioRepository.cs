using Microsoft.EntityFrameworkCore;
using GreenLight.Models;
using GreenLight.Repository.Interface;
using GreenLight.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenLight.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbContext _dbContext;

        public UsuarioRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _dbContext.Usuarios.Include(x => x.Lampadas).ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _dbContext.Usuarios.Include(x => x.Lampadas).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var result = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuario.Id);
            if (result != null)
            {
                result.Nome = usuario.Nome;
                result.Email = usuario.Email;
                result.Senha = usuario.Senha;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteUsuario(int id)
        {
            var result = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (result != null)
            {
                _dbContext.Usuarios.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
