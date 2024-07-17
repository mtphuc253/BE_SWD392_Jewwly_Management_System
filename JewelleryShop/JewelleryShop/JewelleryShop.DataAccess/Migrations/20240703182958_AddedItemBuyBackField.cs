using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelleryShop.DataAccess.Migrations
{
    public partial class AddedItemBuyBackField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemImagesID",
                table: "Items",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBuyBack",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ItemInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Gemstone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CusID",
                table: "CustomerPromotion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerPromotion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromotionID",
                table: "Customer",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPromotion_CusID",
                table: "CustomerPromotion",
                column: "CusID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PromotionID",
                table: "Customer",
                column: "PromotionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerPromotion",
                table: "Customer",
                column: "PromotionID",
                principalTable: "CustomerPromotion",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPromotion_Customer",
                table: "CustomerPromotion",
                column: "CusID",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerPromotion",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPromotion_Customer",
                table: "CustomerPromotion");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPromotion_CusID",
                table: "CustomerPromotion");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PromotionID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsBuyBack",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemInvoice");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Gemstone");

            migrationBuilder.DropColumn(
                name: "CusID",
                table: "CustomerPromotion");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerPromotion");

            migrationBuilder.DropColumn(
                name: "PromotionID",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "ItemImagesID",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
