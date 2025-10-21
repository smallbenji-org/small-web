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
        private readonly ISearch searchData;

        public UserController(IUserData userData, ISearch searchData)
        {
            this.userData = userData;
            this.searchData = searchData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllUsers()
        {
            var searches = searchData.GetPopularSearches(5);
            var users = await userData.GetUsers();
            return View(new {users = users, searches = (List<string>)searches.Result });
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
            return View("Index");
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

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string input)
        {
            var users = await userData.GetUsers();
            if (input != null) 
            {
                users = users.Where(x => x.userName.ToLower().Contains(input.ToLower())).ToList();
                searchData.AddSearch(input);
            }         
            return View("ShowAllUsers", users);
        }
    }
}
