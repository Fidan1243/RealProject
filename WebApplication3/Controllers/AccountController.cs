using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Helpers;
using Project.UI.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        public static UserManager<CustomIdentityUser> _usermanager;
        public static RoleManager<CustomIdentityRole> _rolemanager;
        public static SignInManager<CustomIdentityUser> _signInmanager;
        private  IUserService _userServmanager;
        private IWebHostEnvironment _webhost;
        public AccountController(UserManager<CustomIdentityUser> usermanager, RoleManager<CustomIdentityRole> rolemanager, SignInManager<CustomIdentityUser> signInmanager, IUserService userServmanager, IWebHostEnvironment webhost)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _signInmanager = signInmanager;
            _userServmanager = userServmanager;
            _webhost = webhost;
        }
        [DataType(DataType.Password)]
        public static string CurrentUserPass { get; set; }
        
        public static string CurrentUserId { get; set; }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ChangeThePassword()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
       static CustomIdentityUser user;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInmanager.PasswordSignInAsync(loginViewModel.Username,
                    loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    user = await _usermanager.GetUserAsync(User);

                    CurrentUserPass = loginViewModel.Password;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeThePasswordAsync(ChangePasswordViewModel chViewModel)
        {
                 user = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                var result = _usermanager.ChangePasswordAsync(user,CurrentUserPass,chViewModel.ConfrimNewPassword).Result;
                if (result.Succeeded)
                {
                    CurrentUserPass = chViewModel.NewPassword;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return View(chViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerViewModel)
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

                    var helper = new ImageHelper(_webhost);
                    registerViewModel.ImageUrl = await helper.SaveFile(registerViewModel.File);
                    _usermanager.AddToRoleAsync(user, "Admin").Wait();
                    _userServmanager.Add(new User
                    {
                        User_Id = user.Id,
                        Name = registerViewModel.Name,
                        Surname = registerViewModel.Surname,
                        Email = registerViewModel.Email,
                        ImagePath = registerViewModel.ImageUrl

                    });

                    return RedirectToAction("Login");
                }


            }
            return View(registerViewModel);
        }

    }
}
