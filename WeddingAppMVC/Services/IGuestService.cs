using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public interface IGuestService
    {
        Task AddAsync(Guest guest);
        Task<bool> DeleteAsync(int id);
        Task<List<Guest>> GetAllAsync();
        Task<Guest?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Guest input);
        Task<List<Guest>> GetFilteredAsync(string? filter, string? sortBy);
        Task<GuestStatistics> GetStatisticsAsync();
    }
}