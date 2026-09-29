using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WeddingAppMVC.Models
{
    public class WeddingInfo
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Must be between 2-150 characters.")]
        [Display(Name = "Title*")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Welcome message is required")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Must be between 2-500 characters.")]
        [Display(Name = "Welcome message*")]
        public string WelcomeMessage { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, MinimumLength = 2, ErrorMessage = "Must be between 2-2000 characters")]
        [Display(Name = "Description*")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Contact information is required.")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Must be between 2-500 characters")]
        [Display(Name = "Contact*")]
        public string Contact { get; set; }


        [StringLength(1000, ErrorMessage = "Can be at most 1000 characters.")]
        [Display(Name = "Website description")]
        public string WebsiteDescription { get; set; }


        [StringLength(500, ErrorMessage = "Can be at most 500 characters.")]
        [Display(Name = "Closing message")]
        public string ClosingMessage { get; set; }
    }
}
