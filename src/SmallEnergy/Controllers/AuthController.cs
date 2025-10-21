using Microsoft.AspNetCore.Mvc;

namespace SmallEnergy.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
