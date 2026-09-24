namespace WeddingAppMVC.Models
{
    public class GuestListViewModel
    {
        public List<Guest> Guests { get; set; } = new();
        public string? Filter { get; set; }
        public string? SortBy { get; set; }

        public int TotalGuests { get; set; }
        public int Attending { get; set; }
        public int NotAttending { get; set; }
        public int NotAnswered { get; set; }
        public int TotalAttendants { get; set; }
    }
}
