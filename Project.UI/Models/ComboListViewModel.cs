using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ComboListViewModel
    {
        public List<ComboMViewModel> Combos { get; set; }
        public CartViewModel Cart { get; set; }
        public List<Model> Models { get; set; }
        public List<Material> Materials { get; set; }
        public User User { get; set; }
    }
}
