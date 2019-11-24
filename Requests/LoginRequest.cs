using Newtonsoft.Json;

namespace CrossRef.Requests
{
	public class LoginRequest : IRequest
	{
		[JsonProperty("email")] public string Email { get; set; }

		[JsonProperty("password")] public string Password { get; set; }

		public bool IsValid()
		{
			return !(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password));
		}
	}
}