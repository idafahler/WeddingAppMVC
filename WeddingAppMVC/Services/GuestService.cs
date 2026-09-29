using Microsoft.EntityFrameworkCore;
using WeddingAppMVC.Data;
using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public class GuestService : IGuestService
    {
        private readonly ApplicationDbContext _context;
        public GuestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guest>> GetAllAsync() =>
            await _context.Guests.ToListAsync();


        public async Task<Guest?> GetByIdAsync(int id) =>
            await _context.Guests.FindAsync(id);



        public async Task AddAsync(Guest guest)
        {
            guest.RegistrationDate = DateTime.Now;
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Guest input)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest is null)
                return false;

            guest.FirstName = input.FirstName;
            guest.LastName = input.LastName;
            guest.Email = input.Email;
            guest.PhoneNumber = input.PhoneNumber;
            guest.Attendance = input.Attendance;
            guest.NumberOfAttendants = input.NumberOfAttendants;
            guest.Message = input.Message;

            if (input.HasResponded)
                guest.HasResponded = true;

            if (!input.Attendance)
                guest.NumberOfAttendants = null;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest is null)
                return false;

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Guest>> GetFilteredAsync(string? filter, string? sortBy, string? search)
        {
            IQueryable<Guest> query = _context.Guests;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                query = query.Where(g => (g.FirstName + " " + g.LastName).Contains(search));
            }

            query = filter switch
            {
                "attending" => query.Where(g => g.HasResponded && g.Attendance),
                "notattending" => query.Where(g => g.HasResponded && !g.Attendance),
                "notanswered" => query.Where(g => !g.HasResponded),
                _ => query
            };

            query = sortBy switch
            {
                "name_desc" => query.OrderByDescending(g => g.FirstName).ThenByDescending(g => g.LastName),
                "status" => query.OrderByDescending(g => g.HasResponded).ThenByDescending(g => g.Attendance),
                "status_desc" => query.OrderBy(g => g.HasResponded).ThenBy(g => g.Attendance),
                "date" => query.OrderBy(g => g.RegistrationDate),
                "date_desc" => query.OrderByDescending(g => g.RegistrationDate),
                _ => query.OrderBy(g => g.FirstName).ThenBy(g => g.LastName)
            };

            return await query.ToListAsync();
        }

        public async Task<GuestStatistics> GetStatisticsAsync()
        {
            var guests = await _context.Guests.ToListAsync();

            return new GuestStatistics
            {
                TotalGuests = guests.Count,
                Attending = guests.Count(g => g.HasResponded && g.Attendance),
                NotAttending = guests.Count(g => g.HasResponded && !g.Attendance),
                NotAnswered = guests.Count(g => !g.HasResponded),
                TotalAttendants = guests.Where(g => g.HasResponded && g.Attendance)
                                .Sum(g => g.NumberOfAttendants ?? 0)
            };
        }
    }
}
