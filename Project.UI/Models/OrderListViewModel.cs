using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class OrderListViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }
        public List<Model> Models { get; set; }
        public List<Material> Materials { get; set; }
        public double Total { get; set; }
        public User User { get; set; }
    }
}
