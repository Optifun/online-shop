using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShop.Server.DataAccess
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {
        }

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<FavouriteProduct> FavouriteProducts { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductShop> ProductShops { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<PurchasedProduct> PurchasedProducts { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=OnlineShop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Type)
                    .HasMaxLength(18)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<FavouriteProduct>(entity =>
            {
                entity.ToTable("favourite_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.FavouriteProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Favourite_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavouriteProducts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Favourite_User");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("price");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Discount)
                    .HasPrecision(5, 2)
                    .HasColumnName("discount");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SettingDate)
                    .HasColumnName("setting_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Value)
                    .HasPrecision(12, 3)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(24)
                    .HasColumnName("name");

                entity.Property(e => e.PriceId).HasColumnName("price_id");

                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK_Product_Price");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Product_Vendor");
            });

            modelBuilder.Entity<ProductShop>(entity =>
            {
                entity.ToTable("product_shop");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductShops)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductShop_Product");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductShops)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_ProductShop_Shop");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchase");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsCash).HasColumnName("is_cash");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Purchase_Shop");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Purchase_User");
            });

            modelBuilder.Entity<PurchasedProduct>(entity =>
            {
                entity.ToTable("purchased_product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.PriceId).HasColumnName("price_id");

                entity.Property(e => e.ProductShopId).HasColumnName("product_shop_id");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK_Purchased_Price");

                entity.HasOne(d => d.ProductShop)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.ProductShopId)
                    .HasConstraintName("FK_Purchased_ProductShop");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK_Purchased_Purchase");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Review_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shop");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Address)
                    .HasMaxLength(42)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.Name)
                    .HasMaxLength(14)
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("character(64)[]")
                    .HasColumnName("password_hash");

                entity.Property(e => e.Register)
                    .HasColumnName("register")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, null, true);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
