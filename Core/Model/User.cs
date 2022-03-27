using System;

namespace OnlineShop.Core.Model
{
    public record User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Register { get; set; }
    }
}