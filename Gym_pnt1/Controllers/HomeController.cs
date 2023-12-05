using Microsoft.AspNetCore.Mvc;

namespace Gym_pnt1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            bool UserExists = !string.IsNullOrEmpty(HttpContext.Session.GetString("username"));
            if (!UserExists)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }
}
