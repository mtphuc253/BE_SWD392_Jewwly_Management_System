using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JewelleryShop.DataAccess.Models
{
    public partial class JewelleryDBContext : DbContext
    {
        public JewelleryDBContext()
        {
        }

        public JewelleryDBContext(DbContextOptions<JewelleryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerPromotion> CustomerPromotions { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Gemstone> Gemstones { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemImage> ItemImages { get; set; } = null!;
        public virtual DbSet<ItemInvoice> ItemInvoices { get; set; } = null!;
        public virtual DbSet<ItemMaterial> ItemMaterials { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MaterialPrice> MaterialPrices { get; set; } = null!;
        public virtual DbSet<ReturnPolicy> ReturnPolicies { get; set; } = null!;
        public virtual DbSet<RewardsProgram> RewardsPrograms { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StaffStation> StaffStations { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Warranty> Warranties { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Brand__ItemID__208CD6FA");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collection");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CustomerName).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PromotionId)
                    .HasMaxLength(450)
                    .HasColumnName("PromotionID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_Customer_CustomerPromotion");
            });

            modelBuilder.Entity<CustomerPromotion>(entity =>
            {
                entity.ToTable("CustomerPromotion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CusId)
                    .HasMaxLength(50)
                    .HasColumnName("CusID");

                entity.Property(e => e.DiscountPct).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.CustomerPromotions)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_CustomerPromotion_Customer");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountCode).HasMaxLength(50);

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Gemstone>(entity =>
            {
                entity.ToTable("Gemstone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Colour).HasMaxLength(255);

                entity.Property(e => e.GemstoneName).HasMaxLength(255);

                entity.Property(e => e.Hardness).HasMaxLength(255);

                entity.Property(e => e.Origin).HasMaxLength(255);

                entity.Property(e => e.Rarity).HasMaxLength(255);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.BuyerAddress).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.StaffId).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoice__Custome__66603565");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Invoice__StaffId__656C112C");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.AccessoryType).HasMaxLength(50);

                entity.Property(e => e.BrandId)
                    .HasMaxLength(50)
                    .HasColumnName("BrandID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.GemStoneId)
                    .HasMaxLength(450)
                    .HasColumnName("GemStoneID");

                entity.Property(e => e.ItemImagesId)
                    .HasMaxLength(450)
                    .HasColumnName("ItemImagesID");

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(50);

                entity.HasOne(d => d.GemStone)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.GemStoneId)
                    .HasConstraintName("FK_Items_Gemstone");

                entity.HasMany(d => d.Collections)
                    .WithMany(p => p.Items)
                    .UsingEntity<Dictionary<string, object>>(
                        "ItemCollection",
                        l => l.HasOne<Collection>().WithMany().HasForeignKey("CollectionId").HasConstraintName("FK__ItemColle__Colle__1DB06A4F"),
                        r => r.HasOne<Item>().WithMany().HasForeignKey("ItemId").HasConstraintName("FK__ItemColle__ItemI__1CBC4616"),
                        j =>
                        {
                            j.HasKey("ItemId", "CollectionId").HasName("PK__ItemColl__25A0E829219DFE2F");

                            j.ToTable("ItemCollection");

                            j.IndexerProperty<string>("ItemId").HasMaxLength(50).HasColumnName("ItemID");

                            j.IndexerProperty<string>("CollectionId").HasColumnName("CollectionID");
                        });
            });

            modelBuilder.Entity<ItemImage>(entity =>
            {
                entity.ToTable("ItemImage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.ThumbnailUrl).HasColumnName("ThumbnailURL");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemImages)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ItemImage__ItemI__123EB7A3");
            });

            modelBuilder.Entity<ItemInvoice>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.InvoiceId });

                entity.ToTable("ItemInvoice");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.InvoiceId)
                    .HasMaxLength(50)
                    .HasColumnName("InvoiceID");

                entity.Property(e => e.ReturnPolicyId)
                    .HasMaxLength(50)
                    .HasColumnName("ReturnPolicyID");

                entity.Property(e => e.WarrantyId)
                    .HasMaxLength(50)
                    .HasColumnName("WarrantyID");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ItemInvoices)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemInvoi__Invoi__6FE99F9F");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemInvoices)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemInvoi__ItemI__6EF57B66");

                entity.HasOne(d => d.ReturnPolicy)
                    .WithMany(p => p.ItemInvoices)
                    .HasForeignKey(d => d.ReturnPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemInvoice_ReturnPolicy");

                entity.HasOne(d => d.Warranty)
                    .WithMany(p => p.ItemInvoices)
                    .HasForeignKey(d => d.WarrantyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemInvoice_Warranty");
            });

            modelBuilder.Entity<ItemMaterial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ItemMaterial");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__ItemMater__ItemI__395884C4");

                entity.HasOne(d => d.Material)
                    .WithMany()
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_ItemMaterial_Material");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.Property(e => e.MaterialDescription).HasMaxLength(450);

                entity.Property(e => e.MaterialName).HasMaxLength(150);
            });

            modelBuilder.Entity<MaterialPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PriceUsd)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("PriceUSD");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(255)
                    .HasColumnName("symbol");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReturnPolicy>(entity =>
            {
                entity.ToTable("ReturnPolicy");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnPolicyType).HasMaxLength(255);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RewardsProgram>(entity =>
            {
                entity.ToTable("RewardsProgram");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RewardsPrograms)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_RewardsProgram_Customer");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<StaffStation>(entity =>
            {
                entity.HasKey(e => e.StationId);

                entity.ToTable("StaffStation");

                entity.Property(e => e.StationId)
                    .HasMaxLength(50)
                    .HasColumnName("StationID");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .HasColumnName("StaffID");

                entity.Property(e => e.StaionName).HasMaxLength(450);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Station");

                entity.Property(e => e.StationId)
                    .HasMaxLength(50)
                    .HasColumnName("StationID");

                entity.Property(e => e.StationName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.ToTable("Warranty");

                entity.Property(e => e.WarrantyId)
                    .HasMaxLength(50)
                    .HasColumnName("WarrantyID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Warranties)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Warranty__Custom__00200768");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .HasColumnName("StaffID");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(25);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StationId)
                    .HasMaxLength(50)
                    .HasColumnName("StationID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Roles");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Staff_StaffStation");

                entity.HasOne(d => d.StationNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Staff_Station");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
