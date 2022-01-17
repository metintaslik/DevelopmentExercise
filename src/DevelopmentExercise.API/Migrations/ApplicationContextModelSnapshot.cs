﻿// <auto-generated />
using System;
using DevelopmentExercise.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevelopmentExercise.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("DevelopmentExercise.API.Models.Discount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiscountDescription")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Percentage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoleID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(19, 2)");

                    b.HasKey("ID");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DiscountDescription = "For an employee of the store, gets a 30% discount",
                            Percentage = true,
                            RoleID = 1,
                            Value = 0.3m
                        },
                        new
                        {
                            ID = 2,
                            DiscountDescription = "For an affiliate of the store, gets a 10% discount",
                            Percentage = true,
                            RoleID = 2,
                            Value = 0.1m
                        },
                        new
                        {
                            ID = 3,
                            DiscountDescription = "Customer for over 2 years, gets a 5% discount",
                            Percentage = true,
                            RoleID = 3,
                            Value = 0.5m
                        },
                        new
                        {
                            ID = 4,
                            DiscountDescription = "For every $100 on the bill, there would be a $ 5 discount",
                            Percentage = false,
                            Value = 5m
                        });
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InvoiceTotalPrice")
                        .HasColumnType("decimal(19, 2)");

                    b.Property<int>("OrderID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DiscountCost")
                        .HasColumnType("decimal(19, 2)");

                    b.Property<decimal>("OrderCost")
                        .HasColumnType("decimal(19, 2)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityCount")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(19, 2)");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4962),
                            DiscountCost = 0.00m,
                            OrderCost = 36778.74m,
                            OrderNumber = "HRWE6WTI",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4968),
                            DiscountCost = 0.00m,
                            OrderCost = 10980.00m,
                            OrderNumber = "750JB8JJ",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 2
                        },
                        new
                        {
                            ID = 3,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4972),
                            DiscountCost = 0.00m,
                            OrderCost = 950.00m,
                            OrderNumber = "KZ8VVPBX",
                            QuantityCount = 2,
                            TotalCost = 0m,
                            UserID = 3
                        },
                        new
                        {
                            ID = 4,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4977),
                            DiscountCost = 0.00m,
                            OrderCost = 600.75m,
                            OrderNumber = "GFY1SSWF",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 4
                        },
                        new
                        {
                            ID = 5,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4981),
                            DiscountCost = 0.00m,
                            OrderCost = 4999.00m,
                            OrderNumber = "391RNVTZ",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 2
                        },
                        new
                        {
                            ID = 6,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4987),
                            DiscountCost = 0.00m,
                            OrderCost = 17999.00m,
                            OrderNumber = "X2020IK0",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 1
                        },
                        new
                        {
                            ID = 7,
                            Created = new DateTime(2022, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4991),
                            DiscountCost = 0.00m,
                            OrderCost = 99.99m,
                            OrderNumber = "NDNRZ0L8",
                            QuantityCount = 1,
                            TotalCost = 0m,
                            UserID = 4
                        });
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Created = new DateTime(2017, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4613),
                            Email = "metinn.taslik@gmail.com",
                            FirstName = "Metin",
                            LastName = "TASLIK",
                            Role = 1,
                            RoleID = 1
                        },
                        new
                        {
                            ID = 2,
                            Created = new DateTime(2018, 1, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4633),
                            Email = "metinn.taslik@outlook.com",
                            FirstName = "Metin",
                            LastName = "TASLIK",
                            Role = 3,
                            RoleID = 3
                        },
                        new
                        {
                            ID = 3,
                            Created = new DateTime(2021, 7, 16, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4636),
                            Email = "demo@demo.com",
                            FirstName = "Demo",
                            LastName = "DEMO",
                            Role = 2,
                            RoleID = 2
                        },
                        new
                        {
                            ID = 4,
                            Created = new DateTime(2022, 1, 9, 15, 13, 37, 920, DateTimeKind.Local).AddTicks(4643),
                            Email = "test@test.com",
                            FirstName = "Test",
                            LastName = "TEST",
                            Role = 3,
                            RoleID = 3
                        });
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.Invoice", b =>
                {
                    b.HasOne("DevelopmentExercise.API.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.Order", b =>
                {
                    b.HasOne("DevelopmentExercise.API.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevelopmentExercise.API.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
