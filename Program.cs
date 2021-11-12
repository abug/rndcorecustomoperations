using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using rndcorecustomoperations.Models;
using rndcorecustomoperations.Repositories;

namespace rndcorecustomoperations
{
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

        static void Main(string[] args)
        {
            //CreateSeedDataInJson();
            //ReadFromDb();   
            ReadFromDbWithBusiness();
        }

        private static async void ReadFromDbWithBusiness()
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
