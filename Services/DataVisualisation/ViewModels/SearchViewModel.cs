using System.ComponentModel.DataAnnotations;

namespace CrossRef.Services.DataVisualisation.ViewModels
{
	public class SearchViewModel
	{
		[Required] public string ResearcherName { get; set; }
	}
}