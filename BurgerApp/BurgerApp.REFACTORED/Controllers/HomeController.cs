using BurgerApp.REFACTORED.Models;
using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurgerApp.REFACTORED.Controllers
{
    public class HomeController : Controller
    {
        
        private IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        public IActionResult Index()
        {
            try
            {
                HomeViewModel homeViewModel = new HomeViewModel();

                homeViewModel.MostPopularBurger = _orderService.GetMostPopularBurger();
                homeViewModel.OrdersDone = _orderService.GetOrdersDone();
                homeViewModel.AverageOrderPrice = _orderService.AverageOrderPrice();

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                return View("ResourceNotFound",ex);
            }
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}