using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class GenreService : CrudService<Genre>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository) 
            : base(genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IReadOnlyCollection<Genre>> GetGameGenresAsync(int gameId)
        {
            return await _genreRepository.GetGameGenresAsync(gameId);
        }
    }
}
