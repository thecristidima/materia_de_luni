using System;
using System.Collections.Generic;

namespace CrossRef.Common.Data.Entities
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int YearOfPublication { get; set; }
        public DateTime? Published { get; set; }
        public string DOI { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

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

    public class Collaborator
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CollaboratorId { get; set; }

        public User AuthorUser { get; set; }
        public User CollaboratorUser { get; set; }
    }
}