using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrossRef.Services.Register
{
	public class RegisterViewModel
	{
		[Required] public string Email { get; set; }

		[Required] [DisplayName("First name")] public string FirstName { get; set; }

		[Required] [DisplayName("Last name")] public string LastName { get; set; }

		[Required] public string Password { get; set; }
	}
}