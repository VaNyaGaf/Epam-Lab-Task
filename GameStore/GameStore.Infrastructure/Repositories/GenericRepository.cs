using GameStore.DAL.Abstractions.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Repositories
{
    class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GameStoreContext _context;

        public GenericRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var res = await _context.Set<TEntity>().AddAsync(entity);
            return res.Entity;
        }

        public void Delete(int id)
        {
            var entityToDelete = _context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
