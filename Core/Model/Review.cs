namespace OnlineShop.Core.Model
{
    public record Review
    {
        public long Id { get; set; }
        public short Rating { get; set; }
        public string Comment { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}