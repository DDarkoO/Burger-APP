﻿// <auto-generated />
using BurgerApp.DATA.ACCESS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerApp.DATA.ACCESS.Migrations
{
    [DbContext(typeof(BurgerAppDbContext))]
    [Migration("20220728221346_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasFries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Hamburger",
                            Price = 200.0
                        },
                        new
                        {
                            Id = 2,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Cheeseburger",
                            Price = 180.0
                        },
                        new
                        {
                            Id = 3,
                            HasFries = false,
                            IsVegan = true,
                            IsVegetarian = true,
                            Name = "Greenburger",
                            Price = 190.0
                        },
                        new
                        {
                            Id = 4,
                            HasFries = false,
                            IsVegan = true,
                            IsVegetarian = true,
                            Name = "Fitburger",
                            Price = 220.0
                        },
                        new
                        {
                            Id = 5,
                            HasFries = true,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Happy Burger",
                            Price = 250.0
                        });
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.BurgerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("BurgerSize")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfBurgers")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("OrderId");

                    b.ToTable("BurgerOrder");
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("StoreAddress")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDelivered = false,
                            PaymentMethod = 2,
                            StoreAddress = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDelivered = true,
                            PaymentMethod = 1,
                            StoreAddress = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsDelivered = false,
                            PaymentMethod = 2,
                            StoreAddress = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsDelivered = false,
                            PaymentMethod = 2,
                            StoreAddress = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsDelivered = true,
                            PaymentMethod = 1,
                            StoreAddress = 5,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bulls Arena",
                            FullName = "Michael Jordan"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Maranelo PitStop 1",
                            FullName = "Charles Leclerc"
                        },
                        new
                        {
                            Id = 3,
                            Address = "San Siro trophy room",
                            FullName = "Ricardo Kaka"
                        },
                        new
                        {
                            Id = 4,
                            Address = "San Siro Stands",
                            FullName = "Paolo Maldini"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Tottenham Hotspur Stadium",
                            FullName = "Harry Kane"
                        });
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.BurgerOrder", b =>
                {
                    b.HasOne("BurgerApp.DOMAIN.Models.Burger", "Burger")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerApp.DOMAIN.Models.Order", "Order")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.Order", b =>
                {
                    b.HasOne("BurgerApp.DOMAIN.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.Burger", b =>
                {
                    b.Navigation("BurgerOrders");
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.Order", b =>
                {
                    b.Navigation("BurgerOrders");
                });

            modelBuilder.Entity("BurgerApp.DOMAIN.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
