using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface ICartItemService
    {
        List<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        List<CartItem> GetCartItemsByCart(int id);
        void AddCartItem(CartItem cartItem);
        void RemoveCartItem(int id);
        void UpdateCartItem(CartItem cartItem);
    }
}
