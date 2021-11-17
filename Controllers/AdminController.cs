using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StoreApp.Data.DatabaseModel;
using StoreApp.Data.Repositories;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnit _unit = new GenericUnit();

        //For product picture upload
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        //**********************************************
        //***CATEGORIES*********************************
        //**********************************************
        public ActionResult Categories()
        {
            List<Categories> allCategories =
                _unit.GetRepositoryInstance<Categories>()
                .GetAllContentsIQueryable()
                .Where(i => i.IsDelete == false)
                .ToList();

            return View(allCategories);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int id)
        {
            Categories cat;
            
            if (id != 0)
            {
                    cat = JsonConvert.DeserializeObject<Categories>(JsonConvert.SerializeObject(_unit.GetRepositoryInstance<Categories>().GetFirstOrDefault(id)));
            }
            else
            {
                cat = new Categories();
            }
            return View("UpdateCategory", cat);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Categories cat)
        {
            if (cat.CategoryId == 0)
            {
                _unit.GetRepositoryInstance<Categories>().Add(cat);
                return RedirectToAction("Categories", "Admin");
            }
            else
            {
                _unit.GetRepositoryInstance<Categories>().Update(cat);
                return RedirectToAction("Categories", "Admin");
            }
        }


        //**********************************************
        //***PRODUCTS***********************************
        //**********************************************

        public ActionResult Products()
        {
            List<Products> allProducts =
                _unit.GetRepositoryInstance<Products>()
                .GetAllContentsIQueryable()
                .Where(i => i.IsDeleted == false)
                .ToList();

            return View(allProducts);
        }

        public ActionResult AddProduct()
        {
            return UpdateProduct(0);
        }

        public ActionResult UpdateProduct(int id)
        {
            Products prod;

            if (id != 0)
            {
                prod = JsonConvert.DeserializeObject<Products>(JsonConvert.SerializeObject(_unit.GetRepositoryInstance<Products>().GetFirstOrDefault(id)));
            }
            else
            {
                prod = new Products();
            }
            //Get active categories into viewbag
            ViewBag.CategoriesDD = new SelectList(_unit.GetRepositoryInstance<Categories>()
                .GetAllContentsIQueryable()
                .Where(i => i.IsDelete == false)
                , "CategoryId","CategoryName");


            return View("UpdateProduct", prod);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Products prod, IFormFile imageFile)
        {
            string productFileName = null;

            if (prod.ProductId == 0)
            {
                if (imageFile != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "/Content/ProductImages");
                    productFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, productFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                       imageFile.CopyTo(fileStream);
                    }
                }

                prod.ProductImage = imageFile != null ? productFileName : "placeholder-image.png";

                _unit.GetRepositoryInstance<Products>().Add(prod);
                return RedirectToAction("Products", "Admin");
            }
            else
            {
                //let's check if we are creating or modifying this product
                if (prod.CreatedDate != null)
                {
                    prod.ModifiedDate = DateTime.Now;
                }
                else
                {
                    prod.CreatedDate = DateTime.Now;
                    prod.ModifiedDate = DateTime.Now;
                }
                //no nulls for me!
                if (prod.ProductImage == null)
                {
                    prod.ProductImage = "";
                }

                if (imageFile != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "Content\\ProductImages");
                    productFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, productFileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                }
                prod.ProductImage = imageFile != null ? productFileName : prod.ProductImage;

                _unit.GetRepositoryInstance<Products>().Update(prod);
                return RedirectToAction("Products", "Admin");
            }
        }

    }
}
