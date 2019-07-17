using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;

namespace GameStore.Core.ServiceInterfaces
{
    public interface IGameService : ICrudService<Game>
    {
        Task<IReadOnlyCollection<Game>> GetPublisherGamesAsync(int publisherId);
    }
}
