using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class ProductShop
    {
        public ProductShop()
        {
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long ShopId { get; set; }
        public int Count { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Shop Shop { get; set; } = null!;
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
