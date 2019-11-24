using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrossRef.Models.ViewModels
{
	public class UserListViewModel
	{
		public bool WrongSearch { get; set; }

		[Required] public IEnumerable<Tuple<string, int>> Users { get; set; }
	}
}