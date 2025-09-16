using Microsoft.AspNetCore.Mvc;

namespace EmployeeMagmSystem_EMS_.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
