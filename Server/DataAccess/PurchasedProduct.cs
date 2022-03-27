using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class PurchasedProduct
    {
        public long Id { get; set; }
        public long PriceId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductShopId { get; set; }
        public int Count { get; set; }

        public virtual Price Price { get; set; } = null!;
        public virtual ProductShop ProductShop { get; set; } = null!;
        public virtual Purchase Purchase { get; set; } = null!;
    }
}
