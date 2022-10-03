using BurgerApp.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;


namespace BurgerApp.DATA.ACCESS.EFImplementations
{
    public class UserEFRepository : IRepository<User>
    {
        BurgerAppDbContext _burgerAppDbContext;
        public UserEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }

        public int Add(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _burgerAppDbContext.Users.Add(entity);
            _burgerAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void DeleteById(int id)
        {
            if(id == null || id <= 0)
            {
                throw new Exception("Error");
            }

            var user = _burgerAppDbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _burgerAppDbContext.Users.Remove(user);
            _burgerAppDbContext.SaveChanges();
        }

        public void Edit(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _burgerAppDbContext.Users.Update(entity);
            _burgerAppDbContext.SaveChanges();

        }

        public List<User> GetAll()
        {
            var usersDb = _burgerAppDbContext.Users
                .Include(x => x.Orders)
                .ToList();

            return usersDb;
        }

        public User GetById(int id)
        {
            if(id == null || id <= 0)
            {
                throw new Exception("Error");
            }

            return _burgerAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
