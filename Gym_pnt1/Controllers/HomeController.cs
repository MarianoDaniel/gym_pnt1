using Microsoft.AspNetCore.Mvc;

namespace Gym_pnt1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
