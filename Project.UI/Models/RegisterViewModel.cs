using System;
using System.ComponentModel.DataAnnotations;

namespace Project.UI.Models
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
