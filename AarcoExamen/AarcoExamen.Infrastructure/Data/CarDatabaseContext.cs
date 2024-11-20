using System;
using System.Collections.Generic;
using AarcoExamen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AarcoExamen.Infrastructure.Data
{
    public partial class CarDatabaseContext : DbContext
    {
        public CarDatabaseContext()
        {
        }

        public CarDatabaseContext(DbContextOptions<CarDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descripcion> Descripcions { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Submarca> Submarcas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.ToTable("Descripcion");

                entity.Property(e => e.DescripcionId).ValueGeneratedNever();

                entity.Property(e => e.Detalle).HasMaxLength(255);

                entity.HasOne(d => d.Modelo)
                    .WithOne(p => p.Descripcion)
                    .HasConstraintName("FK__Modelo__Descripcion__3C69FB99");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");
            });

            modelBuilder.Entity<Submarca>(entity =>
            {
                entity.ToTable("Submarca");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Submarcas)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK__Submarca__MarcaI__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
