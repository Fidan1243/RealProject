using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.UI.Entities;
using System.Security.Claims;
using System.Linq;
using Project.Entities.Concrete;
using Project.UI.Models;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IMaterialService _materialService;
        private IModelService _modelService;
        private string role = "";
        private UserManager<CustomIdentityUser> _userManager;
        private string UserName = "";
        public AdminController(IHttpContextAccessor httpContextAccessor, IProductService productService, UserManager<CustomIdentityUser> useerManager, IMaterialService materialService, IModelService modelService)
        {
            UserName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            role = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            _productService = productService;
            _userManager = useerManager;
            _materialService = materialService;
            _modelService = modelService;
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
            var product = _productService.GetProduct(productId);
            var model = new ProductModifyModel
            {
                Product = product,
                UserRole = role,
                UserName = UserName,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product produc)
        {

            _productService.UpdateProduct(produc);
            return RedirectToAction("Index", "Home");
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
