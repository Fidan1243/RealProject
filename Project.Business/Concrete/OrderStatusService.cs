using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class OrderStatusService : IOrderStatusService
    {
        IOrderStatusDal _orderStatusDal;

        public OrderStatusService(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }

        public void AddOrderStatus(OrderStatus orderrStatus)
        {
            _orderStatusDal.Add(orderrStatus);
        }

        public OrderStatus GetOrderStatus(int id)
        {
            var user = _orderStatusDal.Get(g => g.Id == id);
            return user;
        }

        public OrderStatus GetOrderStatusByName(string Status)
        {
            var user = _orderStatusDal.Get(g => g.Status == Status);
            return user;
        }

        public List<OrderStatus> GetOrderStatuses()
        {
            var users = _orderStatusDal.GetList();
            return users;
        }

        public void RemoveOrderStatus(int id)
        {
            _orderStatusDal.Delete(GetOrderStatus(id));
        }

        public void UpdateOrderStatus(OrderStatus order)
        {
            _orderStatusDal.Update(order);
        }
    }
}
