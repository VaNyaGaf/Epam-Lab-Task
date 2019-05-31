using GameStore.DAL.Abstractions.Models;
using GameStore.DAL.Abstractions.RepositoryInterfaces;

namespace GameStore.Infrastructure.Repositories
{
    class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameStoreContext context) : base(context)
        { }
    }
}
