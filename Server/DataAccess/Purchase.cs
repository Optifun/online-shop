using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchasedProducts = new HashSet<PurchasedProduct>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long ShopId { get; set; }
        public DateTime Date { get; set; }
        public bool IsCash { get; set; }

        public virtual Shop Shop { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
