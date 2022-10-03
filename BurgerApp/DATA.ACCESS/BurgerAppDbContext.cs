using BurgerApp.DOMAIN.Enums;
using BurgerApp.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA.ACCESS
{
    public class BurgerAppDbContext : DbContext
    {
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<BurgerOrder> BurgerOrders { get; set; }

        public BurgerAppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            //modelBuilder.Entity<BurgerOrder>(); // Kakva e logikata ovde, t.e. kako terba da izgleda kodot za srednava tabela?


            modelBuilder.Entity<Burger>()
                .HasData(new Burger
                {
                    Id = 1,
                    Name = "Hamburger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 200
                },
                new Burger
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 180
                },
                new Burger
                {
                    Id = 3,
                    Name = "Greenburger",
                    IsVegetarian = true,
                    IsVegan = true,
                    HasFries = false,
                    Price = 190
                },
                new Burger
                {
                    Id = 4,
                    Name = "Fitburger",
                    IsVegetarian = true,
                    IsVegan = true,
                    HasFries = false,
                    Price = 220
                },
                new Burger
                {
                    Id = 5,
                    Name = "Happy Burger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 250
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FullName = "Michael Jordan",
                    Address = "Bulls Arena"
                },
                new User
                {
                    Id = 2,
                    FullName = "Charles Leclerc",
                    Address = "Maranelo PitStop 1"
                },
                new User
                {
                    Id = 3,
                    FullName = "Ricardo Kaka",
                    Address = "San Siro trophy room"
                },
                new User
                {
                    Id = 4,
                    FullName = "Paolo Maldini",
                    Address = "San Siro Stands"
                },
                new User
                {
                    Id = 5,
                    FullName = "Harry Kane",
                    Address = "Tottenham Hotspur Stadium"
                });

            modelBuilder.Entity<Order>()
                .HasData(new Order
                {
                    Id = 1,
                    StoreAddress = StoreAddress.Sedmica_Aerodrom,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    StoreAddress = StoreAddress.Sedmica_Centar,
                    IsDelivered = true,
                    PaymentMethod = PaymentMethod.Cash,
                    UserId = 2
                },
                new Order
                {
                    Id = 3,
                    StoreAddress = StoreAddress.Royal_Aerodrom,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    UserId = 3
                },
                new Order
                {
                    Id = 4,
                    StoreAddress = StoreAddress.Royal_Debar_Maalo,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    UserId = 4
                },
                new Order
                {
                    Id = 5,
                    StoreAddress = StoreAddress.Baking_Bread,
                    IsDelivered = true,
                    PaymentMethod = PaymentMethod.Cash,
                    UserId = 5
                });

            modelBuilder.Entity<BurgerOrder>()
                .HasData(new BurgerOrder
                {
                    Id = 1,
                    BurgerId = 4,
                    OrderId = 1,
                    NumberOfBurgers = 1,
                    BurgerSize = BurgerSize.Double                   
                },
                new BurgerOrder
                {
                    Id = 2,
                    BurgerId = 4,
                    OrderId = 2,
                    NumberOfBurgers = 1,
                    BurgerSize = BurgerSize.Normal
                },
                new BurgerOrder
                {
                    Id = 3,
                    BurgerId = 2,
                    OrderId = 3,
                    NumberOfBurgers = 3,
                    BurgerSize = BurgerSize.Double
                },
                new BurgerOrder
                {
                    Id = 4,
                    BurgerId = 1,
                    OrderId = 4,
                    NumberOfBurgers = 2,
                    BurgerSize = BurgerSize.Normal
                },
                new BurgerOrder
                {
                    Id = 5,
                    BurgerId = 3,
                    OrderId = 4,
                    NumberOfBurgers = 1,
                    BurgerSize = BurgerSize.Double
                },
                new BurgerOrder
                {
                    Id = 6,
                    BurgerId = 3,
                    OrderId = 5,
                    NumberOfBurgers = 4,
                    BurgerSize = BurgerSize.Double
                },
                new BurgerOrder
                {
                    Id = 7,
                    BurgerId = 4,
                    OrderId = 5,
                    NumberOfBurgers = 1,
                    BurgerSize = BurgerSize.Normal
                }
                );
        }

    }
}
