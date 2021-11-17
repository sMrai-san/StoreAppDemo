using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please type in Category Name!")]
        [StringLength(100, ErrorMessage = "Minimum 3 and maximum 100 charachters allowed", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please type in Product Name")]
        [StringLength(100, ErrorMessage = "Minimum 3 and maximum 100 charachters allowed", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please type in Quantity")]
        [Range(typeof(int), "1", "500", ErrorMessage = "Minimun 1 and maximum 500 in quantity allowed")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please type in Price")]
        [Range(typeof(decimal), "0.01", "20000", ErrorMessage = "Minimum 0.01 and maximum 20000 in price allowed")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please type in Description")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Required]
        [Range(1,50)] //Category ID between 1-50
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public SelectList Categories { get; set; }
    }
}
