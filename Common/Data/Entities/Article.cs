using System.Collections.Generic;

namespace CrossRef.Common.Data.Entities
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int YearOfPublication { get; set; }
		public string DOI { get; set; }

		public ICollection<ArticleAuthors> ArticleAuthors { get; set; }
	}

	public class ArticleAuthors
	{
		public int Id { get; set; }
		public int ArticleId { get; set; }
		public int UserId { get; set; }

		// Many-to-many
		public Article Article { get; set; }
		public User User { get; set; }
	}
}