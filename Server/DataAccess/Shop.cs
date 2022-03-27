using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Shop
    {
        public Shop()
        {
            ProductShops = new HashSet<ProductShop>();
            Purchases = new HashSet<Purchase>();
        }

        public long Id { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<ProductShop> ProductShops { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
