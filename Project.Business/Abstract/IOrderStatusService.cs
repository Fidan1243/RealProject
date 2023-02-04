using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Abstract
{
    public interface IOrderStatusService
    {
        List<OrderStatus> GetOrderStatuses();
        OrderStatus GetOrderStatus(int id);
        OrderStatus GetOrderStatusByName(string Status);
        void AddOrderStatus(OrderStatus orderStatus);
        void UpdateOrderStatus(OrderStatus orderStatus);
        void RemoveOrderStatus(int id);
    }
}
