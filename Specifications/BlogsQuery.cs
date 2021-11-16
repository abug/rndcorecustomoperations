using System.Collections.Generic;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Specifications
{
    public class BlogsQuery : BaseQuery<Blog>
    {
        public BlogsQuery() : base()
        {
        }

        public override string QueryBody => "SELECT * FROM Blogs";
    }
}