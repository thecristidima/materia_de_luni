using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrossRef.Common.Data.Entities;

namespace CrossRef.Services.DataVisualisation.ViewModels
{
	public class ArticlesViewModel
	{
		[Required] public ICollection<Article> Articles { get; set; }
	}
}