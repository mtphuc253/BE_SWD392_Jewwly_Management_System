using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelleryShop.DataAccess.Migrations
{
    public partial class staffstation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_ItemInvoice_ItemID",
                table: "ItemInvoice");

            migrationBuilder.DropColumn(
                name: "ReturnPolicyID",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemInvoice",
                table: "ItemInvoice",
                columns: new[] { "ItemID", "InvoiceID" });

            migrationBuilder.CreateTable(
                name: "CustomerPromotion",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiscountPct = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPromotion", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Station",
                table: "Staff",
                column: "StationID",
                principalTable: "Station",
                principalColumn: "StationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Station",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "CustomerPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemInvoice",
                table: "ItemInvoice");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ReturnPolicyID",
                table: "Invoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiscountPct = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemInvoice_ItemID",
                table: "ItemInvoice",
                column: "ItemID");
        }
    }
}
