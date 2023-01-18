using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveOrder(int id);
    }
}
