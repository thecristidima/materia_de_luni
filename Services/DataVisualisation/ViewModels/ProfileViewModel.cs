using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrossRef.Common.Data.Entities;

namespace CrossRef.Services.DataVisualisation.ViewModels
{
	public class ProfileViewModel
	{
		[Required] public string FirstName { get; set; }

		[Required] public string LastName { get; set; }

		[Required] public bool ShowDateOfBirth { get; set; }

		[Required] public bool ShowArticles { get; set; }

		[Required] public bool ShowBiography { get; set; }

		[Required] public bool ShowAffiliation { get; set; }

		public string Biography { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Affiliation { get; set; }
		public List<Article> Articles { get; set; }
	}
}