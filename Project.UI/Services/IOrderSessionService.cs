using Project.UI.Models;

namespace Project.UI.Services
{
    public interface IOrderSessionService
    {
        OrderListViewModel GetOrders();
        void DeleteOrder(int Id);
        void UpdateOrder(int Id,int Status);
    }
}
