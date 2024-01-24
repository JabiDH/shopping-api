using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    /// <inheritdoc />
    public partial class CreateTablesItemsCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1L, "The Laptops and Computers Category.", null, "Laptops & Computers" },
                    { 2L, "The Appliance Category.", null, "Appliance" },
                    { 3L, "The TVs and Projectors Category.", null, "TVs & Projectors" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, 1L, "Dell - Inspiron 16.0\" 2-in-1 OLED Touch Laptop - 13th Gen Intel Evo i7 - 16GB Memory - NVIDIA GeForce MX550 - 1TB SSD - Stylus - Dark River Blue", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6539/6539903_sd.jpg", "Dell - Inspiron 16.0\"", 1099.99m },
                    { 2L, 2L, "Samsung - 6.3 cu. ft. Smart Instant Heat Slide-in Induction Range with Air Fry & Convection+ - Stainless Steel", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6491/6491829_sd.jpg", "Samsung - 6.3 Range", 1599.99m },
                    { 3L, 3L, "Samsung - 65” Class QN85C Neo QLED 4K UHD Smart Tizen TV", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6536/6536418_sd.jpg", "Samsung - 65\"", 1299.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
