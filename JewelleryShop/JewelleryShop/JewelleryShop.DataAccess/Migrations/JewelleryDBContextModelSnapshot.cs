﻿// <auto-generated />
using System;
using JewelleryShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelleryShop.DataAccess.Migrations
{
    [DbContext(typeof(JewelleryDBContext))]
    partial class JewelleryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ItemCollection", b =>
                {
                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("CollectionId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CollectionID");

                    b.HasKey("ItemId", "CollectionId")
                        .HasName("PK__ItemColl__25A0E829219DFE2F");

                    b.HasIndex("CollectionId");

                    b.ToTable("ItemCollection", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Brand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Collection", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("CollectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Collection", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PromotionId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("PromotionID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.CustomerPromotion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CusId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CusID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountPct")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CusId");

                    b.ToTable("CustomerPromotion", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Gemstone", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Colour")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GemstoneName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Hardness")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Origin")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Rarity")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Gemstone", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BuyerAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CustomerID");

                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StaffId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Item", b =>
                {
                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("AccessoryType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BrandID");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GemStoneId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("GemStoneID");

                    b.Property<bool?>("IsBuyBack")
                        .HasColumnType("bit");

                    b.Property<string>("ItemImagesId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ItemImagesID");

                    b.Property<string>("ItemName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Weight")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ItemId");

                    b.HasIndex("GemStoneId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemImage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageURL");

                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ThumbnailURL");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemImage", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemInvoice", b =>
                {
                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("InvoiceId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("InvoiceID");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ReturnPolicyId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ReturnPolicyID");

                    b.Property<string>("WarrantyId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("WarrantyID");

                    b.HasKey("ItemId", "InvoiceId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ReturnPolicyId");

                    b.HasIndex("WarrantyId");

                    b.ToTable("ItemInvoice", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemMaterial", b =>
                {
                    b.Property<string>("ItemId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ItemID");

                    b.Property<string>("MaterialId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MaterialID");

                    b.HasIndex("ItemId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ItemMaterial", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Material", b =>
                {
                    b.Property<string>("MaterialId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MaterialID");

                    b.Property<string>("MaterialDescription")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaterialName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaterialId");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.MaterialPrice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<decimal?>("PriceUsd")
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("PriceUSD");

                    b.Property<string>("Symbol")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("symbol");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("MaterialPrices");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ReturnPolicy", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ReturnDuration")
                        .HasColumnType("int");

                    b.Property<string>("ReturnPolicyType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("ReturnPolicy", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.RewardsProgram", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id");

                    b.Property<string>("CustomerId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CustomerID");

                    b.Property<int?>("PointsTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("RewardsProgram", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.staff", b =>
                {
                    b.Property<string>("StaffId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StaffID");

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("StationId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StationID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StaffId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StationId");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.StaffStation", b =>
                {
                    b.Property<string>("StationId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StationID");

                    b.Property<string>("StaffId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StaffID");

                    b.Property<string>("StaionName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StationId");

                    b.ToTable("StaffStation", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Station", b =>
                {
                    b.Property<string>("StationId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StationID");

                    b.Property<string>("StationName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StationId");

                    b.ToTable("Station", (string)null);
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Warranty", b =>
                {
                    b.Property<string>("WarrantyId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("WarrantyID");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.HasKey("WarrantyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Warranty", (string)null);
                });

            modelBuilder.Entity("ItemCollection", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Collection", null)
                        .WithMany()
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ItemColle__Colle__1DB06A4F");

                    b.HasOne("JewelleryShop.DataAccess.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ItemColle__ItemI__1CBC4616");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Brand", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Item", "Item")
                        .WithMany("Brands")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Brand__ItemID__208CD6FA");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Customer", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.CustomerPromotion", "Promotion")
                        .WithMany("Customers")
                        .HasForeignKey("PromotionId")
                        .HasConstraintName("FK_Customer_CustomerPromotion");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.CustomerPromotion", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Customer", "Cus")
                        .WithMany("CustomerPromotions")
                        .HasForeignKey("CusId")
                        .HasConstraintName("FK_CustomerPromotion_Customer");

                    b.Navigation("Cus");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Invoice", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Invoice__Custome__66603565");

                    b.HasOne("JewelleryShop.DataAccess.Models.staff", "Staff")
                        .WithMany("Invoices")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK__Invoice__StaffId__656C112C");

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Item", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Gemstone", "GemStone")
                        .WithMany("Items")
                        .HasForeignKey("GemStoneId")
                        .HasConstraintName("FK_Items_Gemstone");

                    b.Navigation("GemStone");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemImage", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Item", "Item")
                        .WithMany("ItemImages")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__ItemImage__ItemI__123EB7A3");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemInvoice", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Invoice", "Invoice")
                        .WithMany("ItemInvoices")
                        .HasForeignKey("InvoiceId")
                        .IsRequired()
                        .HasConstraintName("FK__ItemInvoi__Invoi__6FE99F9F");

                    b.HasOne("JewelleryShop.DataAccess.Models.Item", "Item")
                        .WithMany("ItemInvoices")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK__ItemInvoi__ItemI__6EF57B66");

                    b.HasOne("JewelleryShop.DataAccess.Models.ReturnPolicy", "ReturnPolicy")
                        .WithMany("ItemInvoices")
                        .HasForeignKey("ReturnPolicyId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemInvoice_ReturnPolicy");

                    b.HasOne("JewelleryShop.DataAccess.Models.Warranty", "Warranty")
                        .WithMany("ItemInvoices")
                        .HasForeignKey("WarrantyId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemInvoice_Warranty");

                    b.Navigation("Invoice");

                    b.Navigation("Item");

                    b.Navigation("ReturnPolicy");

                    b.Navigation("Warranty");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ItemMaterial", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__ItemMater__ItemI__395884C4");

                    b.HasOne("JewelleryShop.DataAccess.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .HasConstraintName("FK_ItemMaterial_Material");

                    b.Navigation("Item");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.RewardsProgram", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Customer", "Customer")
                        .WithMany("RewardsPrograms")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_RewardsProgram_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.staff", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Role", "Role")
                        .WithMany("staff")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Staff_Roles");

                    b.HasOne("JewelleryShop.DataAccess.Models.StaffStation", "Station")
                        .WithMany("staff")
                        .HasForeignKey("StationId")
                        .HasConstraintName("FK_Staff_StaffStation");

                    b.HasOne("JewelleryShop.DataAccess.Models.Station", "StationNavigation")
                        .WithMany("staff")
                        .HasForeignKey("StationId")
                        .HasConstraintName("FK_Staff_Station");

                    b.Navigation("Role");

                    b.Navigation("Station");

                    b.Navigation("StationNavigation");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Warranty", b =>
                {
                    b.HasOne("JewelleryShop.DataAccess.Models.Customer", "Customer")
                        .WithMany("Warranties")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Warranty__Custom__00200768");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Customer", b =>
                {
                    b.Navigation("CustomerPromotions");

                    b.Navigation("Invoices");

                    b.Navigation("RewardsPrograms");

                    b.Navigation("Warranties");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.CustomerPromotion", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Gemstone", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Invoice", b =>
                {
                    b.Navigation("ItemInvoices");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Item", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("ItemImages");

                    b.Navigation("ItemInvoices");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.ReturnPolicy", b =>
                {
                    b.Navigation("ItemInvoices");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Role", b =>
                {
                    b.Navigation("staff");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.staff", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.StaffStation", b =>
                {
                    b.Navigation("staff");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Station", b =>
                {
                    b.Navigation("staff");
                });

            modelBuilder.Entity("JewelleryShop.DataAccess.Models.Warranty", b =>
                {
                    b.Navigation("ItemInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
