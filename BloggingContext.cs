using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; private set; }

        public BloggingContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = $"{Environment.CurrentDirectory}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Constants.ConnectionString).ReplaceService<IMigrationsSqlGenerator, CustomMigrationsSqlGenerator>();
            //options.UseSqlite($"Data Source={DbPath}").ReplaceService<IMigrationsSqlGenerator, CustomMigrationsSqlGenerator>();
        }
    }
}