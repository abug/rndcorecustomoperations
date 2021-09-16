using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace rndcorecustomoperations
{
    public class CustomMigrationsSqlGenerator : SqliteMigrationsSqlGenerator
    {
        public CustomMigrationsSqlGenerator([NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies, 
            [NotNullAttribute] IRelationalAnnotationProvider migrationsAnnotations) : base(dependencies, migrationsAnnotations)
        {
        }

        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            if (operation is CreateBlogOperation createUserOperation)
            {
                Generate(createUserOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }

        private void Generate(
            CreateBlogOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            foreach (var blog in operation.Blogs)
            {
                builder.Append("INSERT INTO Blogs VALUES(")
                .Append(blog.BlogId.ToString())
                .Append(", ")
                .Append(stringMapping.GenerateSqlLiteral(blog.Url))
                .Append(")")
                .AppendLine(sqlHelper.StatementTerminator).EndCommand();
            }
        }
    }
}