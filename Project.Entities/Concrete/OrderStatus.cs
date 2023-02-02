using Project.Core.Entities;


namespace Project.Entities.Concrete
{
    public class OrderStatus:IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
