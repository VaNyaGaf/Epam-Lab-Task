using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    internal class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly GameStoreContext _context;

        public GenericRepository(GameStoreContext context)
        {
            _context = context;
        }

        protected GameStoreContext Context
        {
            get => _context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var res = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await GetByIdAsync(id);
            await DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Skips some sequence of games and return a specified amount of games.
        /// </summary>
        /// <param name="skip">Amount of games which be skipped</param>
        /// <param name="amount">Amount of games which be retrieved</param>
        /// <exception cref="ArgumentException">Thrown when skip parameter less than zero or amount less than one.</exception>
        public async Task<IReadOnlyCollection<TEntity>> GetItemsAsync(int skip, int amount)
        {
            if (skip < 0)
            {
                throw new ArgumentException("Parameter can't be less than zero.");
            }

            if (amount < 1)
            {
                throw new ArgumentException("Parameter can't be less or equal than zero.");
            }

            return await _context.Set<TEntity>().Skip(skip).Take(amount).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }
    }
}
