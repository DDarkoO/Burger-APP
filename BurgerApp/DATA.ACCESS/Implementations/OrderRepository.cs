//using BurgerApp.DOMAIN.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BurgerApp.DATA.ACCESS.Implementations
//{
//    public class OrderRepository : IRepository<Order>
//    {
//        public int Add(Order entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity));
//            }

//            entity.Id = ++StaticDb.OrderId;
//            StaticDb.Orders.Add(entity);
//            return entity.Id;
//        }

//        public void DeleteById(int id)
//        {
//            if (id == null || id <= 0)
//            {
//                throw new Exception("The order was not found");
//            }

//            Order order = StaticDb.Orders.Find(x => x.Id == id);

//            if (order == null)
//            {
//                throw new Exception("The order was not found");
//            }

//            StaticDb.Orders.Remove(order);
//        }

//        public void Edit(Order entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("The order was not found");
//            }

//            int index = StaticDb.Orders.FindIndex(x => x.Id == entity.Id);

//            User user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.UserId);
//            entity.User = user;

//            if(index == -1)
//            {
//                throw new Exception("The order was not found");
//            }

//            StaticDb.Orders[index] = entity;

//        }

//        public List<Order> GetAll()
//        {
//            return StaticDb.Orders;
//        }

//        public Order GetById(int id)
//        {
//            if (id == null || id <= 0)
//            {
//                throw new Exception("The order was not found");
//            }

//            return StaticDb.Orders.Find(x => x.Id == id);             
//        }

        
//    }
//}
