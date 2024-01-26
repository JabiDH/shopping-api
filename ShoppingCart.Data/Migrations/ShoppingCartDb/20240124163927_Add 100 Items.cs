using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    /// <inheritdoc />
    public partial class Add100Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 5L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 6L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 7L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 8L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 9L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 10L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 11L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 12L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 13L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 14L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 15L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 16L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 17L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 18L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 19L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 20L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 21L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 22L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 23L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 24L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 25L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 26L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 27L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 28L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 29L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 30L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 31L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 32L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 33L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 34L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 35L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 36L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 37L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 38L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 39L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 40L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 41L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 42L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 43L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 44L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 45L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 46L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 47L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 48L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 49L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 50L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 51L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 52L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 53L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 54L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 55L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 56L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 57L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 58L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 59L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 60L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 61L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 62L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 63L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 64L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 65L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 66L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 67L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 68L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 69L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 70L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 71L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 72L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 73L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 74L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 75L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 76L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 77L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 78L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 79L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 80L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 81L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 82L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 83L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 84L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 85L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 86L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 87L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 88L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 89L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 90L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 91L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 92L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 93L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 94L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 95L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 96L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m },
                    { 97L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 98L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 99L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m },
                    { 100L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 100L);
        }
    }
}
