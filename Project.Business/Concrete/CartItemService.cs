using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class CartItemService : ICartItemService
    {
        private ICartItemDal _cartItemDal;

        public CartItemService(ICartItemDal comboDal)
        {
            _cartItemDal = comboDal;
        }

        public void AddCartItem(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
        }

        public CartItem GetCartItem(int id)
        {
            var cartItem = _cartItemDal.Get(g => g.Id == id);
            return cartItem;
        }

        public List<CartItem> GetCartItems()
        {
            var cartItem = _cartItemDal.GetList();
            return cartItem;
        }

        public List<CartItem> GetCartItemsByCart(int id)
        {
            var cartItem = _cartItemDal.GetList(g => g.Cart_Id == id);
            return cartItem;
        }

        public void RemoveCartItem(int id)
        {
            _cartItemDal.Delete(GetCartItem(id));
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
        }
    }
}
