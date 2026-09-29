using WeddingAppMVC.Models;

namespace WeddingAppMVC.Services
{
    public interface IWeddingInfoService
    {
        Task<WeddingInfo?> GetAsync();
        Task<bool> UpdateAsync(WeddingInfo input);
    }
}