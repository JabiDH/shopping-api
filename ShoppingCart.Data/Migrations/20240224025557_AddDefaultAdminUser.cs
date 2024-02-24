using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60fecca9-8070-4d0b-9ccc-3ff6d077971c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede95183-48e9-4312-9cf9-499554fc53ed");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e9b2e07-5b77-43fa-aee0-91c607c94d79", 0, "4719e4aa-f465-4f4a-bc66-085a7e00220f", "admin@shoppingcart.com", false, false, null, "ADMIN@SHOPPINGCART.COM", "ADMIN@SHOPPINGCART.COM", "AQAAAAIAAYagAAAAEJlgiA0cfxn9eghnJ0Cn36MAVkuuqsLQifAhKPGJ5hDZAaxMs0A8895p2D757EEGzg==", null, false, "DAUFPCXDO7ETJ5KJEFU6UDWXLYMGYOJX", false, "admin@shoppingcart.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4F2FED6E-34E0-44D3-8E97-E848DFC3DE7C", "8e9b2e07-5b77-43fa-aee0-91c607c94d79" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4F2FED6E-34E0-44D3-8E97-E848DFC3DE7C", "8e9b2e07-5b77-43fa-aee0-91c607c94d79" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e9b2e07-5b77-43fa-aee0-91c607c94d79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60fecca9-8070-4d0b-9ccc-3ff6d077971c", "60fecca9-8070-4d0b-9ccc-3ff6d077971c", "Writer", "WRITER" },
                    { "ede95183-48e9-4312-9cf9-499554fc53ed", "ede95183-48e9-4312-9cf9-499554fc53ed", "Reader", "READER" }
                });
        }
    }
}
