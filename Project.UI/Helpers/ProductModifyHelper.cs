using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
using Project.UI.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Project.UI.Helpers
{
    public class ProductModifyHelper
    {
        private readonly IWebHostEnvironment _webhost;
        private IProductService _productService;
        private IModelService _modelService;
        private IMaterialService _materialService;
        private ICartSessionService _cartService;
        public ProductModifyHelper(IWebHostEnvironment webhost, IProductService productService, IModelService modelService, IMaterialService materialService, ICartSessionService cartService)
        {
            _webhost = webhost;
            _productService = productService;
            _modelService = modelService;
            _materialService = materialService;
            _cartService = cartService;
        }

        public async Task<Product> ProductCreation(ProductModifyModel modifyModel)
        {
            if (modifyModel.File != null)
            {
                var imgPath = await ImageHelper(modifyModel.File);
                modifyModel.Product.ImagePath = imgPath;
            }
            return modifyModel.Product;
        }

        public async Task<string> ImageHelper(IFormFile file)
        {
            var saveimg = Path.Combine(_webhost.WebRootPath, "images", file.FileName);
            using (var img = new FileStream(saveimg, FileMode.Create))
            {
                await file.CopyToAsync(img);
            }
            return file.FileName.ToString();
        }

        public async Task<ProductViewModel> ProductDetails(int productId)
        {
            var product = _productService.GetProduct(productId);
            var model = _modelService.GetModel(product.Model_Id);
            var models = _modelService.GetModels();

            var prs = _productService.GetProductsByName(product.Name);
            List<ProductMaterialModel> materials = new List<ProductMaterialModel>();
            foreach (var item in prs)
            {
                var material = _materialService.GetMaterial(item.Material_Id);
                materials.Add(new ProductMaterialModel()
                {
                    Material = material,
                    ProductId = item.Id
                });
            }
            var pros = _productService.GetProductByModel(product.Model_Id);

            return new ProductViewModel
            {
                Product = product,
                Materials = materials,
                Models = models,
                ProductModel = model,
                RelatedProducts = pros,
                Cart = _cartService.GetCart()
            };
        }

        public async Task<ProductListViewModel> Product(int modelId = 0, int materialId = 0)
        {
            var model = _modelService.GetModels();
            List<Product> Products = new List<Product>();
            if (modelId != 0 || materialId != 0)
            {
                if (modelId != 0 && materialId == 0)
                {
                    Products = _productService.GetProductByModel(modelId);
                }
                else if (materialId != 0 && modelId == 0)
                {
                    Products = _productService.GetProductByMaterial(materialId);
                }
                else
                {
                   Products = _productService.GetProductByCategories(modelId,materialId);

                }
            }
            else
            {
                Products = _productService.GetProducts();
            }

            var materials = _materialService.GetMaterials();

            return new ProductListViewModel
            {
                Products = Products,
                Materials = materials,
                Models = model,
                Cart = _cartService.GetCart()
            };
        }

    }
}
