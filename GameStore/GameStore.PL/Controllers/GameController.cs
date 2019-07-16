using System;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using GameStore.PL.Pagination;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameService gameService, IMapper mapper, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGameViewModel gameViewModel)
        {
            var game = _mapper.Map<Game>(gameViewModel);
            return Ok(await _gameService.CreateAsync(game));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGame(EditGameModel game)
        {
            var editedGame = _mapper.Map<Game>(game);
            return Ok(await _gameService.UpdateAsync(editedGame));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _gameService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameService.GetAllAsync());
        }

        [HttpGet("Pages")]
        public async Task<IActionResult> GetPageOfGames(int pageSize, int pageNumber)
        {
            int skip = (pageNumber - 1) * pageSize;
            int lastPage = GetLastPage((await _gameService.GetAllAsync()).Count, pageSize);
            var games = await _gameService.GetGamesAsync(skip, pageSize);
            Paginator<Game> paginator = new Paginator<Game>(games, pageSize, pageNumber, lastPage);
            return Ok(new { page = paginator.GetPage() });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }

        private int GetLastPage(int totalItem, int pageSize)
        {
            return (int)Math.Ceiling((decimal)totalItem / pageSize);
        }
    }
}