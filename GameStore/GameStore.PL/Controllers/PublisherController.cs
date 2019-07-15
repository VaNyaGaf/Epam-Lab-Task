using System;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(IPublisherService genreService, IMapper mapper, ILogger<PublisherController> logger)
        {
            _publisherService = genreService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(CreatePublisherViewModel publisherViewModel)
        {
            var publisher = _mapper.Map<Publisher>(publisherViewModel);
            return Ok(await _publisherService.CreateAsync(publisher));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublisher(EditPublisherModel publisher)
        {
            var editedPublisher = _mapper.Map<Publisher>(publisher);
            return Ok(await _publisherService.UpdateAsync(editedPublisher));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _publisherService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherService.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _publisherService.DeleteAsync(id);
            return Ok();
        }
    }
}