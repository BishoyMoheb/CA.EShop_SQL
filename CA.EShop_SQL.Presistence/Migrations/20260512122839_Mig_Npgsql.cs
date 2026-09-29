using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CA.EShop_SQL.Presistence.Migrations
{
    public partial class Mig_Npgsql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbS_Customers",
                columns: table => new
                {
                    C_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbS_Customers", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "DbS_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price_Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbS_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbS_ROSummaries",
                columns: table => new
                {
                    ROSummaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cust_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbS_ROSummaries", x => x.ROSummaryId);
                });

            migrationBuilder.CreateTable(
                name: "DbS_Orders",
                columns: table => new
                {
                    O_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    C_Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbS_Orders", x => x.O_Id);
                    table.ForeignKey(
                        name: "FK_DbS_Orders_DbS_Customers_C_Id",
                        column: x => x.C_Id,
                        principalTable: "DbS_Customers",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbS_LineItems",
                columns: table => new
                {
                    LI_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProdId = table.Column<Guid>(type: "uuid", nullable: true),
                    Price_Currency = table.Column<string>(type: "text", nullable: true),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbS_LineItems", x => x.LI_Id);
                    table.ForeignKey(
                        name: "FK_DbS_LineItems_DbS_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DbS_Orders",
                        principalColumn: "O_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbS_LineItems_DbS_Products_ProdId",
                        column: x => x.ProdId,
                        principalTable: "DbS_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbS_Customers_Email",
                table: "DbS_Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbS_LineItems_OrderId",
                table: "DbS_LineItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DbS_LineItems_ProdId",
                table: "DbS_LineItems",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_DbS_Orders_C_Id",
                table: "DbS_Orders",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbS_LineItems");

            migrationBuilder.DropTable(
                name: "DbS_ROSummaries");

            migrationBuilder.DropTable(
                name: "DbS_Orders");

            migrationBuilder.DropTable(
                name: "DbS_Products");

            migrationBuilder.DropTable(
                name: "DbS_Customers");
        }
    }
}
