using GameStore.Core.Entities;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    internal class PlatformTypeRepository : GenericRepository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameStoreContext context) 
            : base(context)
        {
        }
    }
}
