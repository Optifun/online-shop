namespace OnlineShop.Core.Model
{
    public record Vendor
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
}