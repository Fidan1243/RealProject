using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Entities;
using Project.UI.Models;

namespace Project.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private IUserService _userService;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager,
            SignInManager<CustomIdentityUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.Username,
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
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email
                };

                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "User"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can not add the role");
                            return View(registerViewModel);
                        }
                    }
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can not add the role");
                            return View(registerViewModel);
                        }
                    }
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    _userService.AddUser(new User
                    {
                        User_Id = user.Id,
                        Name = registerViewModel.Name,
                        Surname = registerViewModel.Surname,
                        UserName = registerViewModel.Username,
                        Email = registerViewModel.Email,
                        Role = "User"
                    });
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.ToString());
                    return View(registerViewModel);
                }

            }
            return View(registerViewModel);
        }


        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

    }
}
