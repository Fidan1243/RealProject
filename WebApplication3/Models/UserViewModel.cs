using Microsoft.AspNetCore.Http;

namespace Project.UI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }

        public IFormFile File { get; set; }
        public string ImageUrl { get; set; } = "~/person.jpg";
    }
}
