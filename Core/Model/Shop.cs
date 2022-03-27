namespace OnlineShop.Core.Model
{
    public record Shop
    {
        public long Id { get; set; }
        public string Address { get; set; } = null!;
    }
}