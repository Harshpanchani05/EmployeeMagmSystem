using Microsoft.AspNetCore.Identity;

namespace EmployeeMagmSystem_EMS_.Models
{
    public class Users: IdentityUser
    {

       
        public string FullName { get; set; }
       
    }
}
