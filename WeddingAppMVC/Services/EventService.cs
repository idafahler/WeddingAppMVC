using Microsoft.EntityFrameworkCore;
using WeddingAppMVC.Data;
using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllAsync() =>
            await _context.Events.OrderBy(e => e.StartTime).ToListAsync();

        public async Task<Event?> GetByIdAsync(int id) =>
            await _context.Events.FindAsync(id);

        public async Task AddAsync(Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Event input)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev is null)
                return false;

            ev.Title = input.Title;
            ev.StartTime = input.StartTime;
            ev.EndTime = input.EndTime;
            ev.Location = input.Location;
            ev.Address = input.Address;
            ev.Description = input.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev is null)
                return false;

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
