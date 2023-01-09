using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
    }
}
