using System;
using System.ComponentModel.DataAnnotations;

namespace Project.UI.Models
{
    public class LoginViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
