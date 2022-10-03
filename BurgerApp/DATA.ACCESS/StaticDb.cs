using BurgerApp.DOMAIN.Enums;
using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA.ACCESS
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int UserId { get; set; }
        public static int BurgerOrderId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<User> Users { get; set; }
        public static List<Order> Orders { get; set; }

        static StaticDb()
        {
            BurgerId = 5;
            OrderId = 5;
            BurgerOrderId = 7;
            UserId = 5;

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FullName = "Michael Jordan",
                    Address = "Bulls Arena",
                    Orders = new List<Order>
                    {

                    }
                },

                new User
                {
                    Id = 2,
                    FullName = "Charles Leclerc",
                    Address = "Maranelo PitStop 1",
                    Orders = new List<Order>
                    {

                    }
                },

                new User
                {
                    Id = 3,
                    FullName = "Ricardo Kaka",
                    Address = "San Siro trophy room",
                    Orders = new List<Order>
                    {

                    }
                },

                new User
                {
                    Id = 4,
                    FullName = "Paolo Maldini",
                    Address = "San Siro Stands",
                    Orders = new List<Order>
                    {

                    }
                },

                new User
                {
                    Id = 5,
                    FullName = "Harry Kane",
                    Address = "Tottenham Hotspur Stadium",
                    Orders = new List<Order>
                    {

                    }
                }
            };

            Burgers = new List<Burger>
            {
                new Burger
                {
                    Id = 1,
                    Name = "Hamburger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 200,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 180,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger
                {
                    Id = 3,
                    Name = "Greenburger",
                    IsVegetarian = true,
                    IsVegan = true,
                    HasFries = false,
                    Price = 190,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger
                {
                    Id = 4,
                    Name = "Fitburger",
                    IsVegetarian = true,
                    IsVegan = true,
                    HasFries = false,
                    Price = 220,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                },

                new Burger
                {
                    Id = 5,
                    Name = "Happy Burger",
                    IsVegetarian = false,
                    IsVegan = false,
                    HasFries = true,
                    Price = 250,
                    BurgerOrders = new List<BurgerOrder>
                    {

                    }
                }
            };

            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    StoreAddress = StoreAddress.Sedmica_Aerodrom,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    User = Users[0],
                    UserId = Users[0].Id,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 1,
                            Burger = Burgers[Burgers.Count - 1],
                            BurgerId = Burgers[Burgers.Count -1].Id,
                            NumberOfBurgers = 2,
                            BurgerSize = BurgerSize.Double,
                            OrderId = 1
                        }
                    }

                },

                new Order
                {
                    Id = 2,
                    StoreAddress = StoreAddress.Sedmica_Centar,
                    IsDelivered = true,
                    PaymentMethod = PaymentMethod.Cash,
                    User = Users[1],
                    UserId = Users[1].Id,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[3],
                            BurgerId = Burgers[3].Id,
                            NumberOfBurgers = 1,
                            BurgerSize = BurgerSize.Normal,
                            OrderId = 2
                        }
                    }
                },

                new Order
                {
                    Id = 3,
                    StoreAddress = StoreAddress.Royal_Aerodrom,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    User = Users[2],
                    UserId = Users[2].Id,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 3,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            NumberOfBurgers = 3,
                            BurgerSize = BurgerSize.Double,
                            OrderId = 3
                        }
                    }
                },

                new Order
                {
                    Id = 4,
                    StoreAddress = StoreAddress.Royal_Debar_Maalo,
                    IsDelivered = false,
                    PaymentMethod = PaymentMethod.Card,
                    User = Users[3],
                    UserId = Users[3].Id,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 4,
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            NumberOfBurgers = 2,
                            BurgerSize = BurgerSize.Normal,
                            OrderId = 4
                        },

                        new BurgerOrder
                        {
                            Id = 5,
                            Burger = Burgers.First(x => x.Id == 3),
                            BurgerId = Burgers.First(x => x.Id == 3).Id,
                            NumberOfBurgers = 1,
                            BurgerSize = BurgerSize.Double,
                            OrderId = 4
                        }
                    }
                },

                new Order
                {
                    Id = 5,
                    StoreAddress = StoreAddress.Baking_Bread,
                    IsDelivered = true,
                    PaymentMethod = PaymentMethod.Cash,
                    User = Users[4],
                    UserId = Users[4].Id,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 6,
                            Burger = Burgers[2],
                            BurgerId = Burgers[2].Id,
                            NumberOfBurgers = 4,
                            BurgerSize = BurgerSize.Double,
                            OrderId = 5
                        },

                        new BurgerOrder
                        {
                            Id = 7,
                            Burger = Burgers.First(x => x.Id == 4),
                            BurgerId = Burgers.First(x => x.Id == 4).Id,
                            NumberOfBurgers = 1,
                            BurgerSize = BurgerSize.Normal,
                            OrderId = 5
                        }
                    }
                },
            };
        }



        
    }
}
