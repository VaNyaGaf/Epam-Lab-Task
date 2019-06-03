using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Models;

namespace GameStore.Infrastructure.Repositories
{
    class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreContext context) : base(context)
        { }
    }
}
