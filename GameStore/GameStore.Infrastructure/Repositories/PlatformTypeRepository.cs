using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Models;

namespace GameStore.Infrastructure.Repositories
{
    class PlatformTypeRepository : GenericRepository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameStoreContext context) : base(context)
        { }
    }
}
