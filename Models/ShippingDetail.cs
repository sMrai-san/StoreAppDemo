using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class ShippingDetail
    {
        public int ShippingDetailId { get; set; }
        [Required]
        public int? MemberId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostNumber { get; set; }
        [Required]
        public string City { get; set; }
        public int? OrderId { get; set; }
        public decimal? AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }
    }
}
