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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreController> _logger;

        public GenreController(IGenreService genreService, IMapper mapper, ILogger<GenreController> logger)
        {
            _genreService = genreService ?? throw new ApplicationException("Genre Service isn't injected!");
            _mapper = mapper ?? throw new ApplicationException("AutoMapper isn't injected");
            _logger = logger ?? throw new ApplicationException("Logger isn't injected");
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGameViewModel genreViewModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Model state is not valid");
                throw new ApplicationException("Model state is not valid");
            }

            var genre = _mapper.Map<Genre>(genreViewModel);
            return Ok(await _genreService.CreateAsync(genre));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(EditGenreModel genre)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Model state is not valid");
                throw new ApplicationException("Model state is not valid");
            }

            var editedGenre = _mapper.Map<Genre>(genre);
            return Ok(await _genreService.UpdateAsync(editedGenre));
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