using Microsoft.EntityFrameworkCore;
using StoreApp.Data.DatabaseModel;
using StoreApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models.Home
{
    public class HomeIndexPagedList<T> : List<T>
    {
        public HomeIndexPagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            AddRange(items);
        }

        public static HomeIndexPagedList<Products> Create(List<Products> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new HomeIndexPagedList<Products>(items, count, pageIndex, pageSize);
        }
    }
}
