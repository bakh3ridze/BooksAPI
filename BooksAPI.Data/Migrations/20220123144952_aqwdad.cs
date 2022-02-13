using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAPI.Data.Migrations
{
    public partial class aqwdad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef744a65-28ca-44b7-be2c-5c7e475517fb", "AQAAAAEAACcQAAAAEJSEV9A6ZDJ9UPc+VnDw2ly+2YGu6zyYO0+BgJUa9NCva7ujm6PqxLHhwxWWNFKaLQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37f0bacf-9de7-41c7-a5ad-48dd9dca5321", "AQAAAAEAACcQAAAAEMWXYPuefdElt3xPW06JnySx4W6Tx/82o1LuKpg74AFVFG51bGFQKUPAfnqIFvOyOQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa838aec-4191-44cd-b224-8fd28a4c43e2", "AQAAAAEAACcQAAAAEFYhjeB0l+rxFUHTijUTwyatW+6of3hTu2ZybAQ+fQi8epnDoZBfvCGUPDCbK+Klvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb3df983-c61e-4e51-90b9-636731e7b5b1", "AQAAAAEAACcQAAAAELTQbsNi+rajb4B8t82zYgkNBtti/WOd3l9q9CcCaPzXSD74Ono6IM/Gc5Ekvl3bzQ==" });
        }
    }
}
