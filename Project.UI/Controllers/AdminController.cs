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
using Project.UI.Statics;
using Project.UI.Services;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IMaterialService _materialService;
        private IModelService _modelService;
        private IUserService _userService;
        private IWebHostEnvironment _webhost;
        private UserManager<CustomIdentityUser> _userManager;
        private User user;
        private ProductModifyHelper _helper;
        public AdminController(IWebHostEnvironment webHost, ICartSessionService cartService, IUserService userService, IHttpContextAccessor httpContextAccessor, IProductService productService, UserManager<CustomIdentityUser> useerManager, IMaterialService materialService, IModelService modelService)
        {
            _webhost = webHost;
            _productService = productService;
            _userManager = useerManager;
            _materialService = materialService;
            _helper = new ProductModifyHelper(_webhost, _productService, _modelService, _materialService, cartService);

            _modelService = modelService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            user = Static.UserStart(this, _userService);
            return View();
        }
        public IActionResult DeleteProduct(int productId)
        {
            user = Static.UserStart(this, _userService);
            _productService.RemoveProduct(productId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteModel(int modelId)
        {
            user = Static.UserStart(this, _userService);
            _modelService.RemoveModel(modelId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteMaterial(int materialId)
        {
            user = Static.UserStart(this, _userService);
            _materialService.RemoveMaterial(materialId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult UpdateProduct(int productId)
        {
            user = Static.UserStart(this, _userService);
            var product = _productService.GetProduct(productId);
            var model = new ProductModifyModel
            {
                Product = product,
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductAsync(ProductModifyModel productModifyModel)
        {
            user = Static.UserStart(this, _userService);
            var updateProduct = await _helper.ProductCreation(productModifyModel);
            _productService.UpdateProduct(updateProduct);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddProduct()
        {
            user = Static.UserStart(this, _userService);
            var model = new ProductModifyModel
            {
                Product = new Product(),
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductModifyModel productModifyModel)
        {
            user = Static.UserStart(this, _userService);
            var addProduct = await _helper.ProductCreation(productModifyModel);
            _productService.AddProduct(addProduct);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddModel()
        {
            user = Static.UserStart(this, _userService);
            var model = new ModelViewModel
            {
                Model = new Model(),
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddModelAsync(ModelViewModel modelViewModel)
        {
            var filepath = await _helper.ImageHelper(modelViewModel.File);
            modelViewModel.Model.ImagePath = filepath;
            _modelService.AddModel(modelViewModel.Model);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddMaterial()
        {
            user = Static.UserStart(this, _userService);
            var model = new MaterialViewModel
            {
                Material = new Material(),
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddMaterialAsync(MaterialViewModel materialViewModel)
        {
            var filepath = await _helper.ImageHelper(materialViewModel.File);
            materialViewModel.Material.ImagePath = filepath;
            _materialService.AddMaterial(materialViewModel.Material);
            return RedirectToAction("Index", "Home");

        }

        public IActionResult UpdateMaterial(int materialId)
        {
            user = Static.UserStart(this, _userService);
            var model = new MaterialViewModel
            {
                Material = _materialService.GetMaterial(materialId),
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMaterialAsync(MaterialViewModel materialViewModel)
        {
            string filepath = materialViewModel.Material.ImagePath;
            if (materialViewModel.File != null)
            {
                filepath = await _helper.ImageHelper(materialViewModel.File);
            }
            materialViewModel.Material.ImagePath = filepath;
            _materialService.UpdateMaterial(materialViewModel.Material);
            return RedirectToAction("Index", "Home");

        }



        public IActionResult UpdateModel(int modelId)
        {
            user = Static.UserStart(this, _userService);
            var model = new ModelViewModel
            {
                Model = _modelService.GetModel(modelId),
                User = user,
                Materials = _materialService.GetMaterials(),
                Models = _modelService.GetModels(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateModelAsync(ModelViewModel modelViewModel)
        {
            string filepath = modelViewModel.Model.ImagePath;
            if (modelViewModel.File != null)
            {
                filepath = await _helper.ImageHelper(modelViewModel.File);
            }
            modelViewModel.Model.ImagePath = filepath;
            _modelService.UpdateModel(modelViewModel.Model);
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Accounts()
        {
            user = Static.UserStart(this, _userService);
            var r = _userService.GetUsers();
            return View(r);
        }
    }
}
