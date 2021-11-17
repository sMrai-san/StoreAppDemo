using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class CategoryDetails
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 and maximum 100 charachters allowed")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }

    public class ProductDetails
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product name required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 and maximum 100 charachters allowed")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Quantity required.")]
        [Range(typeof(int), "1","500", ErrorMessage ="Invalid quantity. Must be within 1-500.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price required")]
        [Range(typeof(decimal), "1", "2000000", ErrorMessage = "Invalid price. Must be within 1-200000.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description required.")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Required(ErrorMessage = "Category name required.")]
        [Range(1,50, ErrorMessage ="Enter value between 1-50")] //1-50 allowed only! This is so going to crash someday
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public SelectList Categories { get; set; }
    }
}
