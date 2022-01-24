using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Origin.DataContext
{
    public partial class OriginContext : DbContext
    {
        public OriginContext()
        {
        }

        public OriginContext(DbContextOptions<OriginContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Retiro> Retiro { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;Database=Origin;Uid=root;Pwd=agustina00;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PRIMARY");

                entity.ToTable("balance");

                entity.HasIndex(e => e.IdTarjeta)
                    .HasName("id_id_tarjeta_idx");

                entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");
            });

            modelBuilder.Entity<Retiro>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PRIMARY");

                entity.ToTable("retiro");

                entity.HasIndex(e => e.IdTarjeta)
                    .HasName("id_tarjeta_id_idx");

                entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.ToTable("tarjeta");

                entity.HasIndex(e => e.Numero)
                    .HasName("numero_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Bloqueada)
                    .HasColumnName("bloqueada")
                    .HasColumnType("bit");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Pin).HasColumnName("pin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
