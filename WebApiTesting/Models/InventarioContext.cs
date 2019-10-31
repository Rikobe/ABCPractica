using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiTesting.Models
{
    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
        {
        }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__Producto__A430AEA364E2AD04");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
