using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.ModelView;

namespace store.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Role()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Role(RoleModelView role)
        {
            if (ModelState.IsValid)
            {
                var IdentityRole = new IdentityRole();
                IdentityRole.Name = role.NameRole;
                var result = await roleManager.CreateAsync(IdentityRole);
                if (result.Succeeded) 
                {
                    return View();
                
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Role",role);
        }
    }
}
