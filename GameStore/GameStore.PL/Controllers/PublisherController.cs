using GameStore.Core.Entities;
using GameStore.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService genreService)
        {
            _publisherService = genreService ?? throw new ApplicationException("Publisher Service isn't injected!");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(Publisher publisher)
        {
            return Ok(await _publisherService.CreateAsync(publisher));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePublisher(Publisher publisher)
        {
            return Ok(await _publisherService.UpdateAsync(publisher));
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