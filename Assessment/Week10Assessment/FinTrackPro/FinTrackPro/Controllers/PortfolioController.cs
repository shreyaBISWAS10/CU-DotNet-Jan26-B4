using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<string> assets = new List<string> { "Stock A", "Stock B" };

        public IActionResult Index()
        {
            ViewData["Total"] = 1000.0;
            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            return Content("Asset Details ID: " + id);
        }

        public IActionResult Delete(int id)
        {
            TempData["Message"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
