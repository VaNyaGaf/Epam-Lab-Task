using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceInterfaces
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity enitity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
