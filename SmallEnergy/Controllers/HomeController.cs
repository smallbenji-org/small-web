using AccesPoint;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Models;
using System.Data;
using System.Diagnostics;

namespace SmallEnergy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IDbHandler dbHandler;

        public HomeController(ILogger<HomeController> logger, IDbHandler dbHandler)
        {
            this.logger = logger;
            this.dbHandler = dbHandler;
        }

        public IActionResult Index()
        {
            IDataReader reader = dbHandler.ExecuteReader("SELECT * FROM public.\"vGetAllUsers\" LIMIT 50");
            DataTable tb = new DataTable();
            tb.Load(reader);

            int rows = tb.Rows.Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
