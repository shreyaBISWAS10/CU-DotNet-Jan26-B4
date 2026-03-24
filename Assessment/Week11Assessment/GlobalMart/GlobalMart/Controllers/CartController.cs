using Microsoft.AspNetCore.Mvc;
using GlobalMart.Services;

namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _pricingService;

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public IActionResult Checkout()
        {
            decimal total = 200;
            string promoCode = "FREESHIP";

            var finalTotal = _pricingService.CalculatePrice(total, promoCode);

            ViewBag.Total = finalTotal;

            return View();
        }
    }
}