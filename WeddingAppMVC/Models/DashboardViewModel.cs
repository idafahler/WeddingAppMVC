namespace WeddingAppMVC.Models
{
    public class DashboardViewModel
    {
        public List<Event> Events { get; set; } = new();
        public GuestStatistics Statistics { get; set; } = new();
    }
}
