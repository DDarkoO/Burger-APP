using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.REFACTORED.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
