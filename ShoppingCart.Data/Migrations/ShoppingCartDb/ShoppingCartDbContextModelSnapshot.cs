﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCart.Data.Contexts;

#nullable disable

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    [DbContext(typeof(ShoppingCartDbContext))]
    partial class ShoppingCartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingCart.Models.DataModels.CartItem", b =>
                {
                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "Email");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "The Laptops and Computers Category.",
                            Name = "Laptops & Computers"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "The Appliance Category.",
                            Name = "Appliance"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "The TVs and Projectors Category.",
                            Name = "TVs & Projectors"
                        },
                        new
                        {
                            Id = 4L,
                            Description = "The Cell Phones Category.",
                            Name = "Cell Phones"
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Description = "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue",
                            ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg",
                            Name = "Dell - Inspiron 16.0\"",
                            Price = 1099.99m
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 2L,
                            Description = "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel",
                            ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg",
                            Name = "Samsung - 6.3 Range",
                            Price = 1599.99m
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 3L,
                            Description = "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV",
                            ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg",
                            Name = "Samsung - 65\"",
                            Price = 1299.99m
                        },
                        new
                        {
                            Id = 4L,
                            CategoryId = 4L,
                            Description = "Apple - iPhone 15 Pro 256GB - Black Titanium",
                            ImagePath = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg",
                            Name = "Apple - iPhone 15 Pro 256GB - Black Titanium",
                            Price = 1099.99m
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.ItemImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemImages");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.CartItem", b =>
                {
                    b.HasOne("ShoppingCart.Models.DataModels.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.Item", b =>
                {
                    b.HasOne("ShoppingCart.Models.DataModels.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.ItemImage", b =>
                {
                    b.HasOne("ShoppingCart.Models.DataModels.Item", "Item")
                        .WithMany("Images")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ShoppingCart.Models.DataModels.Item", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
