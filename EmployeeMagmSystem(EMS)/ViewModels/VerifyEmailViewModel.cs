using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
    public class VerifyEmailViewModel
    {
     
            [Required(ErrorMessage = "Email is Required.")]
            [EmailAddress]
            public string Email { get; set; }
        
    }
}
