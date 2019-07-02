using AutoMapper;
using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok();
        }
    }
}