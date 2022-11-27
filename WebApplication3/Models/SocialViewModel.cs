using Project.Entities.Concrete;
using System.Collections.Generic;
using WebApplication3.Entities;

namespace Project.UI.Models
{
    public class SocialViewModel
    {
        public List<Post> Posts { get; set; }
        public List<int> Friends { get; set; }
        public List<User> Users { get; set; }
        public List<Notification> Notifications { get; set; }
        public string Post { get; set; }
        public UserViewModel User { get; set; }
        public  User CurrentUserr { get; set; }
    }
}
