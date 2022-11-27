using System.ComponentModel.DataAnnotations;

namespace Project.UI.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfrimNewPassword { get; set; }
    }
}
