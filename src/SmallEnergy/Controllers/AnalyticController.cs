using AccesPoint.Inferfaces;
using AccesPoint.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmallEnergy.Controllers
{
    [Authorize]
    public class AnalyticController : Controller
    {
        private readonly ISearch searchData;

        public AnalyticController(ISearch searchData)
        {
            this.searchData = searchData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllSearches()
        {
           var searches = await searchData.GetPopularSearchesByDate(100, new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc), DateTime.Now.AddDays(1));
            return View(new { searches = (List<(string, int)>)searches });
        }

        [HttpPost]
        public async Task<IActionResult> FilterDate([FromForm] DateTime fromDate, DateTime toDate)
        {
            var searches = await searchData.GetPopularSearchesByDate(100, fromDate, toDate);
            return View("ShowAllSearches", new { searches = (List<(string, int)>)searches });
        }
    }
}
