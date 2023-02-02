using Project.Entities.Concrete;

namespace Project.UI.Models
{
    public class CartItemViewModel
    {
        public Product Product { get; set; }
        public CartItem CartItem { get; set; }
    }
}
