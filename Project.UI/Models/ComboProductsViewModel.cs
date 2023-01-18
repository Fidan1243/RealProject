using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ComboProductsViewModel
    {
        public List<Product> Marbles { get; set; }
        public List<Product> Decoration_Marbles { get; set; }
        public List<Product> SinkUnits { get; set; }
        public List<Product> Showers { get; set; }
        public List<Product> Toilets { get; set; }
        public List<Product> Mirrors { get; set; }
    }
}
