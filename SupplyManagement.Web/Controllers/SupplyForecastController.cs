using Microsoft.AspNetCore.Mvc;
using ISupplyForecastService.Web.Services.Interfaces;

namespace ISupplyForecastController.Web.Controllers
{
    public class SupplyForecastController : Controller
    {
        private readonly ISupplyForecastServices _service;

        public SupplyForecastController(ISupplyForecastServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> SupplyForecastIndex()
        {
            var products = await _service.Find();
            return View(products);
            // return View();
        }
    }
}