using BurgerApp.DOMAIN.Models;
using BurgerApp.VIEWMODELS.OrderViewModels;


namespace BurgerApp.MAPPERS
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                IsDelivered = order.IsDelivered,
                StoreAddress = order.StoreAddress,
                UserId = order.UserId,
                BurgerNames = order.BurgerOrders.Select(x => x.Burger.Name).ToList(),
                BurgerSizes = order.BurgerOrders.Select(x => x.BurgerSize).ToList(),
                BurgerOrders = order.BurgerOrders.Count > 0 ? order.BurgerOrders : new List<BurgerOrder>(),
                NumberOfBurgers = order.BurgerOrders.Count
            };
        }

        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {

            return new OrderDetailsViewModel
            {
                Id = order.Id,
                StoreAddress = order.StoreAddress,
                IsDelivered = order.IsDelivered,
                PaymentMethod = order.PaymentMethod,
                FullName = order.User.FullName,
                BurgerNames = order.BurgerOrders.Select(x => x.Burger.Name).ToList(),
                DeliveryAddress = order.User.Address,
                Price = order.BurgerOrders.Sum(x => x.Price),
                BurgerPieces = order.BurgerOrders.Select(x => x.NumberOfBurgers).ToList(),
                BurgerOrders = order.BurgerOrders
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                StoreAddress = orderViewModel.StoreAddress,
                IsDelivered = orderViewModel.IsDelivered,
                PaymentMethod = orderViewModel.PaymentMethod,
                UserId = orderViewModel.UserId,
                BurgerOrders = orderViewModel.BurgerOrders                
            };
        }
    }
}
