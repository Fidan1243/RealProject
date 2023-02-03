using Project.UI.Models;
using System.Collections.Generic;

namespace Project.UI.Services
{
    public interface ICartSessionService
    {
        CartViewModel GetCart();
        void RemoveCartItem(int id);
        void BuyCartItem(int id);
        void AddCartItem(int productId,int Quantity);
        void EditCartItem(int Id, int Quantity);
        void BuyCart(string address,string city);
    }
}
