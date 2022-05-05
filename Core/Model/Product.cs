using System.Collections.Generic;

namespace OnlineShop.Core.Model
{
    public record Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        
        public List<Review> Reviews { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Price Price { get; set; } = null!;
        public Vendor Vendor { get; set; } = null!;
        public List<ProductAmmount> ProductShops { get; set; }
    }
}