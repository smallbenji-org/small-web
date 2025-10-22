using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AccesPoint.Models;

namespace SmallEnergy.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            LogInViewModel logInViewModel = new LogInViewModel();
            logInViewModel.loggedIn = signInManager.IsSignedIn(User);
            return View(logInViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                LogInViewModel logInViewModel = new LogInViewModel();
                logInViewModel.loggedIn = signInManager.IsSignedIn(User);
                logInViewModel.failedText = "Failed! Make sure password or name is correct.";
                return View("Index", logInViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public class LogInViewModel
        {
            public bool loggedIn = false;
            public string failedText = string.Empty;
        }
    }
}
