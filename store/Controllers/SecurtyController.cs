using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.ModelView;

namespace store.Controllers
{
    public class SecurtyController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public SecurtyController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveRegister(RegisterModelView model)
        {
            if (ModelState.IsValid)
            {
                var datauser = new AppUser();
                datauser.Email = model.Email;
                datauser.UserName = model.Name;
                datauser.PasswordHash = model.Password;
                datauser.Address = model.Address;
                var result = await userManager.CreateAsync(datauser,model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(datauser, isPersistent: false);
                    return RedirectToAction("Index", "GameStore");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View("Register", model);
        }
        [HttpGet]
        public ActionResult LogIn() { return View(); }
        [HttpPost]
        public async Task<ActionResult> LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userapp = await userManager.FindByEmailAsync(login.Email);
                if (userapp != null)
                {
                    var checkpass= await userManager.CheckPasswordAsync(userapp, login.Password);
                    if (checkpass)
                    {
                        await signInManager.SignInAsync(userapp,login.RememberMe);
                        return RedirectToAction("Index","GameStore");
                    }
                }
                ModelState.AddModelError("", "Email Or Password InValid");
            }
            return View(login);
        }
        public async Task<IActionResult> signOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "GameStore");
        }
    }
}
