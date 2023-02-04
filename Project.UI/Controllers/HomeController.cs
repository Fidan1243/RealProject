using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Helpers;
using Project.UI.Models;
using Project.UI.Services;
using Project.UI.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProductService _productService;
        private IModelService _modelService;
        private IMaterialService _materialService;
        private IOrderStatusService _orderStatusService;
        private IComboService _comboService;
        private IUserService _userService;
        private readonly ComboProductsHelper _chelper;
        private readonly ICartSessionService _carthelper;
        private readonly IOrderSessionService _orderSessionService;
        private ProductModifyHelper _mhelper;
        private User user;
        public HomeController(IWebHostEnvironment _webHost, ICartSessionService CartService, IProductService productService, IComboService comboService, IModelService modelService, IUserService userService, IMaterialService materialService, IOrderSessionService orderSessionService, IOrderStatusService orderStatusService)
        {
            _productService = productService;
            _comboService = comboService;
            _modelService = modelService;
            _carthelper = CartService;
            _chelper = new ComboProductsHelper(_productService, _modelService, _carthelper, materialService);
            _userService = userService;
            _materialService = materialService;
            _mhelper = new ProductModifyHelper(_webHost, _productService, _modelService, _materialService, CartService);
            _orderSessionService = orderSessionService;
            _orderStatusService = orderStatusService;
        }
        List<Model> Models { get; set; }
        public async Task<IActionResult> Index(int modelId = 0, int materialId = 0)
        {
            user = Static.UserStart(this, _userService);
            var vm = await _mhelper.Product(modelId, materialId);
            vm.User = user;
            return View(vm);
        }
        public async Task<IActionResult> Product(int productId)
        {
            user = Static.UserStart(this, _userService);
            var vm = await _mhelper.ProductDetails(productId);
            vm.MainMaterials = _materialService.GetMaterials();
            vm.User = user;
            return View(vm);
        }
        public async Task<IActionResult> Products(int modelId = 0, int materialId = 0)
        {
            user = Static.UserStart(this, _userService);
            var vm = await _mhelper.Product(modelId, materialId);
            vm.User = user;
            return View(vm);
        }
        public IActionResult AddToCart(int productId, int Quantity = 1)
        {
            _carthelper.AddCartItem(productId, Quantity);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFromCart(int itemId)
        {
            _carthelper.RemoveCartItem(itemId);
            return RedirectToAction("Cart");
        }
        public IActionResult Cart()
        {
            user = Static.UserStart(this, _userService);

            var vm = _carthelper.GetCart();

            vm.Models = _modelService.GetModels();
            vm.Materials = _materialService.GetMaterials();
            vm.User = user;
            return View(vm);
        }

        public IActionResult Combination(int comboId)
        {
            user = Static.UserStart(this, _userService);
            var combo = _chelper.ViewModel(_comboService.GetCombo(comboId));

            var vm = new ComboViewModel()
            {
                Combo = combo,
                Models = _modelService.GetModels(),
                Materials = _materialService.GetMaterials(),
                User = user
            };
            return View(vm);
        }

        public async Task<IActionResult> MaterialsAsync()
        {
            user = Static.UserStart(this, _userService);
            var vm = await _mhelper.Product();
            vm.User = user;
            return View(vm);
        }

        public async Task<IActionResult> ModelsAsync()
        {
            user = Static.UserStart(this, _userService);
            var vm = await _mhelper.Product();
            vm.User = user;
            return View(vm);
        }
        public IActionResult Combinations()
        {
            user = Static.UserStart(this, _userService);
            var combolist = _chelper.ListViewModel(_comboService.GetCombos());
            var vm = new ComboListViewModel()
            {
                Combos = combolist,
                Models = _modelService.GetModels(),
                Materials = _materialService.GetMaterials(),
                User = user
            };
            return View(vm);
        }
        public IActionResult CreateCombination()
        {

            user = Static.UserStart(this, _userService);
            var vm = _chelper.CreateViewModel(user);
            return View(vm);
        }
        public IActionResult Checkout()
        {
            user = Static.UserStart(this, _userService);

            var vm = _carthelper.GetCart();

            vm.Models = _modelService.GetModels();
            vm.Materials = _materialService.GetMaterials();
            vm.User = user;
            return View(vm);
        }

        public IActionResult UpdateCart(int Id, int Quantity)
        {
            user = Static.UserStart(this, _userService);
            _carthelper.EditCartItem(Id, Quantity);

            return Redirect("Cart");
        }
        public IActionResult Order(string City, string Address)
        {
            user = Static.UserStart(this, _userService);

            _carthelper.BuyCart(Address, City);
            return Redirect("Index");
        }
        public IActionResult Orders()
        {
            user = Static.UserStart(this, _userService);
            var vm = _orderSessionService.GetOrders();
            vm.Models = _modelService.GetModels();
            vm.Materials = _materialService.GetMaterials();
            vm.User = user;
            return View(vm);
        }
        public IActionResult CancelOrder(int orderId)
        {
            user = Static.UserStart(this, _userService);
            var status = _orderStatusService.GetOrderStatusByName(Static.Canceled);
            _orderSessionService.UpdateOrder(orderId, status.Id);
            return RedirectToAction("Orders");
        }

        [HttpPost]
        public IActionResult CreateCombination(Combo combo)
        {
            user = Static.UserStart(this, _userService);
            combo.User_Id = user.Id;
            _comboService.AddCombo(combo);
            return RedirectToAction("Index", "Home");
        }
    }
}
