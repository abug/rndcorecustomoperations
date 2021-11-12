using rndcorecustomoperations.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace rndcorecustomoperations
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<CreateBlogOperation> CreateBlogs(
            this MigrationBuilder migrationBuilder)
        {
            // Read seed data from JSON
            var fileName = "blog.json";
            var fileContent = File.ReadAllText(fileName);
            var blogsFromFile = JsonSerializer.Deserialize<List<Blog>>(fileContent);
            var operation = new CreateBlogOperation();

            foreach (var blog in blogsFromFile)
            {
            operation.Blogs.Add(blog);
            }

            migrationBuilder.Operations.Add(operation);

            return new OperationBuilder<CreateBlogOperation>(operation);
        }
    }
}