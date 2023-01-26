using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
    }
}
