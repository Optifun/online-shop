using OnlineShop.Core;
using OnlineShop.Server.DataAccess;

namespace OnlineShop.Server;

public static class SeedDataService
{
    public static void PopulateData(OnlineShopContext context)
    {
        Category monitorCategory = new() {Type = "Monitor"};
        Vendor samsungVendor = new() {Name = "Samsung"};
        Shop moskowShop = new() {Address = "Moskow, Pushkin, 21"};
        Price samsungPrice = new()
        {
                Discount = 0,
                SettingDate = DateTime.UtcNow,
                Value = 14500
        };
        Product samsungMonitor = new()
        {
                Name = "SAMSUNG XLT2671124",
                Description = "Cool 27 inch monitor",
                Category = monitorCategory,
                Vendor = samsungVendor,
                Price = samsungPrice
        };

        context.Users.Add(new User()
        {
                Name = "admin",
                IsAdmin = true,
                PasswordHash = Security.Hash("admin")
        });

        context.Shops.AddRange(new Shop[]
        {
                moskowShop, 
                new() {Address = "Ekaterinburg, Lomonosov, 5"},
        });

        context.Vendors.AddRange(new Vendor[]
        {
                samsungVendor, 
                new() {Name = "Razer"},
        });

        context.Categories.AddRange(new Category[]
        {
                new() {Type = "Computer mouse"}, 
                new() {Type = "TV"}, 
                new() {Type = "Motherboard"},
                monitorCategory,
        });


        context.Prices.Add(samsungPrice);
        context.Products.Add(samsungMonitor);
        context.ProductShops.AddRange(new ProductShop[]
        {
                new ProductShop()
                {
                        Product = samsungMonitor,
                        Shop = moskowShop,
                        Count = 5
                }
        });
        context.SaveChanges();
    }
}