using System;
using System.ComponentModel.DataAnnotations;

namespace kairosapp.Models
{
    public class SignupModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, ErrorMessage="Password must have at least eight character")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",  ErrorMessage="Password Should match")]
        public string ConfirmPassword { get; set; }
    }
}