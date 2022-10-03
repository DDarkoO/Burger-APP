using BurgerApp.DOMAIN.Models;
using BurgerApp.VIEWMODELS.BurgerViewModels;


namespace BurgerApp.MAPPERS
{
    public static class BurgerMapper
    {
        public static BurgerViewModelDD ToBurgerViewModelDD(this Burger burger)
        {
            return new BurgerViewModelDD
            {
                Id = burger.Id,
                Name = burger.Name
            };
        }

        public static BurgerDetailsViewModel ToBurgerDetailsViewModel(this Burger burger)
        {
            return new BurgerDetailsViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
                Price = burger.Price,
                BurgerOrders = burger.BurgerOrders
            };
        }

        public static BurgerViewModel ToBurgerViewModel(this Burger burger)
        {
            return new BurgerViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
                Price = burger.Price,
                BurgerOrders = burger.BurgerOrders
            };
        }

        public static Burger ToBurger(this BurgerViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.Name,
                IsVegan = burgerViewModel.IsVegan,
                IsVegetarian = burgerViewModel.IsVegetarian,
                Price = burgerViewModel.Price,
                BurgerOrders = burgerViewModel.BurgerOrders,
                HasFries = burgerViewModel.HasFries
            };
        }
    }
}
