using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.UI.Models
{
    public class ComboListViewModel
    {
        public List<ComboViewModel> Combos { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
    }
}
