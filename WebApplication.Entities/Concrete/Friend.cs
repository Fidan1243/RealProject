using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Core.Entities;

namespace WebApplication3.Entities.Concrete
{
    public class Friend:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
