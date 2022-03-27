namespace OnlineShop.Core.Model
{
    public record Category
    {
        public long Id { get; set; }
        public string Type { get; set; } = null!;
    }
}