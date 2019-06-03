using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Models;

namespace GameStore.Infrastructure.Repositories
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context) : base(context)
        { }
    }
}
