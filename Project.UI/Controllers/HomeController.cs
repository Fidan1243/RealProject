using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Helpers;
using Project.UI.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace Project.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IModelService _modelService;
        private IComboService _comboService;
        private readonly ComboProductsHelper _chelper; 
        private string role = "";
        private string UserName = ""; 
        public HomeController(IProductService productService, IComboService comboService, IModelService modelService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _comboService = comboService;
            _modelService = modelService;
            _chelper = new ComboProductsHelper(_productService, _modelService);
            UserName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            role = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;

        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            var vm = new ProductListViewModel()
            {
                Products = products,
                UserRole = role,
                UserName = UserName
            };
            return View(vm);
        }
        public IActionResult Product(int productId)
        {
            var product = _productService.GetProduct(productId);
            var vm = new ProductViewModel()
            {
                Product = product,
                UserRole = role,
                UserName = UserName
            };
            return View(vm);
        }
        public IActionResult Combination(int comboId)
        {
            var combo = _chelper.ViewModel(_comboService.GetCombo(comboId));

            var vm = new ComboViewModel()
            {
                Combo = combo,
                UserRole = role,
                UserName = UserName
            };
            return View(vm);
        }
        public IActionResult Combinations()
        {

            int pageSize = 10;
            var combos = _comboService.GetCombos();
            var combolist = _chelper.ListViewModel(combos);
            var vm = new ComboListViewModel()
            {
                Combos = combolist,
                UserName = UserName,
                UserRole = role,
            };
            return View(vm);
        }
        public IActionResult CreateCombination()
        {
            var vm = _chelper.CreateViewModel();
            return View(vm);
        }
    }
}
