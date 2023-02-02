using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ComboMViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User_Id { get; set; }
        public Product Marble { get; set; }
        public Product Decoration_Marble { get; set; }
        public Product SinkUnit { get; set; }
        public Product Shower { get; set; }
        public Product Toilet { get; set; }
        public Product Mirror { get; set; }
        public int Marble_Count { get; set; } = 0;
        public int Decoration_Marble_Count { get; set; } = 0;
        public double Total { get; set; } = 0;
    }
}
