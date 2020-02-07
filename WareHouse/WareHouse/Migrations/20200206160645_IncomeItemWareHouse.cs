using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouse.Migrations
{
    public partial class IncomeItemWareHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_WareHouses_WareHouseId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_WareHouseId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Incomes");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "IncomeItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems",
                column: "WareHouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeItems_WareHouses_WareHouseId",
                table: "IncomeItems",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeItems_WareHouses_WareHouseId",
                table: "IncomeItems");

            migrationBuilder.DropIndex(
                name: "IX_IncomeItems_WareHouseId",
                table: "IncomeItems");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "IncomeItems");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Incomes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_WareHouseId",
                table: "Incomes",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_WareHouses_WareHouseId",
                table: "Incomes",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
