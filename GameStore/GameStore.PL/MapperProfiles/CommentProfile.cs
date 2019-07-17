using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Core.Entities;
using GameStore.PL.ViewModels;

namespace GameStore.PL.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<ReplyCommentViewModel, Comment>();
            CreateMap<CreateCommentViewModel, Comment>();
        }
    }
}
