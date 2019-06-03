using GameStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceInterfaces
{
    public interface IPublisherService
    {
        Task<Publisher> CreateAsync(Publisher enitity);
        Task<Publisher> UpdateAsync(Publisher entity);
        Task<IReadOnlyCollection<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
