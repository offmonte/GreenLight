using Microsoft.EntityFrameworkCore;
using GreenLight.Models;
using GreenLight.Repository.Interface;
using GreenLight.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenLight.Repository
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly dbContext _dbContext;

        public RegistroRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Registro>> GetRegistros()
        {
            return await _dbContext.Registros.Include(r => r.Lampada).ToListAsync();
        }

        public async Task<Registro> GetRegistro(int id)
        {
            return await _dbContext.Registros.Include(r => r.Lampada).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Registro> AddRegistro(Registro registro)
        {
            var result = await _dbContext.Registros.AddAsync(registro);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Registro> UpdateRegistro(Registro registro)
        {
            var result = await _dbContext.Registros.FirstOrDefaultAsync(r => r.Id == registro.Id);
            if (result != null)
            {
                result.ConsumoWh = registro.ConsumoWh;
                result.DataConsumo = registro.DataConsumo;
                result.DiferencaMes = registro.DiferencaMes;
                result.LampadaId = registro.LampadaId;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteRegistro(int id)
        {
            var result = await _dbContext.Registros.FirstOrDefaultAsync(r => r.Id == id);
            if (result != null)
            {
                _dbContext.Registros.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
