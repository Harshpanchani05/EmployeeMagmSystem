using EmployeeMagmSystem_EMS_.Models;
using EmployeeMagmSystem_EMS_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMagmSystem_EMS_.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        
        public RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<Users> UserManager { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<Users> userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            ViewData["Role"] = "active";
            var roles = RoleManager.Roles;
            return View(roles);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await RoleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} can not be found";
                return View("NotFound");
            }
            else
            {
                var result = await RoleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Recoed Delete SuccessFully";
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    Console.WriteLine(error.Description);
                }
               
                return View("ListRoles");
            }
        }
       
        
        [HttpGet]
        public IActionResult CreateRole()
        {
            ViewData["Role"] = "active";
            return View("CreateEditRole", new RoleViewModel());
        }

        
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            ViewData["Role"] = "active";
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var model = new RoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
          
            return View("CreateEditRole", model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEditRole", model);
            }

            if (string.IsNullOrEmpty(model.Id))
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await RoleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Role Add successfully!";
                    return RedirectToAction("ListRoles", "Administration");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    TempData["AlertMessageWroag"] = "Role is Already Exit.";
                    return RedirectToAction("ListRoles");
                }
            }
            else
            {
                var role = await RoleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id  ={model.Id} can't be found";
                    return View("NotFound", "Views");
                }
                else
                {
                    role.Name = model.RoleName;
                    var result = await RoleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        TempData["AlertMessage"] = "Role Update SuccessFully";
                        return RedirectToAction("ListRoles");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        TempData["AlertMessageWroag"] = "Role is Already Exit.";
                        return RedirectToAction("ListRoles");
                    }
                    return View(model);
                }
            }

            return RedirectToAction("ListRoles");
        }
    }
}


   