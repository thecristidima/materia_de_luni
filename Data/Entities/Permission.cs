namespace CrossRef.Data.Entities
{
	public class Permission
	{
		public int Id { get; set; }

		public bool ShowBiography { get; set; }
		public bool ShowDateOfBirth { get; set; }
		public bool ShowAffiliation { get; set; }
		public bool ShowArticles { get; set; }

		public int AuthorId { get; set; }
		public User Author { get; set; }
	}
}