using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;

namespace GameStore.Core.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IReadOnlyCollection<Game>> GetGamesAsync(int skip, int amount);
    }
}
