using System.Collections.Generic;

namespace OnlineShop.Core.DTO
{
    public record Product(long Id, string Name, string Description, Price Price, Vendor Vendor, Category Category, List<ProductReview> Reviews);

    public record ProductCard(long Id, string Name, string Description, double Rating, Price Price, Vendor Vendor, Category Category)
    {
        public static ProductCard Convert(ProductCardMutable card) =>
            new ProductCard(card.Id ?? 0, card.Name, card.Description, card.Rating, card.Price, card.Vendor, card.Category);
    }

    public record ProductInfo(string Name, string Description, float Price, long VendorId, long CategoryId);

    public record ProductCardMutable
    {
        public ProductCardMutable(long Id, string Name, string Description, double Rating, Price Price, Vendor Vendor, Category Category)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Rating = Rating;
            this.Price = Price;
            this.Vendor = Vendor;
            this.Category = Category;
        }

        public ProductCardMutable(ProductCard card) : this(card.Id, card.Name, card.Description, card.Rating, card.Price, card.Vendor, card.Category)
        {
        }

        public ProductCardMutable()
        {
        }

        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public Price Price { get; set; }
        public Vendor Vendor { get; set; }
        public Category Category { get; set; }

        public void Deconstruct(out string Name, out string Description, out Price Price)
        {
            Name = this.Name;
            Description = this.Description;
            Price = this.Price;
        }
    }
}