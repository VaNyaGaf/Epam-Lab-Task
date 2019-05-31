using GameStore.BusinessLogic.Abstractions.DtoModels;
using System.Collections.Generic;

namespace GameStore.BusinessLogic.Abstractions.ServiceInterfaces
{
    public interface IPublisherService
    {
        PublisherDto CreateAsync(PublisherDto enitity);
        PublisherDto UpdateAsync(PublisherDto entity);
        IList<PublisherDto> GetAllAsync();
        PublisherDto GetByIdAsync(int id);
        void RemoveAsync(int id);
    }
}
