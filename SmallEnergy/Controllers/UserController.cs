using AccesPoint;
using AccesPoint.Inferfaces;
using AccesPoint.Models;
using AccesPoint.Users;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;

namespace SmallEnergy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData userData;

        public UserController(IUserData userData)
        {
            this.userData = userData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllUsers()
        {
            var users = await userData.GetUsers();
            return View(users);
        }
    }
}
