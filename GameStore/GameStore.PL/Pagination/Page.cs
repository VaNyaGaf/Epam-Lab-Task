using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameStore.PL.Pagination
{
    public class Page<TItem>
    {
        public Page(IEnumerable<TItem> items)
        {
            Items = items;
        }

        public IEnumerable<TItem> Items { get; private set; }

        public object GetUrls()
        {
            return new
            {
            };
        }
    }
}
