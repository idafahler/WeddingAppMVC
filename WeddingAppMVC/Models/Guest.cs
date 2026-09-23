using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WeddingAppMVC.Models
{
    public class Guest
    {
        [BindNever] //Id is set in controller, not by the user in form
        public int Id { get; set; }


        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name needs to be between 2 - 50 characters.")]
        [Display(Name = "First name*")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Name needs to be between 2 - 70 characters.")]
        [Display(Name = "Last name*")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Submit a valid email address")]
        [StringLength(254, ErrorMessage = "Email needs to be maximum 254 characters.")]
        [Display(Name = "Email*")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Submit a valid phone number")]
        [Display(Name = "Phone number*", Prompt = "070 123 45 67")]
        public string PhoneNumber { get; set; }


        [Display(Name = "I will attend ")]
        public bool? Attendance { get; set; }


        [Range(1, 10, ErrorMessage = "Number of attendants can only be between 1-10")]
        [Display(Name = "Number of attendants")]
        public int? NumberOfAttendants { get; set; } = 1; //Default is 1


        [StringLength(150, ErrorMessage = "Message can be at most 150 characters.")]
        [Display(Name = "Message (optional)")]
        public string? Message { get; set; }


        [BindNever] //RegistrationDate is set in controller, not by user in form
        [Display(Name = "Registration date")]
        public DateTime RegistrationDate { get; set; }


        public string FullName => $"{FirstName} {LastName}";
    }
}
