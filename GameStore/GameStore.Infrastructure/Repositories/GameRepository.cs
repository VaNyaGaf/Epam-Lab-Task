using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    internal class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly GameStoreContext _context;

        public GameRepository(GameStoreContext context)
            : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Skips some sequence of games and return a specified amount of games.
        /// </summary>
        /// <param name="skip">Amount of games which be skipped</param>
        /// <param name="amount">Amount of games which be retrieved</param>
        /// <exception cref="ArgumentException">If  </exception>
        public async Task<IReadOnlyCollection<Game>> GetGamesAsync(int skip, int amount)
        {
            if (skip < 0)
            {
                throw new ArgumentException("Parameter can't be less than zero.");
            }

            if (amount < 1)
            {
                throw new ArgumentException("Parameter can't be less or equal than zero.");
            }

            return await _context.Games.Skip(skip).Take(amount).ToListAsync();
        }
    }
}
