using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using rndcorecustomoperations.Business;
using rndcorecustomoperations.Models;
using rndcorecustomoperations.Repositories;
using rndcorecustomoperations.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace rndcorecustomoperations
{
    public class Constants
    {
        public static string ConnectionString => 
            "Server=tcp:sqlsrvrndrepos.database.windows.net,1433;Initial Catalog=sqldbrndrepos;Persist Security Info=False;User ID=abugai;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

    public class Program
    {
        private static List<string> urls = new List<string>
        {
            "http://www.youtube.com",
            "http://www.facebook.com",
            "http://www.baidu.com",
            "http://www.yahoo.com",
            "http://www.amazon.com",
            "http://www.wikipedia.org",
            "http://www.qq.com",
            "http://www.google.co.in",
            "http://www.twitter.com",
            "http://www.live.com"
        };

        public static async Task Main(string[] args)
        {
            //CreateSeedDataInJson();
            //ReadFromDb();   
            //await ReadFromDbWithBusiness();
            //await ReadFromDbWithDapper();
            //Console.WriteLine(ExpressionResearch(b => b.Url));
            //await ReadMultipleResults()


            await RegisterServices();
        }

        private static async Task RegisterServices()
        {
            Console.WriteLine("Create host; Register services;");

            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => 
                    services
                    .AddTransient<IDbConnection>(db => new SqlConnection(Constants.ConnectionString))
                    .AddTransient<ISynapseConnection>(db => new DatabaseConnection(Constants.ConnectionString))
                    .AddTransient<IDatabaseConnection>(db => new DatabaseConnection(Constants.ConnectionString))
                    .AddTransient<IDapperRepository, BaseDapperRepository>()
                    .AddTransient<ISynapseRepository, SynapseRepository>()
                    .AddTransient<IDatabaseRepository, DatabaseRepository>()
                    .AddTransient<IBlogsService, BlogsService>())
                .Build();

            Console.WriteLine("Services registered; Read from database;");

            await ReadMultipleResultsWithDI(host.Services);

            //await host.RunAsync();
        }

        private static async Task ReadMultipleResultsWithDI(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();

            var blogsService = serviceScope.ServiceProvider.GetService<IBlogsService>();

            var request = new BlogRequest();
                
            request.BlogIds.Columns.Add("IdValue", typeof(int));
            request.BlogIds.Columns.Add("UrlValue", typeof(string));
            request.BlogIds.Rows.Add(11, "http://www.youtube.com");
            request.BlogIds.Rows.Add(12, "http://www.facebook.com");
            request.BlogIds.Rows.Add(13, "http://www.baidu.com");

            var result = await blogsService.GetBlogResponseAsync(request);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // private static async Task ReadMultipleResults()
        // {
        //     using (var dbContext = new BloggingContext())
        //     {
        //         var blogsService = new BlogsService(
        //             new BaseDapperRepository(dbContext.Database.GetDbConnection())); 

        //         var request = new BlogRequest();
                
        //         request.BlogIds.Columns.Add("IdValue", typeof(int));
        //         request.BlogIds.Columns.Add("UrlValue", typeof(string));
        //         request.BlogIds.Rows.Add(11, "http://www.youtube.com");
        //         request.BlogIds.Rows.Add(12, "http://www.facebook.com");
        //         request.BlogIds.Rows.Add(13, "http://www.baidu.com");

        //         var result = await blogsService.GetBlogResponseAsync(request);

        //         foreach (var item in result)
        //         {
        //             Console.WriteLine(item);
        //         }
        //     }
        // }

        // private static async Task ReadWithService()
        // {
        //     using (var dbContext = new BloggingContext())
        //     {
        //         var blogsService = new BlogsService(new BaseDapperRepository(dbContext.Database.GetDbConnection()));     
        //         var result = await blogsService.GetBlogResponseAsync(new BlogRequest { Id = 11 });

        //         foreach (var item in result)
        //         {
        //             Console.WriteLine(item);
        //         }
        //     }
            
        // }

        private static async Task ReadFromDbWithBusiness()
        {
            using (var dbContext = new BloggingContext())
            {
                 var blogsBusiness = new BlogsBusiness(new BlogsRepository(dbContext));

                 var blogs = await blogsBusiness.FindAsync();

                 foreach (var blog in blogs)
                 {
                     System.Console.WriteLine(blog);
                 }
            }
        }

        /// Read data from db and visually verify correct data seed in console output.
        private static void ReadFromDb()
        {
            using (var dbContext = new BloggingContext())
            {
                 var blogs = dbContext.Blogs;

                 foreach (var blog in blogs)
                 {
                     System.Console.WriteLine(blog);
                 }
            }
        }

        private static async Task ReadFromDbWithDapper()
        {
            using (var dbContext = new BloggingContext())
            {
                var parameters = new DynamicParameters();
                parameters.Add("url", "q");
                var query = "ListBlogsParams";
                var command = new CommandDefinition(
                    query, parameters, commandType: CommandType.StoredProcedure);
                var connection = dbContext.Database.GetDbConnection();
                var blogs = await connection.QueryAsync<Blog>(command);
                foreach (var blog in blogs)
                {
                    System.Console.WriteLine(blog);
                }
            }
        }

        private static string ExpressionResearch(Expression<Func<Blog, object>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return ((PropertyInfo)memberExpression.Member).Name;
        }

        /// Fill database entity list and serialize to json. Than read from file to visually verify in console output.
        private static void CreateSeedDataInJson()
        {
            var blogs = new List<Blog>();

            var limit = 20;
            for (int i = 10; i < limit; i++)
            {
                blogs.Add(new Blog { BlogId = i, Url = urls[limit - i - 1]});
            }

            var jsonString = JsonSerializer.Serialize(blogs);

            var fileName = "blog.json";
            File.WriteAllText(fileName, jsonString);

            var fileContent = File.ReadAllText(fileName);
            System.Console.WriteLine(fileContent);
            var blogsFromFile = JsonSerializer.Deserialize<List<Blog>>(fileContent);

            foreach (var blog in blogsFromFile)
            {
                System.Console.WriteLine(blog);
            }
        }
    }
}
