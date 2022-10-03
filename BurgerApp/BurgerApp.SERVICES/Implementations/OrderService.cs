using BurgerApp.DATA.ACCESS;
using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.OrderViewModels;

namespace BurgerApp.SERVICES.Implementations
{
    public class OrderService : IOrderService
    {

        private IOrderRepository _orderRepository;
        private IRepository<Burger> _burgerRepository;
        private IRepository<User> _userRepository;

        public OrderService(IOrderRepository orderRepository, IRepository<Burger> burgerRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
            _userRepository = userRepository;
        }


        public void AddOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new ArgumentNullException(nameof(orderViewModel));
            }
            User user = _userRepository.GetById(orderViewModel.UserId);

            Order order = orderViewModel.ToOrder();
            order.User = user;

            _orderRepository.Add(order);

        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new ArgumentNullException(nameof(orderViewModel));
            }

            Order order = orderViewModel.ToOrder();
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderRepository.Edit(order);
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<OrderDetailsViewModel> orderDetailsViewModels = _orderRepository.GetAll().Select(x => x.ToOrderDetailsViewModel()).ToList();
            return orderDetailsViewModels;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            if (id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }

            return _orderRepository.GetById(id).ToOrderDetailsViewModel();

        }



        public OrderViewModel AddBurgerNamesAndNumberToOrderViewModel(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new Exception("OrderViewModel is faulty!");
            }

            for (int i = 0; i < orderViewModel.BurgerNames.Count; i++)
            {
                BurgerOrder burgerOrder = new BurgerOrder()
                {
                    BurgerId = _burgerRepository.GetAll().FirstOrDefault(x => x.Name == orderViewModel.BurgerNames[i]).Id,
                    Burger = _burgerRepository.GetById(_burgerRepository.GetAll().FirstOrDefault(x => x.Name == orderViewModel.BurgerNames[i]).Id),
                    BurgerSize = orderViewModel.BurgerSizes[i],
                    NumberOfBurgers = 1
                };
                orderViewModel.BurgerOrders.Add(burgerOrder);
            }

            return orderViewModel;
        }

        OrderViewModel IOrderService.GetOrderByIdToViewModel(int id)
        {
            if (id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }

            return _orderRepository.GetById(id).ToOrderViewModel();

        }

        OrderViewModel IOrderService.RemoveBurgerOrdersFromViewModel(OrderViewModel orderViewModel)
        {
            orderViewModel.BurgerOrders.RemoveRange(
                orderViewModel.NumberOfBurgers, orderViewModel.BurgerOrders.Count - orderViewModel.NumberOfBurgers);
            return orderViewModel;
        }

        void IOrderService.DeleteOrderById(int id)
        {
            if (id == 0 || id <= 0)
            {
                throw new Exception("Order was not found");
            }
            Order order = _orderRepository.GetById(id);
            if (order == null)
            {
                throw new Exception("The order was not found");
            }

            _orderRepository.DeleteById(id);
        }

        string IOrderService.GetMostPopularBurger()
        {
            var ordersDb = _orderRepository.GetAll();
            var burgerOrders = ordersDb.SelectMany(x => x.BurgerOrders).ToList();

            return burgerOrders.GroupBy(x => x.Burger.Id)
                .OrderByDescending(x => x.Count())
                .First()
                .Select(x => x.Burger.Name)
                .First();
        }

        int IOrderService.GetOrdersDone()
        {
            return _orderRepository.GetAll().Where(x => x.IsDelivered == true).ToList().Count();
        }

        double IOrderService.AverageOrderPrice()
        {
            return _orderRepository.GetAverageOrderPrice();
        }
    }

}
