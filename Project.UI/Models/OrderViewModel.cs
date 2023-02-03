using Project.Entities.Concrete;

namespace Project.UI.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
