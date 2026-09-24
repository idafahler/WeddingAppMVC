using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WeddingAppMVC.Models
{
    public class Event
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Must be between 2-150 characters")]
        [Display(Name = "Event title*", Prompt = "Wedding ceremony")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A starting time is required")]
        [Display(Name = "Starting time*")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Ending time (optional)")]
        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Must be between 2-150 characters")]
        [Display(Prompt = "The garden")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Must be between 2-150 characters")]
        [Display(Prompt = "18 Willow Lane, Hampshire, England")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Description of some sort must be entered")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Must be between 5-1000 characters")]
        public string Description { get; set; }
    }
}
