using AutoMapper;
using GameStore.Core.Entities;
using GameStore.PL.ViewModels;

namespace GameStore.PL.MapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<CreateGenreViewModel, Genre>().ReverseMap();
        }
    }
}
