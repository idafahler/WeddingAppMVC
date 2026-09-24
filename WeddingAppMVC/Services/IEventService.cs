using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task AddAsync(Event ev);
        Task<bool> UpdateAsync(int id, Event input);
        Task<bool> DeleteAsync(int id);
    }
}