using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> CreateAsync(Game enitity)
        {
            return await _gameRepository.AddAsync(enitity);
        }

        public async Task<IReadOnlyCollection<Game>> GetAllAsync()
        {
            return await _gameRepository.GetAllAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _gameRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public async Task<Game> UpdateAsync(Game entity)
        {
            return await _gameRepository.UpdateAsync(entity);
        }
    }
}
