using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossRef.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"Articles",
				table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Title = table.Column<string>(nullable: true),
					YearOfPublication = table.Column<int>(nullable: false)
				},
				constraints: table => { table.PrimaryKey("PK_Articles", x => x.Id); });

			migrationBuilder.CreateTable(
				"Users",
				table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Email = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true),
					FirstName = table.Column<string>(nullable: true),
					LastName = table.Column<string>(nullable: true)
				},
				constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"Articles");

			migrationBuilder.DropTable(
				"Users");
		}
	}
}