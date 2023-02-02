using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Project.Business.Abstract;
using Project.UI.Models;
using Project.UI.Services;

namespace Project.UI.ViewComponents
{
    public class CartViewComponent:ViewComponent
    {
        private ICartSessionService _cartService;

        public CartViewComponent(ICartSessionService cartService)
        {
            _cartService = cartService;
        }

        public ViewViewComponentResult Invoke()
        {

            var model = _cartService.GetCart();
            return View(model);
        }
    }
}
