using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Models;

namespace GameStore.Infrastructure.Repositories
{
    class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameStoreContext context) : base(context)
        { }
    }
}
