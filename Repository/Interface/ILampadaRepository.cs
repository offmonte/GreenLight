using System.Collections.Generic;
using System.Threading.Tasks;
using GreenLight.Models;

namespace GreenLight.Repository.Interface
{
    public interface ILampadaRepository
    {
        Task<IEnumerable<Lampada>> GetLampadas();
        Task<Lampada> GetLampada(int id);
        Task<Lampada> AddLampada(Lampada lampada);
        Task<Lampada> UpdateLampada(Lampada lampada);
        void DeleteLampada(int id);
    }
}
