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
    }
}
