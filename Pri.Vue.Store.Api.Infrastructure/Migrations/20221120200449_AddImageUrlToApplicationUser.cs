using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Vue.Store.Api.Infrastructure.Migrations
{
    public partial class AddImageUrlToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e834f602-f9e4-4914-b4ea-e884c28f546f", "images/users/1.jpg", "AQAAAAEAACcQAAAAEN4Y1NW4OubpNTrgzcDi7BNi/7Zyv1a1YTkvkystAUXQiq6K0r/WpN1NFHYuhv/oOw==", "df7fa394-ce00-468f-8d16-81b5b2930aa4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bab4bc0-fe4a-488b-9c67-2c772dfcdcd3", "AQAAAAEAACcQAAAAEGd7L8XOVzXA5VAcjBuZnEB4odUQPmD7lTt11a6mtSvRJ06Q5CaH3glFVQhIpjeshg==", "8daffbaa-84a6-464c-9426-2f11caab39b9" });
        }
    }
}
