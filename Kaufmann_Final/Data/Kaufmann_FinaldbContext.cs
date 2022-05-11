﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Kaufmann_Final.Models;

namespace Kaufmann_Final.Data
{
    public partial class Kaufmann_FinaldbContext : DbContext
    {
        public Kaufmann_FinaldbContext()
        {
        }

        public Kaufmann_FinaldbContext(DbContextOptions<Kaufmann_FinaldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Infraction> Infractions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleOwner> VehicleOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.DriverLicenseNumber);

                entity.Property(e => e.DriverLicenseNumber)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecurity)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Infraction>(entity =>
            {
                entity.Property(e => e.InfractionId).HasColumnName("InfractionID");

                entity.Property(e => e.FineAmount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.InfractionDate).HasColumnType("date");

                entity.Property(e => e.Offence)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleOwnerId).HasColumnName("VehicleOwnerID");

                entity.HasOne(d => d.VehicleOwner)
                    .WithMany(p => p.Infractions)
                    .HasForeignKey(d => d.VehicleOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Infractions_Vehicles");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.LicensePlateNumber);

                entity.Property(e => e.LicensePlateNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleOwner>(entity =>
            {
                entity.ToTable("VehicleOwner");

                entity.Property(e => e.VehicleOwnerId).HasColumnName("VehicleOwnerID");

                entity.Property(e => e.DriverLicenseNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.LicensePlateNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TitleDateIssued).HasColumnType("date");

                entity.HasOne(d => d.DriverLicenseNumberNavigation)
                    .WithMany(p => p.VehicleOwners)
                    .HasForeignKey(d => d.DriverLicenseNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleOwner_Drivers");

                entity.HasOne(d => d.LicensePlateNumberNavigation)
                    .WithMany(p => p.VehicleOwners)
                    .HasForeignKey(d => d.LicensePlateNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleOwner_Vehicles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}