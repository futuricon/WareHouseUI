using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WareHouse.Migrations
{
    public partial class Prividers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_WareHouse_WareHouseId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WareHouse_WareHouseId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WareHouse",
                table: "WareHouse");

            migrationBuilder.RenameTable(
                name: "WareHouse",
                newName: "WareHouses");

            migrationBuilder.AddColumn<string>(
                name: "FIO",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WareHouses",
                table: "WareHouses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIO = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_WareHouses_WareHouseId",
                table: "Incomes",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WareHouses_WareHouseId",
                table: "Products",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_WareHouses_WareHouseId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WareHouses_WareHouseId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WareHouses",
                table: "WareHouses");

            migrationBuilder.DropColumn(
                name: "FIO",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "WareHouses",
                newName: "WareHouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WareHouse",
                table: "WareHouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_WareHouse_WareHouseId",
                table: "Incomes",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WareHouse_WareHouseId",
                table: "Products",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
