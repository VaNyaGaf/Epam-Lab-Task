using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class PublisherService : CrudService<Publisher>, IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository) 
            : base(publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
    }
}
