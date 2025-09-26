using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels
{
        public class RoleViewModel
        {
            public string? Id { get; set; }   

            [Required(ErrorMessage = "Role name is required")]
            public string RoleName { get; set; }
        }
}