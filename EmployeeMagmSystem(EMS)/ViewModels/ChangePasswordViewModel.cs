using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
    public class ChangePasswordViewModel
    {
       
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is Required.")]
            [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} character long.")]
            [DataType(DataType.Password)]
            [Compare("ConfirmNewPassword", ErrorMessage = "Passwrod does not Match.")]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "Confirm Password is Required.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm New Password")]
            public string ConfirmNewPassword { get; set; }
        
    }
}
