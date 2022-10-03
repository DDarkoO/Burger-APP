using BurgerApp.VIEWMODELS.BurgerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.SERVICES.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerViewModelDD> GetBurgersForDD();
        List<BurgerDetailsViewModel> GetAllBurgers();
        BurgerViewModel GetBurgerById(int id);
        void AddBurger(BurgerViewModel burgerViewModel);
        void EditBurger(BurgerViewModel burgerViewModel);
        void DeleteBurgerById(int id);

        
        
    }
}
