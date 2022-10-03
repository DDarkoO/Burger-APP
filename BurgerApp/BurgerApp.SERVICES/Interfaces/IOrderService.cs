using BurgerApp.VIEWMODELS.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderById(int id);
        OrderViewModel GetOrderByIdToViewModel(int id);
        void AddOrder(OrderViewModel orderViewModel);
        void EditOrder(OrderViewModel orderViewModel);
        void DeleteOrderById(int id);
        OrderViewModel AddBurgerNamesAndNumberToOrderViewModel(OrderViewModel orderViewModel);
        OrderViewModel RemoveBurgerOrdersFromViewModel(OrderViewModel orderViewModel);
        string GetMostPopularBurger();
        int GetOrdersDone();
        double AverageOrderPrice();
    }
}
