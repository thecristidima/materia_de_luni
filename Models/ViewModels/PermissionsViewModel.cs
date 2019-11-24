using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrossRef.Models.ViewModels
{
	public class PermissionsViewModel
	{
		[Required]
		[DisplayName("Show biography")]
		public bool ShowBiography { get; set; }

		[Required]
		[DisplayName("Show date of birth")]
		public bool ShowDateOfBirth { get; set; }

		[Required]
		[DisplayName("Show affiliation")]
		public bool ShowAffiliation { get; set; }

		[Required]
		[DisplayName("Show published articles information")]
		public bool ShowArticles { get; set; }
	}
}