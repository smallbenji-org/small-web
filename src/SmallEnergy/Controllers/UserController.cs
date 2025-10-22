using AccesPoint;
using AccesPoint.Inferfaces;
using AccesPoint.Models;
using AccesPoint.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;
using System.Threading.Tasks;

namespace SmallEnergy.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserData userData;
        private readonly ISearch searchData;
        private readonly UserManager<User> userManager;

        public UserController(IUserData userData, ISearch searchData, UserManager<User> userManager)
        {
            this.userData = userData;
            this.searchData = searchData;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await userData.GetUser(id);
            return View(user);
        }

        public async Task<IActionResult> ShowAllUsers()
        {
            var searches = await searchData.GetPopularSearches(5);
            var users = await userData.GetUsers(10);
            return View(new {users = users, searches = (List<string>)searches });
        }

        public async Task<IActionResult> EditUser(int id)
        {
            var user = await userData.GetUser(id);
            return View(user);
        }

        public async Task<IActionResult> Avatar(int id)
        {
            var user = await userData.GetUser(id);
            if (user?.avatarBinary == null || user.avatarBinary.Length == 0)
                return File("~/images/default-avatar.png", "image/png");

            string contentType = "image/jpeg"; 
            
            // Check for PNG signature (89 50 4E 47)
            if (user.avatarBinary.Length > 4 && 
                user.avatarBinary[0] == 0x89 && 
                user.avatarBinary[1] == 0x50 && 
                user.avatarBinary[2] == 0x4E && 
                user.avatarBinary[3] == 0x47)
            {
                contentType = "image/png";
            }
            // Check for JPEG signature (FF D8 FF)
            else if (user.avatarBinary.Length > 3 && 
                     user.avatarBinary[0] == 0xFF && 
                     user.avatarBinary[1] == 0xD8 && 
                     user.avatarBinary[2] == 0xFF)
            {
                contentType = "image/jpeg";
            }
            // Check for GIF signature (47 49 46)
            else if (user.avatarBinary.Length > 3 && 
                     user.avatarBinary[0] == 0x47 && 
                     user.avatarBinary[1] == 0x49 && 
                     user.avatarBinary[2] == 0x46)
            {
                contentType = "image/gif";
            }

            return File(user.avatarBinary, contentType);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember([FromForm] User user, IFormFile avatarFile)
        {
            if (avatarFile != null && avatarFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await avatarFile.CopyToAsync(ms);
                user.avatarBinary = ms.ToArray();
            }
            else
            {
                var existingUser = await userData.GetUser(user.Id);
                if (existingUser?.avatarBinary != null)
                {
                    user.avatarBinary = existingUser.avatarBinary;
                }
            }
           
            await userData.UpdateMember(user);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember([FromForm] int id)
        {
            await userData.DeleteMember(id);
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromForm] User user)
        {
            user.userPassword = userManager.PasswordHasher.HashPassword(user, user.userPassword);
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
            var users = await userData.GetUsers(10);
            var searches = await searchData.GetPopularSearches(5);
            if (input != null) 
            {
                users = users.Where(x => x.userName.ToLower().Contains(input.ToLower())).ToList();
                searchData.AddSearch(input);
            }
            return View("ShowAllUsers", new { users = users, searches = (List<string>)searches });
        }
    }
}
