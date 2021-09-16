using Microsoft.EntityFrameworkCore.Migrations;

namespace rndcorecustomoperations.Migrations
{
    public partial class SeedDataFromJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateBlogs();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
