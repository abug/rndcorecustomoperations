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

        public List<Blog> Blogs { get; set; }
    }
}