namespace OnlineShop.Core.Model
{
    public record ProductAmmount
    {
        public int Count { get; set; }
        public virtual Shop Shop { get; set; } = null!;
    }
}