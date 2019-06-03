using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Models;

namespace GameStore.Infrastructure.Repositories
{
    class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameStoreContext context) : base(context)
        { }
    }
}
