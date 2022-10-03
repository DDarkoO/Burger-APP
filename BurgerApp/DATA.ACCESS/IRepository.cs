using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA.ACCESS
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        int Add(T entity);
        void Edit(T entity);
        void DeleteById(int id);
    }
}
