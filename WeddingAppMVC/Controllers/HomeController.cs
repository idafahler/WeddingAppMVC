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

        public HomeController(IEventService eventService, IGuestService guestService)
        {
            _eventService = eventService;
            _guestService = guestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            var viewModel = new DashboardViewModel
            {
                Events = await _eventService.GetAllAsync(),
                Statistics = await _guestService.GetStatisticsAsync()
            };

            return View(viewModel);
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
