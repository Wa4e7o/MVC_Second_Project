namespace MovieSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        //With this class make custom user role
        [Display(Name = "Username")]
        public string FullName { get; set; }
    }
}
