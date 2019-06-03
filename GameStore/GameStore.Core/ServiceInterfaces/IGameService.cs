using GameStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceInterfaces
{
    public interface IGameService
    {
        Task<Game> CreateAsync(Game enitity);
        Task<Game> UpdateAsync(Game entity);
        Task<IReadOnlyCollection<Game>> GetAllAsync();
        Task<Game> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
