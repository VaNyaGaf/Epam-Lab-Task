using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.Core.Entities;

namespace GameStore.Core.ServiceInterfaces
{
    public interface ICommentService : ICrudService<Comment>
    {
        Task<IReadOnlyCollection<Comment>> GetGameCommentsAsync(int gameId);
    }
}
