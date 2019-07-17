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
        public GameRepository(GameStoreContext context)
            : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Game>> GetPublisherGamesAsync(int publisherId)
        {
            return await (from game in Context.Games
                    where game.PublisherId == publisherId
                    select game).ToListAsync();
        }
    }
}
