using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;

namespace GameStore.PL.Pagination
{
    public class Paginator<TItem> : IPaginator<TItem> 
        where TItem : class
    {
        private readonly ICrudService<TItem> _crudService;

        public Paginator(ICrudService<TItem> crudService, int pageSize)
        {
            if (pageSize < 1)
            {
                throw new ArgumentException("Parametr can't be less or equal than zero");
            }

            _crudService = crudService;
            PageSize = pageSize;
            FirstPage = 1;
            LastPage = GetLastPage(crudService.CountAsync().Result, pageSize);
            CurrentPage = 1;
        }

        public int FirstPage { get; private set; }

        public int LastPage { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int Previous
        {
            get
            {
                if (--CurrentPage < FirstPage)
                {
                    return FirstPage;
                }
                else
                {
                    return --CurrentPage;
                }
            }
        }

        public int Next
        {
            get
            {
                if (++CurrentPage > LastPage)
                {
                    return LastPage;
                }
                else
                {
                    return ++CurrentPage;
                }
            }
        }

        public async Task<Page<TItem>> GetPageAsync(int pageNumber)
        {
            CurrentPage = pageNumber;
            int skip = (pageNumber - 1) * PageSize;
            return new Page<TItem>(await _crudService.GetItemsAsync(skip, PageSize));
        }

        private int GetLastPage(int totalItem, int pageSize)
        {
            return (int)Math.Ceiling((decimal)totalItem / pageSize);
        }
    }
}
