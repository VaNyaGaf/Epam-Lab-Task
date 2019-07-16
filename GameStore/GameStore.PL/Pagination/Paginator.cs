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
    {
        // private int _pageSize;
        public Paginator(IEnumerable<TItem> items, int pageSize, int currentPage, int lastPage)
        {
            if (items is null)
            {
                throw new ArgumentException("Collection of items can't be null");
            }

            if (pageSize < 1 || currentPage < 1 || lastPage < 1)
            {
                throw new ArgumentException("Parametr can't be less or equal than zero");
            }

            if (currentPage > lastPage)
            {
                throw new ArgumentException("Current page number can't be greater than las page number");
            }

            Items = items;
            
            // PageSize = pageSize;
            FirstPage = 1;
            CurrentPage = currentPage;
            LastPage = lastPage;
        }

        public int FirstPage { get; private set; }

        public int LastPage { get; private set; }

        public int CurrentPage { get; private set; }

        // public int PageSize
        // {
        //    get => _pageSize;
        //    set
        //    {
        //        if (value < 1)
        //        {
        //            throw new ArgumentException("Size of page can't be less than 1");
        //        }
        //        else
        //        {
        //            _pageSize = value;
        //            LastPage = (int)Math.Ceiling((decimal)(Items.Count() / _pageSize));
        //        }
        //    }
        // }
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

        public IEnumerable<TItem> Items { get; private set; }

        public Page<TItem> GetPage()
        {
            return new Page<TItem>(Items);
        }
    }
}
