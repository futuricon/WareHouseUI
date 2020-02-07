using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouse.Migrations
{
    public partial class ProviderIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderTableId",
                table: "Incomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ProviderTableId",
                table: "Incomes",
                column: "ProviderTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Providers_ProviderTableId",
                table: "Incomes",
                column: "ProviderTableId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Providers_ProviderTableId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_ProviderTableId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ProviderTableId",
                table: "Incomes");
        }
    }
}
