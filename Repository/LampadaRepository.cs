using Microsoft.EntityFrameworkCore;
using GreenLight.Models;
using GreenLight.Repository.Interface;
using GreenLight.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenLight.Repository
{
    public class LampadaRepository : ILampadaRepository
    {
        private readonly dbContext _dbContext;

        public LampadaRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Lampada>> GetLampadas()
        {
            return await _dbContext.Lampadas.Include(l => l.Usuario).ToListAsync();
        }

        public async Task<Lampada> GetLampada(int id)
        {
            return await _dbContext.Lampadas.Include(l => l.Usuario).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Lampada> AddLampada(Lampada lampada)
        {
            var result = await _dbContext.Lampadas.AddAsync(lampada);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Lampada> UpdateLampada(Lampada lampada)
        {
            var result = await _dbContext.Lampadas.FirstOrDefaultAsync(l => l.Id == lampada.Id);
            if (result != null)
            {
                result.Apelido = lampada.Apelido;
                result.NomeDispositivo = lampada.NomeDispositivo;
                result.Modo = lampada.Modo;
                result.UsuarioId = lampada.UsuarioId;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteLampada(int id)
        {
            var result = await _dbContext.Lampadas.FirstOrDefaultAsync(l => l.Id == id);
            if (result != null)
            {
                _dbContext.Lampadas.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
