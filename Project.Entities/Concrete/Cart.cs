using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.Concrete
{
    public class Cart:IEntity
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
    }
}
