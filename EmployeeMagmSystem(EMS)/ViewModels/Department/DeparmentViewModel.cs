using System.ComponentModel.DataAnnotations;

namespace EmployeeMagmSystem_EMS_.ViewModels.Department
{
    public class DeparmentViewModel
    {
        public string Id { get; set; } 

        [Required(ErrorMessage = "Deparment name is required")]
        [Display(Name = "Deparment Name")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
