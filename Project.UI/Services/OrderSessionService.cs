using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
using System.Linq;
using System.Security.Claims;

namespace Project.UI.Services
{
    public class OrderSessionService : IOrderSessionService
    {
        private IOrderService _orderService;
        private IOrderStatusService _orderStatusService;
        private IProductService _productService;
        private User user;

        public OrderSessionService(IHttpContextAccessor httpContextAccessor, IUserService userService, IOrderService orderService, IOrderStatusService orderStatusService, IProductService productService)
        {
            _orderService = orderService;
            _orderStatusService = orderStatusService;
            user = userService.GetUsers().Find(i => i.User_Id == httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _productService = productService;
        }

        public void DeleteOrder(int Id)
        {
            _orderService.RemoveOrder(Id);
        }

        public OrderListViewModel GetOrders()
        {
            var orders = _orderService.GetOrders();
            OrderListViewModel model = new OrderListViewModel
            {
                Orders = new System.Collections.Generic.List<OrderViewModel>(),
                OrderStatuses = _orderStatusService.GetOrderStatuses()
            };
            if (orders != null)
            {
                orders.OrderBy(i => i.Status_Id);
                if (user.Role != "Admin")
                {
                    orders = orders.FindAll(i => i.User_Id == user.Id);
                }
                foreach (var item in orders)
                {
                    model.Orders.Add(new OrderViewModel
                    {
                        Order = item,
                        Product = _productService.GetProduct(item.Product_Id),
                        OrderStatus = _orderStatusService.GetOrderStatus(item.Status_Id)
                    });
                }

            }

            return model;
        }

        public void UpdateOrder(int Id,int Status)
        {
            var order = _orderService.GetOrder(Id);
            if (order != null)
            {
                if(_orderStatusService.GetOrderStatus(order.Status_Id).Status == "Canceled")
                {
                    var pr = _productService.GetProduct(order.Product_Id);
                    pr.OrderCount -= order.Quantity;
                    pr.Quantity += order.Quantity;
                    _productService.UpdateProduct(pr);
                }
            order.Status_Id = Status;
            _orderService.UpdateOrder(order);
            }
        }
    }
}
