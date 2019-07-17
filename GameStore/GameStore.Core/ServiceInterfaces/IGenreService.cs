using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;

namespace GameStore.Core.ServiceInterfaces
{
    public interface IGenreService : ICrudService<Genre>
    {
        Task<IReadOnlyCollection<Genre>> GetGameGenresAsync(int gameId);
    }
}
