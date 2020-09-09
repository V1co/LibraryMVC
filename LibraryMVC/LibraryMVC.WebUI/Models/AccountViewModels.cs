using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.WebUI.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"[a-zA-Z]{2,30}", ErrorMessage = "Numbers and special characters cannot be used in First Name field")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"[a-zA-Z]{2,30}", ErrorMessage = "Numbers and special characters cannot be used in Last Name field")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"[0-9]{10,11}", ErrorMessage = "Please provide correct Phone Number format")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"([a-zA-Z0-9]+\s)+([a-zA-Z])+", ErrorMessage = "Please enter valid Address")]
        public string Street { get; set; }
        [Required]
        [RegularExpression(@"([A-Za-z]){2,30}", ErrorMessage = "Numbers and special characters cannot be used in City field")]
        public string City { get; set; }
        [RegularExpression(@"[a-zA-Z]{2,30}", ErrorMessage = "Numbers and special characters cannot be used in County field")]
        public string County { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        [RegularExpression(@"[a-zA-Z]{2}[0-9]{2}[ ][0-9]{1}[a-zA-Z]{2}", ErrorMessage = "Provided Post Code is incorrect")]
        public string PostCode { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
