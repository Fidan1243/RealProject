using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Entities.Concrete
{
    public class Material:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
