using BurgerApp.DATA.ACCESS;

using BurgerApp.DOMAIN.Models;
using BurgerApp.MAPPERS;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.BurgerViewModels;


namespace BurgerApp.SERVICES.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;
        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public List<BurgerViewModelDD> GetBurgersForDD()
        {
            return _burgerRepository.GetAll().Select(x => x.ToBurgerViewModelDD()).ToList();
        }

        void IBurgerService.AddBurger(BurgerViewModel burgerViewModel)
        {
            if (burgerViewModel == null)
            {
                throw new ArgumentNullException(nameof(burgerViewModel));
            }

            if(_burgerRepository.GetAll().Any(x => x.Name == burgerViewModel.Name))
            {
                throw new Exception("Burger with that name already exists in our menu!");
            }

            if (burgerViewModel.Price <= 0)
            {
                throw new Exception("Free burgers will have negative impact over our business...");
            }

            try
            {
                _burgerRepository.Add(burgerViewModel.ToBurger());
            }
            catch (Exception e)
            {
                throw new Exception("Error");
            }

        }

        void IBurgerService.DeleteBurgerById(int id)
        {
            if(id <= 0 || id == null)
            {
                throw new Exception("Error");
            }

            Burger burger = _burgerRepository.GetById(id);

            try
            {
                _burgerRepository.DeleteById(burger.Id);
            }
            catch(Exception e)
            {
                throw new Exception("Error");
            }
        }

        void IBurgerService.EditBurger(BurgerViewModel burgerViewModel)
        {
            if(burgerViewModel == null)
            {
                throw new ArgumentNullException(nameof(burgerViewModel));
            }

            int index = _burgerRepository.GetAll().FindIndex(x => x.Id == burgerViewModel.Id);

            if (index == -1)
            {
                throw new Exception("Error");
            }

            _burgerRepository.DeleteById(burgerViewModel.Id);

        }

        List<BurgerDetailsViewModel> IBurgerService.GetAllBurgers()
        {
            return _burgerRepository.GetAll().Select(x => x.ToBurgerDetailsViewModel()).ToList();
        }

        BurgerViewModel IBurgerService.GetBurgerById(int id)
        {
            if(id <= 0 || id == null)
            {
                throw new Exception("Error");
            }

            return _burgerRepository.GetById(id).ToBurgerViewModel();

        }

        
    }
}
