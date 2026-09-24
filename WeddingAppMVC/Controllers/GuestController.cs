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
        public async Task<IActionResult> Index(string? filter, string? sortBy)
        {
            List<Guest> allGuests = await _service.GetAllAsync();

            var viewModel = new GuestListViewModel
            {
                Guests = await _service.GetFilteredAsync(filter, sortBy),
                Filter = filter,
                SortBy = sortBy,
                TotalGuests = allGuests.Count,
                Attending = allGuests.Count(g => g.HasResponded && g.Attendance),
                NotAttending = allGuests.Count(g => g.HasResponded && !g.Attendance),
                NotAnswered = allGuests.Count(g => !g.HasResponded),
                TotalAttendants = allGuests.Where(g => g.HasResponded && g.Attendance).Sum(g => g.NumberOfAttendants ?? 0)
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guest guest)
        {
            if (!ModelState.IsValid)
                return View();
            await _service.AddAsync(guest);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Rsvp(int id)
        {
            Guest? guest = await _service.GetByIdAsync(id);
            if (guest is null)
                return NotFound();

            return View(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Rsvp(int id, Guest guest)
        {
            if (!ModelState.IsValid)
                return View(guest);

            guest.HasResponded = true;

            bool updated = await _service.UpdateAsync(id, guest);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Confirmation), new { id });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            Guest? guest = await _service.GetByIdAsync(id);
            if (guest is null)
                return NotFound();

            return View(guest);
        }

        public async Task<IActionResult> Details(int id)
        {
            Guest? guest = await _service.GetByIdAsync(id);
            if (guest is null)
                return NotFound();

            return View(guest);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Guest? guest = await _service.GetByIdAsync(id);
            if (guest is null)
                return NotFound();

            return View(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Guest guest)
        {
            if (!ModelState.IsValid)
            {
                Guest existing = await _service.GetByIdAsync(id);
                if (existing is null)
                    return NotFound();

                guest.HasResponded = existing.HasResponded;
                return View(guest);
            }

            bool updated = await _service.UpdateAsync(id, guest);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Guest? guest = await _service.GetByIdAsync(id);
            if (guest is null)
                return NotFound();

            return View(guest);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            bool deleted =await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
