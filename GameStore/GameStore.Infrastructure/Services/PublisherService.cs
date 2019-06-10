using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class PublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<Publisher> CreateAsync(Publisher enitity)
        {
            return await _publisherRepository.AddAsync(enitity);
        }

        public async Task<IReadOnlyCollection<Publisher>> GetAllAsync()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _publisherRepository.DeleteAsync(id);
        }

        public async Task<Publisher> UpdateAsync(Publisher entity)
        {
            return await _publisherRepository.UpdateAsync(entity);
        }
    }
}
