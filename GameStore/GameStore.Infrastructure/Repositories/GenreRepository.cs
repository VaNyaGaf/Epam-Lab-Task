using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    internal class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameStoreContext context) 
            : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Genre>> GetGameGenresAsync(int gameId)
        {
            return await (from gg in Context.GameGenres
                    where gg.GameId == gameId
                    join genre in Context.Genres on gg.GenreId equals genre.Id
                    select genre).ToListAsync();
        }
    }
}
