using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public Model ProductModel { get; set; }
        public List<ProductMaterialModel> Materials  { get; set; }
        public List<Material> MainMaterials { get; set; }
        public CartViewModel Cart { get; set; }
        public List<Model> Models { get; set; }
        public User User { get; set; }
    }
}
