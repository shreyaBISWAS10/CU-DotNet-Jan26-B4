using Microsoft.AspNetCore.Mvc;
using GlobalMart.Services;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IPricingService _pricingService;

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public IActionResult Index()
        {
            decimal basePrice = 100;
            string promoCode = "WINTER25";

            var finalPrice = _pricingService.CalculatePrice(basePrice, promoCode);

            ViewBag.Price = finalPrice;

            return View();
        }
    }
}