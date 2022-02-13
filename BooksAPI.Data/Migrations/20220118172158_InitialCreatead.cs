using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAPI.Data.Migrations
{
    public partial class InitialCreatead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "aa838aec-4191-44cd-b224-8fd28a4c43e2", "patrick@fakemail.com", true, false, null, null, "PATRICK", "AQAAAAEAACcQAAAAEFYhjeB0l+rxFUHTijUTwyatW+6of3hTu2ZybAQ+fQi8epnDoZBfvCGUPDCbK+Klvw==", null, false, null, false, "patrick" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "fb3df983-c61e-4e51-90b9-636731e7b5b1", "mike@fakemail.Com", true, false, null, null, "MIKE", "AQAAAAEAACcQAAAAELTQbsNi+rajb4B8t82zYgkNBtti/WOd3l9q9CcCaPzXSD74Ono6IM/Gc5Ekvl3bzQ==", null, false, null, false, "mike" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
