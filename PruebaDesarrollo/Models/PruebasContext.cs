using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaDesarrollo.Models
{
    public partial class PruebasContext : DbContext
    {
        public PruebasContext()
        {
        }

        public PruebasContext(DbContextOptions<PruebasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=URANO;Initial Catalog=Pruebas;Persist Security Info=True;User ID=administra;Password=proespec");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP850_CI_AI");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__City__AA1D437804095DB6");

                entity.ToTable("City");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Seller__AA1D4378DF1AF919");

                entity.ToTable("Seller");

                entity.Property(e => e.Code)
                    .ValueGeneratedNever()
                    .HasColumnName("CODE");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.Document)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENT");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Code)
                .ValueGeneratedOnAdd()
                .HasColumnName("CODE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Seller__CITY_ID__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
