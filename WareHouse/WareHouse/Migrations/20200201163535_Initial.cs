using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WareHouse.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<double>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exemptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(nullable: false),
                    Count = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CostPrice = table.Column<double>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemOrders", x => new { x.OrderId, x.OrderItemId });
                    table.ForeignKey(
                        name: "FK_OrderItemOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemOrders_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Total = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    LastSync = table.Column<DateTime>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeItemIncomes",
                columns: table => new
                {
                    IncomeId = table.Column<int>(nullable: false),
                    IncomeItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeItemIncomes", x => new { x.IncomeId, x.IncomeItemId });
                    table.ForeignKey(
                        name: "FK_IncomeItemIncomes_Incomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeItemIncomes_IncomeItems_IncomeItemId",
                        column: x => x.IncomeItemId,
                        principalTable: "IncomeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeItemIncomes_IncomeItemId",
                table: "IncomeItemIncomes",
                column: "IncomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeItems_ProductId",
                table: "IncomeItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ProductId",
                table: "Incomes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_WareHouseId",
                table: "Incomes",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemOrders_OrderItemId",
                table: "OrderItemOrders",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderItemId",
                table: "Products",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WareHouseId",
                table: "Products",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemptions");

            migrationBuilder.DropTable(
                name: "IncomeItemIncomes");

            migrationBuilder.DropTable(
                name: "OrderItemOrders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "IncomeItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "WareHouse");
        }
    }
}
