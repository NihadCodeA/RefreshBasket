using System.ComponentModel.DataAnnotations;

namespace AdminPanelCRUD.ViewModels
{
	public class MemberRegisterViewModel
	{
		[Required]
		[StringLength(maximumLength: 50)]
		public string Fullname { get; set; }
		[Required]
		[StringLength(maximumLength: 100)]
		public string Email { get; set; }
		[Required]
		[StringLength(maximumLength: 40)]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}
