using System;
using System.Collections.Generic;

namespace CrossRef.Data.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Biography { get; set; }
		public string Affiliation { get; set; }

		public string Salt { get; set; }

		public Permission Permission { get; set; }

		public ICollection<ArticleAuthors> ArticleAuthors { get; set; }
	}
}