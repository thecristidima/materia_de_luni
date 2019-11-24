using Newtonsoft.Json;

namespace CrossRef.Requests
{
	public class RegisterRequest : IRequest
	{
		[JsonProperty("email")] public string Email { get; set; }

		[JsonProperty("password")] public string Password { get; set; }

		[JsonProperty("firstName")] public string FirstName { get; set; }

		[JsonProperty("lastName")] public string LastName { get; set; }

		public bool IsValid()
		{
			return !(string.IsNullOrEmpty(Email)
			         || string.IsNullOrEmpty(Password)
			         || string.IsNullOrEmpty(FirstName)
			         || string.IsNullOrEmpty(LastName));
		}
	}
}