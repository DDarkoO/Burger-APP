using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.DATA.ACCESS.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BurgerOrder",
                columns: new[] { "Id", "BurgerId", "BurgerSize", "NumberOfBurgers", "OrderId" },
                values: new object[,]
                {
                    { 1, 4, 2, 1, 1 },
                    { 2, 4, 1, 1, 2 },
                    { 3, 2, 2, 3, 3 },
                    { 4, 1, 1, 2, 4 },
                    { 5, 3, 2, 1, 4 },
                    { 6, 3, 2, 4, 5 },
                    { 7, 4, 1, 1, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BurgerOrder",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
