using Microsoft.AspNetCore.Http;
using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ProductModifyModel
    {
        public Product Product { get; set; }
        public IFormFile File { get; set; }
        public List<Material> Materials { get; set; }
        public List<Model> Models { get; set; }
        public User User { get; set; }
    }
}
