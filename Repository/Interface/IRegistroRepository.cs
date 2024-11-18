using System.Collections.Generic;
using System.Threading.Tasks;
using GreenLight.Models;

namespace GreenLight.Repository.Interface
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<Registro>> GetRegistros();
        Task<Registro> GetRegistro(int id);
        Task<Registro> AddRegistro(Registro registro);
        Task<Registro> UpdateRegistro(Registro registro);
        void DeleteRegistro(int id);
    }
}
