using System.ComponentModel.DataAnnotations;

namespace CrossRef.Models.ViewModels
{
	public class SearchViewModel
	{
		[Required] public string ResearcherName { get; set; }
	}
}