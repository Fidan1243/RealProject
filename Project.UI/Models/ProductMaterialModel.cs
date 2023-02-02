using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ProductMaterialModel
    {
        public int ProductId { get; set; }
        public CartViewModel Cart { get; set; }
        public List<Model> Models { get; set; }
        public Material Material { get; set; }
    }
}
