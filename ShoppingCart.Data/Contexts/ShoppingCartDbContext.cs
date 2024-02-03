using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingCart.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Contexts
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity => {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Price)
                .HasPrecision(18, 2);

                entity.HasMany(e => e.Images)
                .WithOne(e => e.Item)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Category)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
                               
            });            

            modelBuilder.Entity<Category>(entity => {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();               
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.Email });
            });

            // Create some categories
            var categories = new List<Category>() {
                new Category() {
                    Id = 1,
                    Name = "Laptops & Computers",
                    Description = "The Laptops and Computers Category."
                },
                new Category() {
                    Id = 2,
                    Name = "Appliance",
                    Description = "The Appliance Category."
                },
                new Category() { 
                    Id = 3,
                    Name = "TVs & Projectors",
                    Description = "The TVs and Projectors Category."
                },
                new Category() {
                    Id = 4,
                    Name = "Cell Phones",
                    Description = "The Cell Phones Category."
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            // Create some Items
            var items = new List<Item>();            

            for (int i = 1; i <= 4; i += 4)
            {
                var subItems = new List<Item>() {
                    new Item()
                    {
                        Id = i,
                        Name = "Dell - Inspiron 16.0\"",
                        Description = "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 " +
                        "- 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue",
                        Price = 1099.99M,
                        CategoryId = 1,
                        ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg"
                    },
                    new Item()
                    {
                        Id = i + 1,
                        Name = "Samsung - 6.3 Range",
                        Description = "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel",
                        Price = 1599.99M,
                        CategoryId = 2,
                        ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg"
                    },
                    new Item()
                    {
                        Id = i + 2,
                        Name = "Samsung - 65\"",
                        Description = "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV",
                        Price = 1299.99M,
                        CategoryId = 3,
                        ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg"
                    },
                    new Item()
                    {
                        Id = i + 3,
                        Name = "Apple - iPhone 15 Pro 256GB - Black Titanium",
                        Description = "Apple - iPhone 15 Pro 256GB - Black Titanium",
                        Price = 1099.99M,
                        CategoryId = 4,
                        ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg"
                    }
                };
                items.AddRange(subItems);                
            }

            modelBuilder.Entity<Item>().HasData(items);
        }
    }
}
