using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlyCarsREST.Models
{
    public partial class OnlyCarsContext : DbContext
    {
        public OnlyCarsContext()
        {
        }

        public OnlyCarsContext(DbContextOptions<OnlyCarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlyCars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParkingPlace>(entity =>
            {
                entity.ToTable("ParkingPlace");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CarId)
                    .HasMaxLength(10)
                    .HasColumnName("carId")
                    .IsFixedLength();

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.ParkingNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("parkingNumber");

                entity.Property(e => e.X)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("y");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
