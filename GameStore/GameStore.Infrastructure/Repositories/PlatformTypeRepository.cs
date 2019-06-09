using GameStore.Core.Entities;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    class PlatformTypeRepository : GenericRepository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameStoreContext context) : base(context)
        { }
    }
}
