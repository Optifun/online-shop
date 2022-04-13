namespace OnlineShop.Core.DTO
{
    public record ProductCard(long Id, string Name, string Description, Price Price, Vendor Vendor, Category Category);
    public record ProductInfo(string Name, string Description, float Price, long VendorId, long CategoryId);
}