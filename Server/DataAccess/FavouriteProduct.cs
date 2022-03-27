using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class FavouriteProduct
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
