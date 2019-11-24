using Microsoft.EntityFrameworkCore.Migrations;

namespace CrossRef.Migrations
{
	public partial class aaa : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				"Salt",
				"Users",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				"Salt",
				"Users");
		}
	}
}