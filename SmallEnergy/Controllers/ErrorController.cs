using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace SmallEnergy.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("Error");
        }

        [Route("Shared/Error{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.OriginalPath = feature?.OriginalPath;
            ViewBag.OriginalQueryString = feature?.OriginalQueryString;
            ViewBag.StatusCode = statusCode;
            if (statusCode == 404)
                return View($"Error{statusCode}");

            return View("Index");
        }
    }
}
