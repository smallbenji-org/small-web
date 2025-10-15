using AccesPoint;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;

namespace SmallEnergy.Controllers
{
    public class UserController : Controller
    {
        private readonly IDbHandler dbHandler;

        public UserController(IDbHandler dbHandler)
        {
            this.dbHandler = dbHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAllUsers()
        {
            IDataReader reader = dbHandler.ExecuteReader("SELECT * FROM public.\"vGetAllUsers\" LIMIT 50");
            DataTable tb = new DataTable();
            tb.Load(reader);
            
            AllUsers users = new AllUsers();

            int rows = tb.Rows.Count;

            return View();
        }
    }
}
