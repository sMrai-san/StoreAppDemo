using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreApp.Data.DatabaseModel
{
    public partial class StoreAppContext : DbContext
    {
        public StoreAppContext()
        {
         
        }

        public StoreAppContext(DbContextOptions<StoreAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartStatus> CartStatus { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<MemberRoles> MemberRoles { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetails { get; set; }
        public virtual DbSet<SlideImages> SlideImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.200;Database=StoreApp;User ID=superuser;Password=superuser;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart__CartStatus__4AB81AF0");
            });

            modelBuilder.Entity<CartStatus>(entity =>
            {
                entity.Property(e => e.CartStatus1)
                    .HasColumnName("CartStatus")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A0BE807EC71");

                entity.HasIndex(e => e.CategoryName)
                    .HasDatabaseName("UQ__Categori__8517B2E0CA7BAEDF")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberRoles>(entity =>
            {
                entity.HasKey(e => e.MemberRoleId)
                    .HasName("PK__MemberRo__673C212B981BD403");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Members__0CF04B18B41B7A9B");

                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("UQ__Members__A9D10534207A5EFB")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CD2EAB5074");

                entity.HasIndex(e => e.ProductName)
                    .HasDatabaseName("UQ__Products__DD5A978AD7A1D39A")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__3B75D760");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1ADCF17A28");

                entity.HasIndex(e => e.RoleName)
                    .HasDatabaseName("UQ__Roles__8A2B6160AB7CC3D4")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShippingDetails>(entity =>
            {
                entity.HasKey(e => e.ShippingDetailId)
                    .HasName("PK__Shipping__FBB368513C3C81F3");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ShippingDetails)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__ShippingD__Payme__4316F928");
            });

            modelBuilder.Entity<SlideImages>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK__SlideIma__9E7CB650B1BAADC5");

                entity.Property(e => e.SlideDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SlideImage).IsUnicode(false);

                entity.Property(e => e.SlideTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
