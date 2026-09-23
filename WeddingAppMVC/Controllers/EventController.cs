using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
