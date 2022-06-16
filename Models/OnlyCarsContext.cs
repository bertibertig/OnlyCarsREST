﻿using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlyCars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<ParkingPlace>(entity =>
            {
                entity.ToTable("ParkingPlace");

                entity.Property(e => e.CarId)
                    .HasMaxLength(10)
                    .HasColumnName("carId")
                    .IsFixedLength();

                entity.Property(e => e.Ldx)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ldx")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Ldy)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ldy")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Occupied)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("occupied");

                entity.Property(e => e.ParkingNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("parkingNumber");

                entity.Property(e => e.Urx)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("urx")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Ury)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ury")
                    .HasDefaultValueSql("((-1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
