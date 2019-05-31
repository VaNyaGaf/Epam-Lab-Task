using GameStore.DAL.Abstractions.Models;
using GameStore.DAL.Abstractions.RepositoryInterfaces;

namespace GameStore.Infrastructure.Repositories
{
    class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameStoreContext context) : base(context)
        { }
    }
}
