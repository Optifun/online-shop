using System;

namespace OnlineShop.Core.Model
{
    public record User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public DateTime Register { get; set; }
    }
}