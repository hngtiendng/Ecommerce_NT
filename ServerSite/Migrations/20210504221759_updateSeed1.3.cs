using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerSite.Migrations
{
    public partial class updateSeed13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Products",
                newName: "UpdateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Products",
                newName: "Update");
        }
    }
}
