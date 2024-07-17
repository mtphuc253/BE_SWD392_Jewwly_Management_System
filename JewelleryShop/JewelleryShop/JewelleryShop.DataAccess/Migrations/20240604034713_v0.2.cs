using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelleryShop.DataAccess.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Image",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemImagesID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemInvoiceID",
                table: "Warranty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "StaffID");

            migrationBuilder.AlterColumn<string>(
                name: "StationID",
                table: "StaffStation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaionName",
                table: "StaffStation",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GemStoneID",
                table: "Items",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffStation",
                table: "StaffStation",
                column: "StationID");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                    table.ForeignKey(
                        name: "FK__Brand__ItemID__208CD6FA",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Gemstone",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GemstoneName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rarity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Hardness = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemstone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ItemImage",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImage", x => x.id);
                    table.ForeignKey(
                        name: "FK__ItemImage__ItemI__123EB7A3",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaterial",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaterialID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__ItemMater__ItemI__395884C4",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID");
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MaterialPrices",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PriceUSD = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPrices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
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
                    table.PrimaryKey("PK_Promotion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnPolicy",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReturnPolicyType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReturnDuration = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnPolicy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RewardsProgram",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PointsTotal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardsProgram", x => x.id);
                    table.ForeignKey(
                        name: "FK_RewardsProgram_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemCollection",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CollectionID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemColl__25A0E829219DFE2F", x => new { x.ItemID, x.CollectionID });
                    table.ForeignKey(
                        name: "FK__ItemColle__Colle__1DB06A4F",
                        column: x => x.CollectionID,
                        principalTable: "Collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ItemColle__ItemI__1CBC4616",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleID",
                table: "Staff",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StationID",
                table: "Staff",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GemStoneID",
                table: "Items",
                column: "GemStoneID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInvoice_ReturnPolicyID",
                table: "ItemInvoice",
                column: "ReturnPolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ItemID",
                table: "Brand",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCollection_CollectionID",
                table: "ItemCollection",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_ItemID",
                table: "ItemImage",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaterial_ItemID",
                table: "ItemMaterial",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RewardsProgram_CustomerID",
                table: "RewardsProgram",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInvoice_ReturnPolicy",
                table: "ItemInvoice",
                column: "ReturnPolicyID",
                principalTable: "ReturnPolicy",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Gemstone",
                table: "Items",
                column: "GemStoneID",
                principalTable: "Gemstone",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Roles",
                table: "Staff",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_StaffStation",
                table: "Staff",
                column: "StationID",
                principalTable: "StaffStation",
                principalColumn: "StationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemInvoice_ReturnPolicy",
                table: "ItemInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Gemstone",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Roles",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_StaffStation",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Gemstone");

            migrationBuilder.DropTable(
                name: "ItemCollection");

            migrationBuilder.DropTable(
                name: "ItemImage");

            migrationBuilder.DropTable(
                name: "ItemMaterial");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MaterialPrices");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "ReturnPolicy");

            migrationBuilder.DropTable(
                name: "RewardsProgram");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffStation",
                table: "StaffStation");

            migrationBuilder.DropIndex(
                name: "IX_Staff_RoleID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_StationID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Items_GemStoneID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemInvoice_ReturnPolicyID",
                table: "ItemInvoice");

            migrationBuilder.DropColumn(
                name: "StaionName",
                table: "StaffStation");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "GemStoneID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Staff",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ItemInvoiceID",
                table: "Warranty",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StationID",
                table: "StaffStation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RoleID",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ItemImagesID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ItemImagesID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemImagesID",
                table: "Items",
                column: "ItemImagesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Image",
                table: "Items",
                column: "ItemImagesID",
                principalTable: "Image",
                principalColumn: "ItemImagesID");
        }
    }
}
