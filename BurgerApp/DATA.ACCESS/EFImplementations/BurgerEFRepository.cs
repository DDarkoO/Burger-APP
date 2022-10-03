using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA.ACCESS.EFImplementations
{
    public class BurgerEFRepository : IRepository<Burger>
    {
        private BurgerAppDbContext _burgerAppDbContext;
        public BurgerEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }

        public int Add(Burger entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _burgerAppDbContext.Burgers.Add(entity);
            _burgerAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void DeleteById(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var burger = _burgerAppDbContext.Burgers.FirstOrDefault(x => x.Id == id);
            if(burger == null)
            {
                throw new ArgumentNullException(nameof(burger));
            }

            _burgerAppDbContext.Burgers.Remove(burger);
            _burgerAppDbContext.SaveChanges();

        }

        public void Edit(Burger entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _burgerAppDbContext.Burgers.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Burger> GetAll()
        {
            return _burgerAppDbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            var burger = _burgerAppDbContext.Burgers.FirstOrDefault(x => x.Id == id);

            if(burger == null)
            {
                throw new ArgumentNullException(nameof(burger));
            }

            return burger;
        }
    }
}
