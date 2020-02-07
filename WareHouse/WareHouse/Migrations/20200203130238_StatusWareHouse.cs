using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouse.Migrations
{
    public partial class StatusWareHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:role", "admin,worker");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "WareHouse",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WareHouse");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:role", "admin,worker");
        }
    }
}
