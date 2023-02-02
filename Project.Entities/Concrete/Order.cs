using Project.Core.Entities;


namespace Project.Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int User_Id { get; set; }
        public int Status_Id { get; set; }
    }
}
