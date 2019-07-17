using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Core.Entities;
using GameStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    internal class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context)
            : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Comment>> GetGameCommentsAsync(int gameId)
        {
            return await Context.Comments
                .Where(comment => comment.GameId == gameId)
                .ToListAsync();
        }
    }
}
