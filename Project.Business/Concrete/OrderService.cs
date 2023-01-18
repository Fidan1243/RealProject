using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Business.Concrete
{
    public class OrderService : IOrderService
    {
        IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void AddOrder(Order orderr)
        {
            _orderDal.Add(orderr);
        }

        public Order GetOrder(int id)
        {
            var user = _orderDal.Get(g => g.Id == id);
            return user;
        }

        public List<Order> GetOrders()
        {
            var users = _orderDal.GetList();
            return users;
        }

        public void RemoveOrder(int id)
        {
            _orderDal.Delete(GetOrder(id));
        }

        public void UpdateOrder(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
