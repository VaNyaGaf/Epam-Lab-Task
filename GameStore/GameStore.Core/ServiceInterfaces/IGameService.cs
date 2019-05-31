using GameStore.BusinessLogic.Abstractions.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BusinessLogic.Abstractions.ServiceInterfaces
{
    public interface IGameService
    {
        Task<GameDto> CreateAsync(GameDto enitity);
        Task<GameDto> UpdateAsync(GameDto entity);
        Task<IList<GameDto>> GetAllAsync();
        Task<GameDto> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
