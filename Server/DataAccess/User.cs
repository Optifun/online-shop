using System;
using System.Collections.Generic;

namespace OnlineShop.Server.DataAccess
{
    public partial class User
    {
        public User()
        {
            FavouriteProducts = new HashSet<FavouriteProduct>();
            Purchases = new HashSet<Purchase>();
            Reviews = new HashSet<Review>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Register { get; set; }
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
