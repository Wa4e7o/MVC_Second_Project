namespace MovieSystem.Models.Accounts
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.ApplicationUser;

    public class RegisterViewModel
    {
        [Display(Name = "User full name !")]
        [Required(ErrorMessage = "Full name is required !")]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required !")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Password is required !")]
        [MinLength(PassWordMinLength)]
        [MaxLength(PassWordMaxLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match !")]
        public string ConfirmPassword { get; set; }
    }
}
