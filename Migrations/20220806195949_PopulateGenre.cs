using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    public partial class PopulateGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'Adventure')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Science Fiction')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Drama')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (6, 'Fantasy')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (7, 'Animation')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (8, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (9, 'Thriller')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
