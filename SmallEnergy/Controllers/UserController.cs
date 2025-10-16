using AccesPoint;
using AccesPoint.Inferfaces;
using AccesPoint.Models;
using AccesPoint.Users;
using EmilsAuto.Helper;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;

namespace SmallEnergy.Controllers
{
    public class UserController : Controller
    {
        private readonly IDbHandler dbHandler;
        private readonly IUserData userData;

        public UserController(IDbHandler dbHandler, IUserData userData)
        {
            this.dbHandler = dbHandler;
            this.userData = userData;

        public UserController(IDbHandler dbHandler)
        {
            this.dbHandler = dbHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllUsers()
        {
            var users = await userData.GetUsers();
            return View(users);

        public IActionResult ShowAllUsers()
        {
            //IDataReader reader = dbHandler.ExecuteReader("SELECT * FROM public.\"vGetAllUsers\" LIMIT 50");
            //DataTable tb = new DataTable();
            //tb.Load(reader);
            //
            //AllUsers users = new AllUsers();
            //
            //int rows = tb.Rows.Count;

            return View();
        }
    }
}
