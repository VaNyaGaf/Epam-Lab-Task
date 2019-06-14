using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public CrudService(IRepository<TEntity> repository)
        {
            _repository = repository ?? throw new System.ApplicationException("NO ICURD SEVICE");
        }

        public async Task<TEntity> CreateAsync(TEntity enitity)
        {
            return await _repository.AddAsync(enitity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
