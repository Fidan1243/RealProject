using Microsoft.AspNetCore.Http;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Models;
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
            order.Status_Id = Status;
            _orderService.UpdateOrder(order);
        }
    }
}
