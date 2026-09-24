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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            if (!ModelState.IsValid)
                return View(ev);

            await _service.AddAsync(ev);
            return RedirectToAction("Dashboard", "Home");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Event? ev = await _service.GetByIdAsync(id);
            if (ev is null)
                return NotFound();

            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event ev)
        {
            if (!ModelState.IsValid)
            {
                ev.Id = id;
                return View(ev);
            }

            bool updated = await _service.UpdateAsync(id, ev);
            if (!updated)
                return NotFound();

            return RedirectToAction("Dashboard", "Home");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Event? ev = await _service.GetByIdAsync(id);
            if (ev is null)
                return NotFound();

            return View(ev);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            bool deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return RedirectToAction("Dashboard", "Home");
        }
    }
}
