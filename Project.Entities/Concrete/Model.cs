using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Concrete
{
    public class Model:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
