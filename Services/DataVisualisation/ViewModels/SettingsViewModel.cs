using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrossRef.Services.DataVisualisation.ViewModels
{
	public class SettingsViewModel
	{
		[Required] [DisplayName("First name")] public string FirstName { get; set; }

		[Required] [DisplayName("Last name")] public string LastName { get; set; }

		[Required] public string Biography { get; set; }

		[Required]
		[DisplayName("Date of birth")]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[DisplayName("Affiliation")]
		public string Affiliation { get; set; }
	}
}