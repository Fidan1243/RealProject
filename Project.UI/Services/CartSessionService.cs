﻿using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _httpContextAccessor;
        private ICartItemService _cartItemService;
        private ICartService _cartService;
        private IProductService _productService;
        private IOrderService _orderService;
        private User user;
        public CartSessionService(IUserService userService, IHttpContextAccessor httpContextAccessor, ICartItemService cartItemService, ICartService cartService, IProductService productService, IOrderService orderService)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartItemService = cartItemService;
            _cartService = cartService;
            user = userService.GetUsers().Find(i => i.User_Id == httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
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

            _cartItemService.AddCartItem(new CartItem
            {
                Product_Id = productId,
                Quantity = Quantity,
                Cart_Id = cart.Id
            });
        }

        public void BuyCart()
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
            var prod =_productService.GetProduct(list.Product_Id);
            prod.Quantity -= list.Quantity <= prod.Quantity ? list.Quantity : prod.Quantity;
            prod.OrderCount += list.Quantity <= prod.Quantity ? list.Quantity : prod.Quantity;
            _productService.UpdateProduct(prod);
        }

        public CartViewModel GetCart()
        {
            var cart = _cartService.GetCarts().FirstOrDefault(i => i.User_Id == user.Id);
            var viewModelList = new CartViewModel()
            { CartItems = new List<CartItemViewModel>() };
            if (cart != null)
            {
                var list = _cartItemService.GetCartItemsByCart(cart.Id);
                if (list != null)
                {

                    foreach (var item in list)
                    {
                        var product = _productService.GetProduct(item.Product_Id);

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
            return viewModelList;
        }

        public void RemoveCartItem(int id)
        {
            _cartItemService.RemoveCartItem(id);
        }

    }
}