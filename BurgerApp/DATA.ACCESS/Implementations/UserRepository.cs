//using BurgerApp.DOMAIN.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BurgerApp.DATA.ACCESS.Implementations
//{
//    public class UserRepository : IRepository<User>
//    {
//        public int Add(User entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException(nameof(entity));
//            }

//            entity.Id = ++StaticDb.UserId;
//            StaticDb.Users.Add(entity);
//            return entity.Id;
//        }

//        public void DeleteById(int id)
//        {
//            if (id == null || id <= 0)
//            {
//                throw new Exception("The user was not found");
//            }

//            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
//            if(user == null)
//            {
//                throw new Exception("The user was not found");
//            }

//            StaticDb.Users.Remove(user);
            
//        }

//        public void Edit(User entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("The user was not found");
//            }

//            int index = StaticDb.Users.FindIndex(x => x.Id == entity.Id);
//            if (index == -1)
//            {
//                throw new Exception("The user was not found");
//            }

//            StaticDb.Users[index] = entity;
//        }

//        public List<User> GetAll()
//        {
//            return StaticDb.Users;
//        }

//        public User GetById(int id)
//        {
//            if(id <= 0 || id == null)
//            {
//                throw new Exception("The user was not found");
//            }

//            return StaticDb.Users.Find(x => x.Id == id);
//        }
//    }
//}
