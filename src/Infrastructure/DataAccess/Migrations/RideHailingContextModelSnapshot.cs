﻿// <auto-generated />
using System;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(RideHailingContext))]
    partial class RideHailingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Domain.Coupons.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdmissibleUses")
                        .HasColumnType("int");

                    b.Property<int>("CurrentUsesCounter")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Core.Domain.Coupons.CouponCustomer", b =>
                {
                    b.Property<Guid>("CouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CouponId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CouponUsers");
                });

            modelBuilder.Entity("Core.Domain.Customers.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Domain.Customers.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Core.Domain.Drivers.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Core.Domain.Drivers.Opinion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("Core.Domain.Rides.Ride", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DriverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("Core.Domain.Coupons.CouponCustomer", b =>
                {
                    b.HasOne("Core.Domain.Coupons.Coupon", "Coupon")
                        .WithMany("CouponUsers")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Customers.PaymentMethod", b =>
                {
                    b.HasOne("Core.Domain.Customers.Customer", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Drivers.Driver", b =>
                {
                    b.OwnsOne("Core.Domain.Drivers.Vehicle", "Vehicle", b1 =>
                        {
                            b1.Property<string>("DriverId")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("DriverId");

                            b1.ToTable("Drivers");

                            b1.WithOwner()
                                .HasForeignKey("DriverId");
                        });
                });

            modelBuilder.Entity("Core.Domain.Drivers.Opinion", b =>
                {
                    b.HasOne("Core.Domain.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Drivers.Driver", null)
                        .WithMany("Opinions")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Rides.Ride", b =>
                {
                    b.HasOne("Core.Domain.Coupons.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.HasOne("Core.Domain.Customers.Customer", "Customer")
                        .WithMany("Rides")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Drivers.Driver", "Driver")
                        .WithMany("Rides")
                        .HasForeignKey("DriverId");

                    b.OwnsOne("Core.Domain.Money", "Cost", b1 =>
                        {
                            b1.Property<Guid>("RideId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18, 2)");

                            b1.HasKey("RideId");

                            b1.ToTable("Rides");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });

                    b.OwnsOne("Core.Domain.Rides.Node", "Destination", b1 =>
                        {
                            b1.Property<Guid>("RideId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Latitude")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<decimal>("Longitude")
                                .HasColumnType("decimal(18, 2)");

                            b1.HasKey("RideId");

                            b1.ToTable("Rides");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });

                    b.OwnsOne("Core.Domain.Rides.Node", "Origin", b1 =>
                        {
                            b1.Property<Guid>("RideId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Latitude")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<decimal>("Longitude")
                                .HasColumnType("decimal(18, 2)");

                            b1.HasKey("RideId");

                            b1.ToTable("Rides");

                            b1.WithOwner()
                                .HasForeignKey("RideId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
