using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.Concrete
{
    public class ComboLike:IEntity
    {
        public int Id { get; set; }
        public int Combo_Id { get; set; }
        public int User_Id { get; set; }
    }
}
