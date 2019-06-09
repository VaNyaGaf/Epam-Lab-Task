﻿using GameStore.Core.Entities;
using GameStore.Core.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context) : base(context)
        { }
    }
}
