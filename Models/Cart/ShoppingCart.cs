using StoreApp.Data.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models.Cart
{
    public class ShoppingCart
    {
        public Products Product { get; set; }

        public int Quantity { get; set; }
    }
}
