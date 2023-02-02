using System.ComponentModel.DataAnnotations;

namespace AdminPanelCRUD.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
