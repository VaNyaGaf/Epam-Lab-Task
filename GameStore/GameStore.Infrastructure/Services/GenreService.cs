using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> CreateAsync(Genre enitity)
        {
            return await _genreRepository.AddAsync(enitity);
        }

        public async Task<IReadOnlyCollection<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _genreRepository.DeleteAsync(id);
        }

        public async Task<Genre> UpdateAsync(Genre entity)
        {
            return await _genreRepository.UpdateAsync(entity);
        }
    }
}
