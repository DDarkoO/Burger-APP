using BurgerApp.DOMAIN.Models;

namespace BurgerApp.DATA.ACCESS
{
    public interface IOrderRepository : IRepository<Order>
    {
        public double GetAverageOrderPrice();
    }
}
