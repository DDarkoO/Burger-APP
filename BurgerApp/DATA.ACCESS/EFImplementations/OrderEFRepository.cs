using BurgerApp.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BurgerApp.DATA.ACCESS.EFImplementations
{
    public class OrderEFRepository : IOrderRepository
    {
        private BurgerAppDbContext _burgerAppDbContext;

        public OrderEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }

        public int Add(Order entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _burgerAppDbContext.Orders.Add(entity);
            _burgerAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void DeleteById(int id)
        {
            var order = _burgerAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                throw new Exception("Error");
            }

            _burgerAppDbContext.Orders.Remove(order);
            _burgerAppDbContext.SaveChanges();
        }

        public void Edit(Order entity)
        {
            _burgerAppDbContext.Orders.Update(entity); // ??
            _burgerAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            var ordersDb = _burgerAppDbContext.Orders
                .Include(x => x.BurgerOrders)
                .ThenInclude(x => x.Burger)
                .Include(x => x.User)
                .ToList();

            return ordersDb;

        }

        public Order GetById(int id)
        {
            if (id == null)
            {
                throw new Exception("Error");
            }

            var order = _burgerAppDbContext.Orders //Ako e Order order podvlekuva za mozhna greshka, so var ne. Zoshto?
                .Include(x => x.BurgerOrders)
                .ThenInclude(x => x.Burger)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new Exception("Error");
            }
            return order;
        }

        public double GetAverageOrderPrice()
        {
            var burgerOrdersDb = _burgerAppDbContext.Orders
                .Include(x => x.BurgerOrders)
                .ThenInclude(x => x.Burger)
                .Include(x => x.User)
                .SelectMany(x => x.BurgerOrders)
                .GroupBy(x => x.OrderId); // ?????

            //var groupBurgerOrdersByOrderId =
            //    from order in _burgerAppDbContext.Orders
            //    join burgerorder in _burgerAppDbContext.BurgerOrders //za da go koristam tuka BurgerOrders mi bara da bide del od glavnite entiteti vo DbContext bazata. Koga kje go dodadam (ne sum siguren kako treba da se napishe kodot vo base.OMC (modelBuilder.Entity<BurgerOrder>() --> koj kod i kako treba dojde ovde, vo delot so HasOne, HasMany itn itn? <--)) mi dava greshka pri povikuvanje na metodot GetAll(), t.e. mi dava null exception povrzan so BurgerOrders, vika deka e null... 
            //        on order.Id equals burgerorder.OrderId
            //    join burger in _burgerAppDbContext.Burgers
            //        on burgerorder.BurgerId equals burger.Id
            //    join user in _burgerAppDbContext.Users
            //        on order.UserId equals user.Id
            //    group burgerorder by burgerorder.OrderId into newGroup
            //    select newGroup; 

            int[] orderPrices = new int[_burgerAppDbContext.Orders.Count()];
            int counter = 0;

            foreach (var order in _burgerAppDbContext.Orders)
            {
                int sumOfBurgerOrders = 0;

                for(int i = 0; i < order.BurgerOrders.Count(); i++)
                {
                    sumOfBurgerOrders += (int)order.BurgerOrders[i].Price;
                }

                orderPrices[counter] = sumOfBurgerOrders;
                counter++;                
            }

            double averagePrice = (double)orderPrices.Average();
            return averagePrice;


            //var allOrders = _burgerAppDbContext.Orders;
            //var allBurgerOrders = allOrders.SelectMany(x => x.BurgerOrders).ToList();
            //double avg = (allBurgerOrders.Sum(x => x.Burger.Price)) / allBurgerOrders.Count();
            //return avg;
            

            


            //double averagePrice = 1; //(decimal)burgerOrdersDb.Select(x => x.Price).Average();
            //return averagePrice;

            //double averagePrice = burgerOrdersDb.Average();
            //return averagePrice;
        }
    }
}
