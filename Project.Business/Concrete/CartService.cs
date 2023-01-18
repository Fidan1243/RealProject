using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class CartService : ICartService
    {
        private ICartDal _cartDal;

        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddCart(Cart cart)
        {
            _cartDal.Add(cart);
        }

        public Cart GetCart(int id)
        {
            var cart = _cartDal.Get(g => g.Id == id);
            return cart;
        }

        public List<Cart> GetCarts()
        {
            var carts = _cartDal.GetList();
            return carts;
        }

        public List<Cart> GetCartsByUser(int id)
        {
            var cartItem = _cartDal.GetList(g => g.User_Id == id);
            return cartItem;
        }

        public void RemoveCart(int id)
        {
            _cartDal.Delete(GetCart(id));
        }
    }
}
