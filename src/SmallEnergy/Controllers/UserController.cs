using AccesPoint;
using AccesPoint.Inferfaces;
using AccesPoint.Models;
using AccesPoint.Users;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> EditUser([FromForm] int Id)
        {
            var user = await userData.GetUser(Id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember([FromForm] User user)
        {
            await userData.UpdateMember(user);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember([FromForm] int id)
        {
            await userData.DeleteMember(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromForm] User user)
        {
            await userData.CreateUser(user);
            return RedirectToAction("ShowAllUsers");
        }
        public IActionResult CreateUser()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> GetBoxed([FromForm] string input)
        {
            string sql = "EXEC [dbo].[dspGetUmbracoUser] "+input;
            var user = await userData.GetSingleUser(sql);
            return View("EditUser", user);
        }
    }
}
