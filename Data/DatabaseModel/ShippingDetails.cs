using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreApp.Data.DatabaseModel
{
    public partial class ShippingDetails
    {
        public int ShippingDetailId { get; set; }
        public int? MemberId { get; set; }
        public string Address { get; set; }
        public string PostNumber { get; set; }
        public string City { get; set; }
        public int? OrderId { get; set; }
        public decimal? AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual Members Member { get; set; }
    }
}
