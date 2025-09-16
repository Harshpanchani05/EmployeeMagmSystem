using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Reuired")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Reuired")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "Password is Reuired")]
        [StringLength(40, MinimumLength =8,ErrorMessage ="The {0} must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword" , ErrorMessage ="Pasword does not match.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password is Reuired")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
