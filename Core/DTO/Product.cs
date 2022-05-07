using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.DTO
{
    public record Product(long Id, string Name, string Description, Price Price, Vendor Vendor, Category Category, List<ProductReview> Reviews);

    public record ProductCard(long Id, string Name, string Description, double Rating, Price Price, Vendor Vendor, Category Category)
    {
        public static ProductCard Convert(ProductCardMutable card) =>
            new ProductCard(card.Id ?? 0, card.Name, card.Description, card.Rating, Price.Convert(card.Price), card.Vendor, card.Category);
    }

    public record ProductInfo(string Name, string Description, Price Price, long VendorId, long CategoryId);
    
    public class ProductAmount
    {
        public ProductAmount(ProductCard product, Dictionary<Shop, long> amount)
        {
            Product = product;
            Amount = amount;
        }

        public ProductCard Product { get; private set; }
        public Dictionary<Shop, long> Amount { get; private set; }
    }
    

    public class ProductCardMutable
    {
        public ProductCardMutable(long Id, string Name, string Description, double Rating, Price Price, Vendor Vendor, Category Category)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Rating = Rating;
            this.Price = new PriceMutable(Price);
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

        [Required, MinLength(3), StringLength(18)]
        public string Name { get; set; }

        [Required, MinLength(5)] public string Description { get; set; }
        public double Rating { get; set; }
        public PriceMutable Price { get; set; } = null!;
        [Required] public Vendor? Vendor { get; set; }
        [Required] public Category? Category { get; set; }
    }
}