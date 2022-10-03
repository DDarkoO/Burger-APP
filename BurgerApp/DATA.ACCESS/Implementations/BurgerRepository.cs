//using BurgerApp.DOMAIN.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BurgerApp.DATA.ACCESS.Implementations
//{
//    public class BurgerRepository : IRepository<Burger>
//    {
//        public int Add(Burger entity)
//        {
//            if(entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity));
//            }
//            entity.BurgerOrders = new List<BurgerOrder>();
//            entity.Id = ++StaticDb.BurgerId;
//            StaticDb.Burgers.Add(entity);
//            return entity.Id;

//        }

//        public void DeleteById(int id)
//        {
//            if(id == null || id <= 0)
//            {
//                throw new Exception("Burger Not found");
//            }

//            int index = StaticDb.Burgers.FindIndex(x => x.Id == id);

//            if (index == -1)
//            {
//                throw new Exception("Burger not found"); 
//            }

//            Burger burger = StaticDb.Burgers[index];
//            if (burger == null)
//            {
//                throw new Exception("Burger not found");
//            }

//            StaticDb.Burgers.RemoveAt(index);

//        }

//        public void Edit(Burger entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity));
//            }

//            int index = StaticDb.Burgers.FindIndex(x => x.Id == entity.Id);

//            if (index == -1)
//            {
//                throw new Exception(" Burger not found");
//            }

//            StaticDb.Burgers[index] = entity;

//        }

//        public List<Burger> GetAll()
//        {
//            return StaticDb.Burgers;
//        }

//        public Burger GetById(int id)
//        {
//            if (id == null || id <= 0)
//            {
//                throw new Exception("Burger not found");
//            }

//            try
//            {
//                return StaticDb.Burgers.Find(x => x.Id == id);
//            }
//            catch (Exception e)
//            {
//                throw new Exception($"{e}");
//            }

//        }
//    }
//}
