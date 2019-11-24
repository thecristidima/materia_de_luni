using CrossRef.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Data
{
	public class CrossRefContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Permission> Permissions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=app.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Author - Permission one-to-one
			modelBuilder.Entity<User>()
				.HasOne(u => u.Permission)
				.WithOne(p => p.Author)
				.HasForeignKey<Permission>(p => p.AuthorId);

			// Author - Article many-to-many
			modelBuilder.Entity<ArticleAuthors>()
				.HasKey(k => new {k.UserId, k.ArticleId});
			modelBuilder.Entity<ArticleAuthors>()
				.HasOne(aa => aa.Article)
				.WithMany(a => a.ArticleAuthors)
				.HasForeignKey(aa => aa.ArticleId);
			modelBuilder.Entity<ArticleAuthors>()
				.HasOne(aa => aa.User)
				.WithMany(u => u.ArticleAuthors)
				.HasForeignKey(aa => aa.UserId);
		}
	}
}