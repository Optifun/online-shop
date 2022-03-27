using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
