using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using GameStore.Core.ServiceInterfaces;

namespace GameStore.Infrastructure.Services
{
    public class CommentService : CrudService<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
            : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IReadOnlyCollection<Comment>> GetGameCommentsAsync(int gameId)
        {
            return await _commentRepository.GetGameCommentsAsync(gameId);
        }
    }
}
