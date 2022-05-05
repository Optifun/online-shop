using System.Collections.Generic;

namespace OnlineShop.Core.DTO
{
    public record Product(long Id, string Name, string Description, Price Price, Vendor Vendor, Category Category, List<ProductReview> Reviews);
    public record ProductCard(long Id, string Name, string Description, double Rating, Price Price, Vendor Vendor, Category Category);
    public record ProductInfo(string Name, string Description, float Price, long VendorId, long CategoryId);
}