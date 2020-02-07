using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouse.Migrations
{
    public partial class IncomeItemWareHouse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems",
                column: "WareHouseId",
                unique: true);
        }
    }
}
