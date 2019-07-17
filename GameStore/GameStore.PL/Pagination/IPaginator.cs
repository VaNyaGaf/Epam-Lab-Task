using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.PL.Pagination
{
    public interface IPaginator<TItem>
    {
        int FirstPage { get; }

        int LastPage { get; }

        int CurrentPage { get; }

        int PageSize { get; }
    }
}
