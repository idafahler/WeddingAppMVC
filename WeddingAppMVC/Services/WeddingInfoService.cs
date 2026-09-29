using Microsoft.EntityFrameworkCore;
using WeddingAppMVC.Data;
using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public class WeddingInfoService : IWeddingInfoService
    {
        private readonly ApplicationDbContext _context;
        public WeddingInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WeddingInfo?> GetAsync() =>
            await _context.WeddingInfos.FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(WeddingInfo input)
        {
            var info = await _context.WeddingInfos.FirstOrDefaultAsync();
            if (info is null)
                return false;

            info.Title = input.Title;
            info.WelcomeMessage = input.WelcomeMessage;
            info.Description = input.Description;
            info.Contact = input.Contact;
            info.WebsiteDescription = input.WebsiteDescription;
            info.ClosingMessage = input.ClosingMessage;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
