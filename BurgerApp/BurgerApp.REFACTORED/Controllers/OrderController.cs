using BurgerApp.SERVICES.Interfaces;
using BurgerApp.VIEWMODELS.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.REFACTORED.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;
        private IBurgerService _burgerService;

        public OrderController(IOrderService orderService, IUserService userService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _userService = userService;
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            List<OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
            return View(orderDetailsViewModels);
        }

        public IActionResult AddOrder()
        {
            ViewBag.Users = _userService.GetUsersForDD();

            OrderViewModel orderViewModel = new();
            return View(orderViewModel);
        }

        public IActionResult AddOrder2(OrderViewModel orderViewModel)
        {

            ViewBag.Burgers = _burgerService.GetBurgersForDD();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult AddOrderPost(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                return View("Error");
            }

            OrderViewModel finalOrderViewModel = _orderService.AddBurgerNamesAndNumberToOrderViewModel(orderViewModel);
            _orderService.AddOrder(finalOrderViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            ViewBag.Users = _userService.GetUsersForDD();
            ViewBag.Burgers = _burgerService.GetBurgersForDD();

            if (id == null || id <= 0)
            {
                return View("ResourceNotFound");
            }

            try
            {
                OrderViewModel orderViewModel = _orderService.GetOrderByIdToViewModel(id.Value);
                return View(orderViewModel);
            }
            catch (Exception ex)
            {
                return View("ResourceNotFound");
            }

        }

        public IActionResult EditOrder2(OrderViewModel orderViewModel)
        {
            ViewBag.Burgers = _burgerService.GetBurgersForDD();

            if (orderViewModel == null)
            {
                return View("ResourceNotFound");
            }
                        
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            OrderViewModel finalOrderViewModel = _orderService.AddBurgerNamesAndNumberToOrderViewModel(orderViewModel);

            if (finalOrderViewModel == null || finalOrderViewModel.NumberOfBurgers < 0)
            {
                return View("ResourceNotFound");
            }

            if (finalOrderViewModel.NumberOfBurgers == 0)
            {
                _orderService.RemoveBurgerOrdersFromViewModel(finalOrderViewModel);
                _orderService.DeleteOrderById(finalOrderViewModel.Id);
                return RedirectToAction("Index");
            } // ??????????????

            //if (orderViewModel.NumberOfBurgers > orderViewModel.BurgerOrders.Count)
            //{
            //    return View("EditOrder2", orderViewModel);
            //}

            _orderService.EditOrder(finalOrderViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            try
            {                
                _orderService.DeleteOrderById(id.Value);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }


    }
}
