using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    /// <inheritdoc />
    public partial class CellPhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[] { 4L, "The Cell Phones Category.", null, "Cell Phones" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Name", "Price" },
                values: new object[] { 4L, 4L, "Apple - iPhone 15 Pro 256GB - Black Titanium", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6525/6525408_sd.jpg", "Apple - iPhone 15 Pro 256GB - Black Titanium", 1099.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
