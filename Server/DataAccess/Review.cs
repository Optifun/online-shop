using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Review
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public short Rating { get; set; }
        public string Comment { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
