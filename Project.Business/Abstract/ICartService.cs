using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface ICartService
    {
        List<Cart> GetCarts();
        Cart GetCart(int id);
        List<Cart> GetCartsByUser(int id);
        void AddCart(Cart cart);
        void RemoveCart(int id);
    }
}
