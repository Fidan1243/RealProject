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
using Microsoft.AspNetCore.Hosting;
using Project.UI.Helpers;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IMaterialService _materialService;
        private IModelService _modelService;
        private IWebHostEnvironment _webhost;
        private string role = "";
        private UserManager<CustomIdentityUser> _userManager;
        private string UserName = "";
        public AdminController(IWebHostEnvironment webHost,IHttpContextAccessor httpContextAccessor, IProductService productService, UserManager<CustomIdentityUser> useerManager, IMaterialService materialService, IModelService modelService)
        {
            _webhost = webHost;
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
        public async Task<IActionResult> UpdateProductAsync(ProductModifyModel productModifyModel)
        {
            var helper = new ProductModifyHelper(_webhost);
            var updateProduct = await helper.ProductCreation(productModifyModel);
            _productService.UpdateProduct(updateProduct);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddProduct()
        {
            var model = new ProductModifyModel
            {
                Product = new Product(),
                UserRole = role,
                UserName = UserName,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductModifyModel productModifyModel)
        {
            var helper = new ProductModifyHelper(_webhost);
            var addProduct = await helper.ProductCreation(productModifyModel);
            _productService.AddProduct(addProduct);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Accounts()
        {
            var r =  _userManager.Users.ToList();
            return View();
        }
    }
}
