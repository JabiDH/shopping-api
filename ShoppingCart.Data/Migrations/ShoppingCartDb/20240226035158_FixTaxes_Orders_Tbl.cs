using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    /// <inheritdoc />
    public partial class FixTaxes_Orders_Tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleTax",
                table: "Orders",
                newName: "TaxRate");

            migrationBuilder.RenameColumn(
                name: "SaleTax",
                table: "OrderItems",
                newName: "TaxRate");

            migrationBuilder.AddColumn<decimal>(
                name: "SalesTax",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesTax",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesTax",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SalesTax",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "TaxRate",
                table: "Orders",
                newName: "SaleTax");

            migrationBuilder.RenameColumn(
                name: "TaxRate",
                table: "OrderItems",
                newName: "SaleTax");
        }
    }
}
