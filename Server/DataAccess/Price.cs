using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Price
    {
        public Price()
        {
            Products = new HashSet<Product>();
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }

        public long Id { get; set; }
        public long? ProductId { get; set; }
        public float Value { get; set; }
        public float Discount { get; set; }
        public DateTime SettingDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
