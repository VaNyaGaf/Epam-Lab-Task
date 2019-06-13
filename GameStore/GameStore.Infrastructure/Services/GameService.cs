using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class GameService : CrudService<Game, IGameRepository>, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository) : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }
    }
}
