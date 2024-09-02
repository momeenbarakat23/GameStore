using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.ModelView;

namespace store.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AdminsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModelView register)
        {
            if (ModelState.IsValid)
            {
                var Userapp = new AppUser();
                Userapp.Email = register.Email;
                Userapp.UserName = register.Name;
                Userapp.Address = register.Address;
                Userapp.PasswordHash = register.Password;
                var result = await userManager.CreateAsync(Userapp, Userapp.PasswordHash);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(Userapp, "Admin");
                    await signInManager.SignInAsync(Userapp, false);
                    return View();
                }
                foreach (var user in result.Errors)
                {
                    ModelState.AddModelError("", user.Description);
                }
                
            }
            return View(register);



        }
    }
}
