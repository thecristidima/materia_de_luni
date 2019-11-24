using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossRef.Migrations
{
	public partial class aa : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"ArticleAuthors",
				table => new
				{
					ArticleId = table.Column<int>(nullable: false),
					UserId = table.Column<int>(nullable: false),
					Id = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ArticleAuthors", x => new {x.UserId, x.ArticleId});
					table.ForeignKey(
						"FK_ArticleAuthors_Articles_ArticleId",
						x => x.ArticleId,
						"Articles",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_ArticleAuthors_Users_UserId",
						x => x.UserId,
						"Users",
						"Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				"IX_ArticleAuthors_ArticleId",
				"ArticleAuthors",
				"ArticleId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"ArticleAuthors");
		}
	}
}