using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrossRef.Data.Entities;

namespace CrossRef.Models.ViewModels
{
	public class ArticlesViewModel
	{
		[Required] public ICollection<Article> Articles { get; set; }
	}
}