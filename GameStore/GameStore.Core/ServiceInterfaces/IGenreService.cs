using GameStore.BusinessLogic.Abstractions.DtoModels;
using System.Collections.Generic;

namespace GameStore.BusinessLogic.Abstractions.ServiceInterfaces
{
    public interface IGenreService
    {
        GenreDto CreateAsync(GenreDto enitity);
        GenreDto UpdateAsync(GenreDto entity);
        IList<GenreDto> GetAllAsync();
        GenreDto GetByIdAsync(int id);
        void RemoveAsync(int id);
    }
}
