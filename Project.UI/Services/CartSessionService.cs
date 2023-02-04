using Microsoft.AspNetCore.Http;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Project.UI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private ICartItemService _cartItemService;
        private IHttpContextAccessor _accessor;
        private ICartService _cartService;
        private IProductService _productService;
        private IOrderService _orderService;
        private User user;
        public CartSessionService(IUserService userService, IHttpContextAccessor httpContextAccessor, ICartItemService cartItemService, ICartService cartService, IProductService productService, IOrderService orderService)
        {
            _cartItemService = cartItemService;
            _cartService = cartService;
            _accessor = httpContextAccessor;
            var uu = _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            user = userService.GetUsers().Find(i => i.User_Id == _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _productService = productService;
            _orderService = orderService;
        }

        public void AddCartItem(int productId, int Quantity)
        {
            var cart = _cartService.GetCarts().FirstOrDefault(i => i.User_Id == user.Id);

            if (cart == null)
            {
                _cartService.AddCart(new Cart { User_Id = user.Id });
                cart = _cartService.GetCarts().FirstOrDefault(i => i.User_Id == user.Id);
            }
            var ifex = _cartItemService.GetCartItems().FirstOrDefault(i => i.Cart_Id == cart.Id && i.Product_Id == productId);

            if (ifex != null)
            {
                ifex.Quantity += Quantity;
                _cartItemService.UpdateCartItem(ifex);
            }
            else
            {
                _cartItemService.AddCartItem(new CartItem
                {
                    Product_Id = productId,
                    Quantity = Quantity,
                    Cart_Id = cart.Id
                });
            }
        }

        public void BuyCart(string address,string city)
        {
            var cart = _cartService.GetCarts().FirstOrDefault(i => i.User_Id == user.Id);
            var viewModelList = new List<CartItemViewModel>();
            if (cart != null)
            {
                var list = _cartItemService.GetCartItemsByCart(cart.Id);
                if (list != null)
                {

                    foreach (var item in list)
                    {
                        var cartlist = _cartItemService.GetCartItem(item.Id);
                        _cartItemService.RemoveCartItem(item.Id);
                        var prod = _productService.GetProduct(cartlist.Product_Id);
                        prod.Quantity -= 1;
                        prod.OrderCount += 1;
                        _productService.UpdateProduct(prod);
                        _orderService.AddOrder(new Order
                        {
                            Product_Id = item.Product_Id,
                            Status_Id = 1,
                            User_Id = user.Id,
                            Address = address,
                            City = city,
                            Quantity = item.Quantity,
                        });
                    }
                }
            }
        }

        public void BuyCartItem(int id)
        {
            var list = _cartItemService.GetCartItem(id);
            _cartItemService.RemoveCartItem(id);
            var prod = _productService.GetProduct(list.Product_Id);
            prod.Quantity -= list.Quantity <= prod.Quantity ? list.Quantity : prod.Quantity;
            prod.OrderCount += list.Quantity <= prod.Quantity ? list.Quantity : prod.Quantity;
            _productService.UpdateProduct(prod);
        }

        public void EditCartItem(int Id, int Quantity)
        {
            var cart = _cartItemService.GetCartItem(Id);
            if (cart !=null)
            {
                cart.Quantity = Quantity;
                _cartItemService.UpdateCartItem(cart);
            }
        }

        public CartViewModel GetCart()
        {
            var cart = _cartService.GetCarts().FirstOrDefault(i => i.User_Id == user.Id);
            var viewModelList = new CartViewModel()
            { CartItems = new List<CartItemViewModel>() };
            double total = 0;
            if (cart != null)
            {
                var list = _cartItemService.GetCartItemsByCart(cart.Id);
                if (list != null)
                {

                    foreach (var item in list)
                    {
                        var product = _productService.GetProduct(item.Product_Id);
                        total += product.Price * item.Quantity;
                        viewModelList.CartItems.Add(new CartItemViewModel
                        {
                            Product = product,
                            CartItem = item
                        });
                    }
                }
            }
            else
            {
                _cartService.AddCart(new Cart { User_Id = user.Id });
            }
            viewModelList.Total = total;
            return viewModelList;
        }

        public void RemoveCartItem(int id)
        {
            _cartItemService.RemoveCartItem(id);
        }

    }
}
