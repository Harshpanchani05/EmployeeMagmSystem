using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is Reuired")]
        [EmailAddress]
        public String Email {  get; set; }

        [Required(ErrorMessage = "Password is Reuired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
