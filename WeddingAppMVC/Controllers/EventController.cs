using Microsoft.AspNetCore.Mvc;
using WeddingAppMVC.Models;
using WeddingAppMVC.Services;

namespace WeddingAppMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _service.GetAllAsync();
            return View(events);
        }
    }
}
