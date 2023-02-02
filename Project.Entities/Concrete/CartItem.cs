using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.Concrete
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Cart_Id { get; set; }
        public int Quantity { get; set; }
    }
}
