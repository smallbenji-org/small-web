using AccesPoint.Inferfaces;
using AccesPoint.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallEnergy.Interfaces;
using SmallEnergy.Models;

namespace SmallEnergy.Controllers
{
    [Authorize]
    public class AnalyticController : Controller
    {
        private readonly ISearch searchData;
        private readonly IPagination paginationHelper;

        public AnalyticController(ISearch searchData, IPagination paginationHelper)
        {
            this.searchData = searchData;
            this.paginationHelper = paginationHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllSearches(int? id, string filter = "", DateTime fromDate = default, DateTime toDate = default)
        {
            AnalyticViewModel viewModel = new AnalyticViewModel();
            // Her tilføjer til standard værdier til datoerne.
            if (fromDate == default)
                fromDate = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            if (toDate == default)
                toDate = DateTime.UtcNow.AddDays(1);
            viewModel.toDate = toDate;
            viewModel.fromDate = fromDate;

            // Her henter jeg searches listen ud fra fromDate og toDate
            var searches = await searchData.GetPopularSearchesByDate(100, viewModel.fromDate, viewModel.toDate);
            viewModel.Searches = (List<(string, int)>)searches;

            // Her sætter jeg søge filteret på hvis det er udfyldt.
            if (!string.IsNullOrEmpty(filter))
            {
                viewModel.filter = filter;
                viewModel.Searches = viewModel.Searches.Where(x => x.Item1.ToLower().Contains(viewModel.filter.ToLower())).ToList();
                searchData.AddSearch(viewModel.filter);
            }

            // Her udregner jeg sidernes pagination.
            viewModel.Pagination.maxPages = paginationHelper.getMaxPages(viewModel.Searches.Count(), 10);
            if (id == null || id > viewModel.Pagination.maxPages || id < 1) { id = 1; }
            viewModel.Pagination.CurrentPage = (int)id;
            viewModel.Searches = paginationHelper.GetPage(10, viewModel.Pagination.CurrentPage, viewModel.Searches.ToList());

            return View(viewModel);
        }
    }
}
