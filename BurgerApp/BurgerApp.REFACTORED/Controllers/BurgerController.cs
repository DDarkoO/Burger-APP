using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.BurgerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.REFACTORED.Controllers
{
    public class BurgerController : Controller
    {
        private IBurgerService _burgerService;

        public BurgerController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            List<BurgerDetailsViewModel> burgerDetailsViewModels = _burgerService.GetAllBurgers();
            return View(burgerDetailsViewModels);
        }

        public IActionResult AddBurger()
        {
            BurgerViewModel burgerViewModel = new();
            return View(burgerViewModel);
        }

        [HttpPost]
        public IActionResult AddBurgerPost(BurgerViewModel burgerViewModel)
        {
            if (burgerViewModel == null)
            {
                return View("Error");
            }

            try
            {
                _burgerService.AddBurger(burgerViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }

        public IActionResult EditBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            return View(_burgerService.GetBurgerById(id.Value));
        }

        [HttpPost]
        public IActionResult EditBurgerPost(BurgerViewModel burgerViewModel)
        {
            if (burgerViewModel == null)
            {
                return View("Error");
            }
            try
            {
                _burgerService.EditBurger(burgerViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult DeleteBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {                
                return View(_burgerService.GetBurgerById(id.Value));
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {
                _burgerService.DeleteBurgerById(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }





    }
}