using rndcorecustomoperations.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace rndcorecustomoperations
{
    public class CreateBlogOperation : MigrationOperation
    {
        public CreateBlogOperation()
        {
            this.Blogs = new List<Blog>();
        }

        public IList<Blog> Blogs { get; set; }
    }
}