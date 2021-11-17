using Microsoft.AspNetCore.Mvc;
using StoreApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        /***********************************/
        /*HOMEPAGE*/
        /***********************************/

        public IActionResult Index(string search, int? pageNumber)
        {
            bool isHome = true;

            if (!string.IsNullOrEmpty(search))
            {
                //Passing pagination stuff to view
                if (pageNumber < 0 || pageNumber == null)
                {
                    pageNumber = 1;
                }
                if (string.IsNullOrEmpty(search))
                {
                    ViewBag.searchContainer = null;
                    ViewBag.pageN = 1;
                }
                else
                {
                    ViewBag.searchContainer = search;
                    ViewBag.pageN = pageNumber;
                }

                return RedirectToAction("ProductListing","Home", new { search=search, pageNumber = pageNumber });
            }
            else
            {
                //Fetch products for view
                HomeIndexViewModel model = new HomeIndexViewModel();
                var products = model.CreateModel(search, pageNumber, isHome);

                return View(products);
            }

        }

        /***********************************/
        /*PRODUCT LISTING VIEW*/
        /***********************************/
        public IActionResult ProductListing(string search, int? pageNumber)
        {
            bool isHome = false;

            //Passing pagination stuff to view
            if (pageNumber < 0 || pageNumber == null)
            {
                pageNumber = 1;
            }
            if (string.IsNullOrEmpty(search))
            {
                ViewBag.searchContainer = null;
                ViewBag.pageN = 1;
            }
            else
            {
                ViewBag.searchContainer = search;
                ViewBag.pageN = pageNumber;
            }

            //Fetch products for view
            HomeIndexViewModel model = new HomeIndexViewModel();
            var products = model.CreateModel(search, pageNumber, isHome);

            return View(products);
        }

        /***********************************/
        /*ETC*/
        /***********************************/



    }
}
