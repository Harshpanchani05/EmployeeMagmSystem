using EmployeeMagmSystem_EMS_.Data;
using EmployeeMagmSystem_EMS_.Models;
using EmployeeMagmSystem_EMS_.ViewModels;
using EmployeeMagmSystem_EMS_.ViewModels.Department;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace EmployeeMagmSystem_EMS_.Controllers
{
    public class DepartmentController : Controller
    {
        public AppDbContext DbContext { get; }
        public DepartmentController(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }


        [HttpGet]
        public IActionResult CreateDepartment()
        {
            ViewData["Department"] = "active";
            return View("CreateEditDepartment", new DeparmentViewModel());
        }

        
        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {
            ViewData["Department"] = "active";
            var department = await DbContext.Department.FindAsync(id);
            if (department == null) return NotFound();  

            var model = new DeparmentViewModel
            {
                Id = id.ToString(),
                Name = department.Name,
                IsActive = department.IsActive,
            };

            return View("CreateEditDepartment", model);
        }



        [HttpGet]
        public async Task<IActionResult> ListDepartment()
        {
            ViewData["Department"] = "active";
            var departments = await DbContext.Department.OrderByDescending(e => e.Id).ToListAsync();
            return View(departments);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await DbContext.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            DbContext.Department.Remove(department);
            await DbContext.SaveChangesAsync();
            TempData["AlertMessage"] = "Recoed Delete SuccessFully";
            return RedirectToAction("ListDepartment");
        }

       
        [HttpPost]
        public async Task<IActionResult> CreaetEditDepartment(DeparmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEditDepartment", model);
            }

            // id pass no thay to create method call thay 
            if (string.IsNullOrEmpty(model.Id))
            {
                var department = new Department
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                };
                var result = DbContext.Department.Add(department);
                

                TempData["AlertMessage"]= "Dept Added SuccessFully";
            }
            else
            {
                int deptId = int.Parse(model.Id);
                var department = await DbContext.Department.FindAsync(deptId);
                if (department == null)
                {
                    return NotFound();
                }
                department.Name = model.Name;
                department.IsActive = model.IsActive;
                TempData["AlertMessage"] = "Dept Update SuccessFully";

            }
            await DbContext.SaveChangesAsync();
            return RedirectToAction("ListDepartment");
        }
    }

}