using Microsoft.AspNetCore.Mvc;

namespace FintechPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MarketStatus = "Open";
            ViewData["TopGainer"] = "Tesla";
            ViewData["Volume"] = 1200000;
            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker,int? days)
        {
            int period = days ?? 30;
            ViewBag.Ticker = ticker;
            ViewBag.Days = period;
            return View();
        }
    }
}
