using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Data.Migrations.ShoppingCartDb
{
    /// <inheritdoc />
    public partial class AddItemImages_DbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage");

            migrationBuilder.RenameTable(
                name: "ItemImage",
                newName: "ItemImages");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImages",
                newName: "IX_ItemImages_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImages_Items_ItemId",
                table: "ItemImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemImages",
                table: "ItemImages");

            migrationBuilder.RenameTable(
                name: "ItemImages",
                newName: "ItemImage");

            migrationBuilder.RenameIndex(
                name: "IX_ItemImages_ItemId",
                table: "ItemImage",
                newName: "IX_ItemImage_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemImage",
                table: "ItemImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Items_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
