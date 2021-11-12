using System.Collections.Generic;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Repositories
{
    public class BlogsQuery : BaseQuery<Blog>
    {
        public BlogsQuery() : base()
        {
        }

        public override string QueryBody => "SELECT * FROM Blogs";
    }
}