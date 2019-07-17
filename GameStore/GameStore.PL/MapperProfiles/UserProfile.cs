using AutoMapper;
using GameStore.Infrastructure.Authorization.Models;

namespace GameStore.PL.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpModel, AuthUser>();
            CreateMap<SignInModel, AuthUser>();
        }
    }
}
