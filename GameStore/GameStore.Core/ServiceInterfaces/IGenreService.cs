using GameStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<Genre> CreateAsync(Genre enitity);
        Task<Genre> UpdateAsync(Genre entity);
        Task<IReadOnlyCollection<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
