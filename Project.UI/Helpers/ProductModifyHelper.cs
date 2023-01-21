using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Project.Entities.Concrete;
using Project.UI.Models;
using System.IO;
using System.Threading.Tasks;

namespace Project.UI.Helpers
{
    public class ProductModifyHelper
    {
        private readonly IWebHostEnvironment _webhost;

        public ProductModifyHelper(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }

        public async Task<Product> ProductCreation(ProductModifyModel modifyModel)
        {
            if(modifyModel.File != null)
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

    }
}
