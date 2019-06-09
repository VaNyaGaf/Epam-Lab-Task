using GameStore.Core.Entities;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameStoreContext context) : base(context)
        { }
    }
}
