using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace rndcorecustomoperations
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<CreateBlogOperation> CreateBlogs(
            this MigrationBuilder migrationBuilder)
        {
            var operation = new CreateBlogOperation();
            operation.Blogs.Add(new Blog { BlogId = 1, Url = "https://www.google.com/" });
            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<CreateBlogOperation>(operation);
        }
    }
}