using GameStore.DAL.Abstractions.Models;
using GameStore.DAL.Abstractions.RepositoryInterfaces;

namespace GameStore.Infrastructure.Repositories
{
    class PlatformTypeRepository : GenericRepository<PlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(GameStoreContext context) : base(context)
        { }
    }
}
