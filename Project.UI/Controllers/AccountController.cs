using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Entities;
using WebApplication3.Models;

namespace Project.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _usermanager;
        private RoleManager<CustomIdentityRole> _rolemanager;
        private SignInManager<CustomIdentityUser> _signInmanager;

        public AccountController(UserManager<CustomIdentityUser> usermanager, RoleManager<CustomIdentityRole> rolemanager, SignInManager<CustomIdentityUser> signInmanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _signInmanager = signInmanager;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInmanager.PasswordSignInAsync(loginViewModel.Username,
                    loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email
                };

                IdentityResult result = _usermanager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {

                    if (!_rolemanager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin"
                        };

                        IdentityResult roleResult = _rolemanager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can not add the role");
                            return View(registerViewModel);
                        }
                    }
                    _usermanager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login");
                }


            }
            return View(registerViewModel);
        }

    }
}
