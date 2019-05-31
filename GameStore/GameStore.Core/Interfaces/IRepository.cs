using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(int id);
        void Delete(TEntity entity);
    }
}
