using GameStore.DAL.Abstractions.Models;
using GameStore.DAL.Abstractions.RepositoryInterfaces;

namespace GameStore.DAL.Repositories
{
    class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreContext context) : base(context)
        { }
    }
}
