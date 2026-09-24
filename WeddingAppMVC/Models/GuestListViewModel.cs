namespace WeddingAppMVC.Models
{
    public class GuestListViewModel
    {
        public List<Guest> Guests { get; set; } = new();
        public string? Filter { get; set; }
        public string? SortBy { get; set; }

        public GuestStatistics Statistics { get; set; } = new();
    }
}
