using Microsoft.AspNetCore.Mvc;
using WeddingAppMVC.Models;
using WeddingAppMVC.Services;

namespace WeddingAppMVC.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestService _service;
        public GuestController(IGuestService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var guests = await _service.GetAllAsync();
            return View(guests);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rsvp(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _service.AddAsync(guest);
            return RedirectToAction("Confirmation");
        }
    }
}
