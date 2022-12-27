﻿using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Entities.Concrete
{
    public class Combo:IEntity
    {
        public int Id { get; set; }
        public int LikeCount { get; set; } = 0;
        public int Mirror_Id { get; set; }
        public int Sink_Unit_Id { get; set; }
        public int Marble_Id { get; set; }
        public int Shower_Id { get; set; }
        public int Toilet_Id { get; set; }
        public int Marble_Count { get; set; } = 0;
    }
}
