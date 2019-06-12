using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService ?? throw new ApplicationException("Genre Service isn't injected!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            return Ok(await _genreService.CreateAsync(genre));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(Genre genre)
        {
            return Ok(await _genreService.UpdateAsync(genre));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _genreService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genreService.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genreService.DeleteAsync(id);
            return Ok();
        }
    }
}