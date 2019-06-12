using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService ?? throw new ApplicationException("Game Service isn't injected!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            return Ok(await _gameService.CreateAsync(game));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGame(Game game)
        {
            return Ok(await _gameService.UpdateAsync(game));
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