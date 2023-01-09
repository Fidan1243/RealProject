using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Entities.Concrete
{
    public class Combo:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mirror_Id { get; set; }
        public int Sink_Unit_Id { get; set; }
        public int Shower_Id { get; set; }
        public int Toilet_Id { get; set; }
        public double Total { get; set; } = 0;
    }
}
