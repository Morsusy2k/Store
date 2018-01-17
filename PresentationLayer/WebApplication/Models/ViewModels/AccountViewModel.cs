using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.PresentationLayer.WebApplication.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The passwords do not match.")]
        public string RepeatPassword { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Phone number")]
        [StringLength(25, MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Address")]
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }

        [DisplayName("Profile picture")]
        public byte?[] Picture { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}