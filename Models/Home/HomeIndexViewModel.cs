using StoreApp.Data.DatabaseModel;
using StoreApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models.Home
{
    public class HomeIndexViewModel
    {
        //******************************************
        public string SearchString { get; set; }
        public int? TotalPages { get; set; }
        public int? PageIndex { get; set; }
        public bool PreviousDisabled { get; set; }
        public bool NextDisabled { get; set; }

        //******************************************

        public static GenericUnit _unit = new GenericUnit();

        public List<Products> ListOfProducts { get; set; }

        public HomeIndexViewModel CreateModel(string search, int? pageNumber, bool isHome)
        {
            /*No search criteria provided, let's show all the featured products*/
            if (string.IsNullOrEmpty(search))
            {
                if (isHome)
                {
                    var prods = _unit.GetRepositoryInstance<Products>()
                                .GetAllContentsIQueryable()
                                .Where(i => i.IsDeleted == false && i.IsFeatured == true)
                                .ToList();
                    return new HomeIndexViewModel()
                    {
                        ListOfProducts = HomeIndexPagedList<Products>.Create(prods, pageNumber ?? 1, 3),
                    };
                }
                else
                {
                    var prods = _unit.GetRepositoryInstance<Products>()
                                .GetAllContentsIQueryable()
                                .Where(i => i.IsDeleted == false)
                                .ToList();
                    return new HomeIndexViewModel()
                    {
                        ListOfProducts = HomeIndexPagedList<Products>.Create(prods, pageNumber ?? 1, 15),
                    };
                }



            }
            /*Search criteria provided, let's show all the containing products*/
            else
            {
                PageIndex = pageNumber;
                int pageSize = 10;
                SearchString = search;

                var prods = _unit.GetRepositoryInstance<Products>()
                                        .GetAllContentsIQueryable()
                                        .Where(i => i.IsDeleted == false &&
                                        i.ProductName.Contains(search) ||
                                        i.Description.Contains(search) ||
                                        i.Category.CategoryName.Contains(search))
                                        .ToList();

                int TotalPages = (int)Math.Ceiling(prods.Count() / (double)pageSize);

                /*Disable the buttons if only one page OR no content before/after*/
                if (PageIndex == TotalPages)
                {
                    if (PageIndex == 1)
                    {
                        NextDisabled = true;
                        PreviousDisabled = true;
                    }
                    else
                    {
                        NextDisabled = true;
                        PreviousDisabled = false;
                    }

                }
                else if (PageIndex == 1)
                {
                    if (PageIndex == TotalPages)
                    {
                        NextDisabled = true;
                        PreviousDisabled = true;
                    }
                    else
                    {
                        NextDisabled = false;
                        PreviousDisabled = true;
                    }
                }

                return new HomeIndexViewModel()
                {
                    ListOfProducts = HomeIndexPagedList<Products>.Create(prods, pageNumber ?? 1, pageSize),
                    PreviousDisabled = PreviousDisabled,
                    NextDisabled = NextDisabled,
                };
            }
        }

    }
}
