using GameStore.Core.Entities;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    internal class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreContext context)
            : base(context)
        {
        }
    }
}
