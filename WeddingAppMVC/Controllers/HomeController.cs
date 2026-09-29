using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeddingAppMVC.Models;
using WeddingAppMVC.Services;

namespace WeddingAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IGuestService _guestService;
        private readonly IWeddingInfoService _weddingInfoService;

        public HomeController(IEventService eventService, IGuestService guestService, IWeddingInfoService weddingInfoService)
        {
            _eventService = eventService;
            _guestService = guestService;
            _weddingInfoService = weddingInfoService;
        }

        public async Task<IActionResult> Index()
        {
            WeddingInfo? info = await _weddingInfoService.GetAsync();
            if (info is null)
                return NotFound();
            return View(info);
        }

        public async Task<IActionResult> Dashboard()
        {
            WeddingInfo? info = await _weddingInfoService.GetAsync();
            if (info is null)
                return NotFound();


            var viewModel = new DashboardViewModel
            {
                Events = await _eventService.GetAllAsync(),
                Statistics = await _guestService.GetStatisticsAsync(),
                WeddingInfo = info
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWeddingInfo([Bind(Prefix = "WeddingInfo")] WeddingInfo input)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DashboardViewModel
                {
                    Events = await _eventService.GetAllAsync(),
                    Statistics = await _guestService.GetStatisticsAsync(),
                    WeddingInfo = input
                };

                return View("Dashboard", viewModel);
            }

            bool updated = await _weddingInfoService.UpdateAsync(input);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Privacy()
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
