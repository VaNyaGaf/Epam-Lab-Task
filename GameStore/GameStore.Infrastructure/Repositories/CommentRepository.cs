using GameStore.DAL.Abstractions.Models;
using GameStore.DAL.Abstractions.RepositoryInterfaces;

namespace GameStore.DAL.Repositories
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context) : base(context)
        { }
    }
}
