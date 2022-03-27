using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            FavouriteProducts = new HashSet<FavouriteProduct>();
            ProductShops = new HashSet<ProductShop>();
            Reviews = new HashSet<Review>();
        }

        public long Id { get; set; }
        public long PriceId { get; set; }
        public long CategoryId { get; set; }
        public long VendorId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Price Price { get; set; } = null!;
        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual ICollection<ProductShop> ProductShops { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
