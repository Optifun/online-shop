using OnlineShop.Core.DTO;

namespace OnlineShop.Client.Pages.Admin.Product
{
    public class ShopInventory
    {
        public Shop Shop;
        public long Amount;

        public void Deconstruct(out Shop shop, out long amount)
        {
            shop = Shop;
            amount = Amount;
        }
    }
}