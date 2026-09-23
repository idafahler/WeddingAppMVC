using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
    }
}