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
            await _context.Events.ToListAsync();

        public async Task<Event?> GetByIdAsync(int id) =>
            await _context.Events.FindAsync(id);
    }
}
