using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerSite.Migrations
{
    public partial class updateSeed11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 21, "/images/Tablet/tl1_2.png", 4 },
                    { 35, "/images/Laptop/lt3_1.png", 9 },
                    { 34, "/images/Laptop/lt2_3.png", 8 },
                    { 33, "/images/Laptop/lt2_2.png", 8 },
                    { 32, "/images/Laptop/lt2_1.png", 8 },
                    { 31, "/images/Laptop/lt1_3.png", 7 },
                    { 30, "/images/Laptop/lt1_2.png", 7 },
                    { 36, "/images/Laptop/lt3_2.png", 9 },
                    { 29, "/images/Laptop/lt1_1.png", 7 },
                    { 27, "/images/Tablet/tl3_2.png", 6 },
                    { 26, "/images/Tablet/tl3_1.png", 6 },
                    { 25, "/images/Tablet/tl2_3.png", 5 },
                    { 24, "/images/Tablet/tl2_2.png", 5 },
                    { 23, "/images/Tablet/tl2_1.png", 5 },
                    { 22, "/images/Tablet/tl1_3.png", 4 },
                    { 28, "/images/Tablet/tl3_3.png", 6 },
                    { 37, "/images/Laptop/lt3_3.png", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);
        }
    }
}
