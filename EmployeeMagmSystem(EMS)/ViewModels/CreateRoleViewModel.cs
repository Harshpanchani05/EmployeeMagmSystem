using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
    
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }
    }
}
