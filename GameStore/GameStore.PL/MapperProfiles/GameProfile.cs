using AutoMapper;
using GameStore.Core.Entities;
using GameStore.PL.ViewModels;

namespace GameStore.PL.MapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<CreateGameViewModel, Game>().ReverseMap();
            CreateMap<EditGameModel, Game>().ReverseMap();
        }
    }
}
