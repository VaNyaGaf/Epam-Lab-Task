using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class GameService : CrudService<Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository) 
            : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Skips some sequence of games and return a specified amount of games.
        /// </summary>
        /// <param name="skip">Amount of games which be skipped</param>
        /// <param name="amount">Amount of games which be retrieved</param>
        /// <exception cref="ArgumentException">If  </exception>
        public async Task<IReadOnlyCollection<Game>> GetGamesAsync(int skip, int amount)
        {
            return await _gameRepository.GetGamesAsync(skip, amount);
        }
    }
}
