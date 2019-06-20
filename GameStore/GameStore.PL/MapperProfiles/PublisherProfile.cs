using AutoMapper;
using GameStore.Core.Entities;
using GameStore.PL.ViewModels;

namespace GameStore.PL.MapperProfiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<CreatePublisherViewModel, Publisher>().ReverseMap();
            CreateMap<EditPublisherModel, Publisher>().ReverseMap();
        }
    }
}
