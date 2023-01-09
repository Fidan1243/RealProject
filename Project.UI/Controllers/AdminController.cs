using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.UI.Entities;
using System.Security.Claims;
using System.Linq;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private string role = "";
        private UserManager<CustomIdentityUser> _userManager;
        private string UserName = "";
        public AdminController(IHttpContextAccessor httpContextAccessor, IProductService productService, UserManager<CustomIdentityUser> useerManager)
        {
            UserName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            role = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            _productService = productService;
            _userManager = useerManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeleteProduct(int productId)
        {
            _productService.RemoveProduct(productId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult UpdateProduct(int productId)
        {
            return View(productId);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult Accounts()
        {
            var r =  _userManager.Users.ToList();
            return View();
        }
    }
}
